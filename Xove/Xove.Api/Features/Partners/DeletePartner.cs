using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Xove.Shared.Features.Partners;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Xove.Shared;
using Xove.Domain;
using Xove.Api.Extensions;
using System;

namespace Xove.Api.Features.Partners
{
    public class DeletePartner : BaseAsyncEndpoint
        .WithRequest<Guid>
        .WithResponse<CommandResponse>
    {
        private readonly AppDbContext _context;

        public DeletePartner(AppDbContext context)
        {
            _context = context;
        }

        [HttpDelete(DeletePartnerRequest.RouteTemplate)]
        [SwaggerOperation(
               Summary = "Delete a partner",
               Description = "Delete a partner",
               OperationId = "Partner.Delete",
               Tags = new[] { "PartnerEndpoint" })]
        public override async Task<ActionResult<CommandResponse>> HandleAsync(Guid partnerId, CancellationToken cancellationToken = default)
        {
            if (ModelState.IsValid)
            {
                var Partner = await _context.Partners.FindAsync(partnerId);

                if(Partner != null)
                {
                    _context.Partners.Remove(Partner);

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
