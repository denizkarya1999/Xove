using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RepoDb;
using Swashbuckle.AspNetCore.Annotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xove.Shared.Features.Partners;

namespace Xove.Api.Features.Partners
{
    public class ListPartner : BaseAsyncEndpoint.WithoutRequest
        .WithResponse<ListPartnerRequest.Response>
    {
        private readonly IConfiguration _configuration;

        public ListPartner(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(ListPartnerRequest.RouteTemplate)]
        [SwaggerOperation(
          Summary = "List Partner",
          Description = "List Partner",
          OperationId = "Partner.List",
          Tags = new[] { "PartnerEndpoint" })]
        public override async Task<ActionResult<ListPartnerRequest.Response>> HandleAsync(CancellationToken cancellationToken = default)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")).EnsureOpen();

            var result = await connection.ExecuteQueryAsync<ListPartnerDto>(CreateSql());

            return Ok(new ListPartnerRequest.Response(result.ToList()));


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
                         FROM dbo.Partners p;";
            }
        }
    }
}
