using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Xove.Shared;
using Xove.Shared.Features.Partners;
using Xove.Web.Services;

namespace Xove.Web.Features.Partners.EditPartner
{
    public class DeletePartner : IRequestHandler<DeletePartnerRequest, CommandResponse>
    {
        private readonly IHttpService _httpService;

        public DeletePartner(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<CommandResponse> Handle(DeletePartnerRequest request, CancellationToken cancellationToken)
        {
            return await _httpService.SendDeleteWithResponseAsync(
                DeletePartnerRequest.RouteTemplate.Replace("{PartnerId}",
                request.PartnerId.ToString()));
        }
    }
}
