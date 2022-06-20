using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RepoDb;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xove.Shared.Features.Partners;

namespace Xove.Api.Features.Partners.ViewPartner
{
    public class ViewPartner : EndpointBaseAsync
        .WithRequest<Guid>
        .WithActionResult<ViewPartnerRequest.Response>
    {
        private readonly IConfiguration _configuration;

        public ViewPartner(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(ViewPartnerRequest.RouteTemplate)]
        [SwaggerOperation(
          Summary = "View a Partner",
          Description = "View a Partner",
          OperationId = "Partner.View",
          Tags = new[] { "PartnerEndpoint" })]
        public override async Task<ActionResult<ViewPartnerRequest.Response>> HandleAsync(Guid id, CancellationToken cancellationToken = default)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")).EnsureOpen();

            var result = await connection.ExecuteQueryAsync<ViewPartnerDto>(CreateSql(), new { Id = id });

            return Ok(new ViewPartnerRequest.Response(result.FirstOrDefault()));

            string CreateSql()
            {
                return @"SELECT
                          i.Age,
                          i.CurrentPosition,
                          i.FullName,
                          i.Gender,
                          i.Id,
                          i.Interests,
                          i.Location,
                          i.SexualOrientation,
                          i.ShortBiography
                        FROM dbo.Partners i
                        WHERE i.Id = @Id";
            }
        }
    }
}
