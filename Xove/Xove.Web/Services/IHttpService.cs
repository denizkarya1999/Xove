using System.Threading.Tasks;
using Xove.Shared;

namespace Xove.Web.Services
{
    public interface IHttpService
    {
        Task SendDeleteAsync(string url);
        Task<CommandResponse> SendDeleteWithResponseAsync(string url);
        Task<T> SendGetAsync<T>(string url);
        Task<CommandResponse> SendPostAsync(string url);
        Task<CommandResponse> SendPostAsync<T>(string url, T request);
        Task<CommandResponse> SendPutAsync(string url);
        Task<CommandResponse> SendPutAsync<T>(string url, T request);
    }
}