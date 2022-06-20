using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RepoDb;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xove.Shared.Features.Partners;
using System;

namespace Xove.Api.Features.Partners
{
    public class ListPartner : EndpointBaseAsync
        .WithoutRequest
        .WithActionResult<ListPartnerRequest.Response>
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
            try{
                using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")).EnsureOpen();

                var result = await connection.ExecuteQueryAsync<ListPartnerDto>(CreateSql());

                return Ok(new ListPartnerRequest.Response(result.ToList()));
            }
            catch (Exception ex)
            {
                throw;
            }


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
