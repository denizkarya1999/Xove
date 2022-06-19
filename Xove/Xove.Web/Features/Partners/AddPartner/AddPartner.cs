using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Xove.Shared;
using Xove.Shared.Features.Partners;
using Xove.Web.Services;

namespace Xove.Web.Features.Partners.AddPartner
{
    public class AddPartner : IRequestHandler<AddPartnerRequest, CommandResponse>
    {
        private readonly IHttpService _httpService;

        public AddPartner(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<CommandResponse> Handle(AddPartnerRequest request, CancellationToken cancellationToken)
        {
            return await _httpService.SendPostAsync<AddPartnerRequest>(AddPartnerRequest.RouteTemplate, request);
        }
    }
}
