using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Xove.Shared.Features.Partners;
using Xove.Web.Services;

namespace Xove.Web.Features.Partners.ListPartner
{
    public class ListPartner : IRequestHandler<ListPartnerRequest, ListPartnerRequest.Response>
    {
        private readonly IHttpService _httpService;

        public ListPartner(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<ListPartnerRequest.Response> Handle(ListPartnerRequest request, CancellationToken cancellationToken)
        {
            return await _httpService.SendGetAsync<ListPartnerRequest.Response>(ListPartnerRequest.RouteTemplate);
        }
    }
}

