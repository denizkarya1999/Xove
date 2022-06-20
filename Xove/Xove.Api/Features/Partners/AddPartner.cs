using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Xove.Api.Extensions;
using Xove.Domain;
using Xove.Shared;
using Xove.Shared.Features.Partners;
using Xove.Domain.Models;

namespace Xove.Api.Features.Partners
{
    public class AddPartner : EndpointBaseAsync
        .WithRequest<AddPartnerRequest>
        .WithActionResult<CommandResponse>
    {
        private readonly AppDbContext _context;

        public AddPartner(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost(AddPartnerRequest.RouteTemplate)]
        [SwaggerOperation(
               Summary = "Add a partner",
               Description = "Add a partner",
               OperationId = "Partner.Add",
               Tags = new[] { "PartnerEndpoint" })]
        public override async Task<ActionResult<CommandResponse>> HandleAsync(AddPartnerRequest request, CancellationToken cancellationToken = default)
        {
            if (ModelState.IsValid)
            {
                var Partner = new Partner()
                {
                    Id = request.Partner.Id,
                    Age = request.Partner.Age,
                    CurrentPosition = request.Partner.CurrentPosition,
                    FullName = request.Partner.FullName,
                    Gender = request.Partner.Gender,
                    Interests = request.Partner.Interests,
                    Location = request.Partner.Location,
                    SexualOrientation = request.Partner.SexualOrientation,
                    ShortBiography = request.Partner.ShortBiography
                };

                await _context.Partners.AddAsync(Partner);
                await _context.SaveChangesAsync(cancellationToken);

                return Ok(new CommandResponse().Success());
            }
            else
            {
                return BadRequest(new CommandResponse().Errors(ModelState));
            }
        }
    }
}
