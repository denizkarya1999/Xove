using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Xove.Api.Extensions;
using Xove.Domain;
using Xove.Shared;
using Xove.Shared.Features.Partners;

namespace Xove.Api.Features.Partners
{
    public class EditPartner : BaseAsyncEndpoint
        .WithRequest<EditPartnerRequest>
        .WithResponse<CommandResponse>
    {
        private readonly AppDbContext _context;

        public EditPartner(AppDbContext context)
        {
            _context = context;
        }

        [HttpPut(EditPartnerRequest.RouteTemplate)]
        [SwaggerOperation(
               Summary = "Edit a partner",
               Description = "Edit a partner",
               OperationId = "Partner.Edit",
               Tags = new[] { "PartnerEndpoint" })]
        public override async Task<ActionResult<CommandResponse>> HandleAsync(EditPartnerRequest request, CancellationToken cancellationToken = default)
        {
            if (ModelState.IsValid)
            {
                var Partner = await _context.Partners.FindAsync(request.Partner.Id);

                if (Partner != null)
                {
                    Partner.Age = request.Partner.Age;
                    Partner.CurrentPosition = request.Partner.CurrentPosition;
                    Partner.FullName = request.Partner.FullName;
                    Partner.Gender = request.Partner.Gender;
                    Partner.Interests = request.Partner.Interests;
                    Partner.Location = request.Partner.Location;
                    Partner.SexualOrientation = request.Partner.SexualOrientation;
                    Partner.ShortBiography = request.Partner.ShortBiography;

                    await _context.SaveChangesAsync(cancellationToken);
                }

                return Ok(new CommandResponse().Success());
            }
            else
            {
                return BadRequest(new CommandResponse().Errors(ModelState));
            }
        }
    }
}
