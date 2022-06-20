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

namespace Xove.Api.Features.Partners
{
    public class GetPartner : EndpointBaseAsync
        .WithRequest<Guid>
        .WithActionResult<GetPartnerRequest.Response>
    {
        private readonly IConfiguration _configuration;

        public GetPartner(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(GetPartnerRequest.RouteTemplate)]
        [SwaggerOperation(
          Summary = "Get Partner",
          Description = "Get Partner",
          OperationId = "Partner.Get",
          Tags = new[] { "PartnerEndpoint" })]
        public override async Task<ActionResult<GetPartnerRequest.Response>> HandleAsync(Guid id, CancellationToken cancellationToken = default)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")).EnsureOpen();

            var result = await connection.ExecuteQueryAsync<PartnerFormModel>(CreateSql(), new { Id = id });

            return Ok(new GetPartnerRequest.Response(result.FirstOrDefault()));


            string CreateSql()
            {
                return @"SELECT
                          p.Age,
                          p.CurrentPosition,
                          p.FullName,
                          p.Gender,
                          p.Id,
                          p.Interests,
                          p.Location,
                          p.SexualOrientation,
                          p.ShortBiography
                         FROM dbo.Partners p
                         WHERE p.Id = @Id;";
            }
        }
    }
}
