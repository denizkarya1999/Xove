using MediatR;
using System;

namespace Xove.Shared.Features.Partners
{
    public record ViewPartnerRequest(Guid Id) : IRequest<ViewPartnerRequest.Response>
    {
        public const string RouteTemplate = "/api/partners/views/{Id}";

        public record Response(ViewPartnerDto Partner);
    }

    public record ViewPartnerDto(Guid Id, int Age, string CurrentPosition, string FullName, string Gender, string Interests, string Location, string SexualOrientation, string ShortBiography);
}
