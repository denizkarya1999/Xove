using MediatR;

namespace Xove.Shared.Features.Partners
{
    public record EditPartnerRequest(PartnerFormModel Partner) : IRequest<CommandResponse>
    {
        public const string RouteTemplate = "/api/partner";
    }
}
