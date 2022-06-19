using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Xove.Shared.Features.Partners;
using Xove.Web.Services;

namespace Xove.Web.Features.Partners.ViewPartner
{
    public class ViewPartner : IRequestHandler<ViewPartnerRequest, ViewPartnerRequest.Response>
    {
        private readonly IHttpService _httpService;

        public ViewPartner(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<ViewPartnerRequest.Response> Handle(ViewPartnerRequest request, CancellationToken cancellationToken)
        {
            return await _httpService.SendGetAsync<ViewPartnerRequest.Response>(
                ViewPartnerRequest.RouteTemplate.Replace("{Id}",
                request.Id.ToString()));
        }
    }
}

