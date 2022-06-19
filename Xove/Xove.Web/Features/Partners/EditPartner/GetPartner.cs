using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Xove.Shared.Features.Partners;
using Xove.Web.Services;

namespace Xove.Web.Features.Partners.EditPartner
{
    public class GetPartner : IRequestHandler<GetPartnerRequest, GetPartnerRequest.Response>
    {
        private readonly IHttpService _httpService;

        public GetPartner(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<GetPartnerRequest.Response> Handle(GetPartnerRequest request, CancellationToken cancellationToken)
        {
            return await _httpService.SendGetAsync<GetPartnerRequest.Response>(
                GetPartnerRequest.RouteTemplate.Replace("{id}",
                request.Id.ToString()));
        }
    }
}

