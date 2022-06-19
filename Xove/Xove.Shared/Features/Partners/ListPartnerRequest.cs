using MediatR;
using System;
using System.Collections.Generic;

namespace Xove.Shared.Features.Partners
{
    public record ListPartnerRequest() : IRequest<ListPartnerRequest.Response>
    {
        public const string RouteTemplate = "/api/partners";
        public record Response(List<ListPartnerDto> Partners);
    }

    public record ListPartnerDto(int Age, string CurrentPosition, string FullName, string Gender, Guid Id, string Interests, string Location, string SexualOrientation, string ShortBiography);
}