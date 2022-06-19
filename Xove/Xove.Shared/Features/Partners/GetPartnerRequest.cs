using MediatR;
using System;

namespace Xove.Shared.Features.Partners
{
    public record GetPartnerRequest(Guid Id) : IRequest<GetPartnerRequest.Response>
    {
        public const string RouteTemplate = "/api/partner/{id}";
        //use the same dto as the add or edit request
        public record Response(PartnerFormModel Partner);
    }
}
