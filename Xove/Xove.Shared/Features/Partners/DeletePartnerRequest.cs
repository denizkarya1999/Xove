using MediatR;
using System;

namespace Xove.Shared.Features.Partners
{
    public record DeletePartnerRequest(Guid PartnerId) : IRequest<CommandResponse>
    {
        //Todo: replace to point to the enpoint
        public const string RouteTemplate = "/api/partner/{PartnerId}";
    }
}
