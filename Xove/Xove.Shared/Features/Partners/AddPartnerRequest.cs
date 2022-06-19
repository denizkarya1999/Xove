using MediatR;

namespace Xove.Shared.Features.Partners
{
    public record AddPartnerRequest(PartnerFormModel Partner) : IRequest<CommandResponse>
    {
        public const string RouteTemplate = "/api/partner";
    }
}
