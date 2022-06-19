using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Xove.Shared;
using Xove.Shared.Features.Partners;
using Xove.Web.Services;

namespace Xove.Web.Features.Partners.EditPartner
{
    public class EditPartner : IRequestHandler<EditPartnerRequest, CommandResponse>
    {
        private readonly IHttpService _httpService;

        public EditPartner(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<CommandResponse> Handle(EditPartnerRequest request, CancellationToken cancellationToken)
        {
            return await _httpService.SendPutAsync<EditPartnerRequest>(EditPartnerRequest.RouteTemplate, request);
        }
    }
}
