using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xove.Shared;

namespace Xove.Web.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> SendGetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            else
            {
                throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
            }
        }

        public async Task<CommandResponse> SendPostAsync<T>(string url, T request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);

            return await ConvertToCommandResponse(response);
        }

        public async Task<CommandResponse> SendPostAsync(string url)
        {
            var response = await _httpClient.PostAsync(url, null);

            return await ConvertToCommandResponse(response);
        }

        public async Task<CommandResponse> SendPutAsync<T>(string url, T request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, content);

            return await ConvertToCommandResponse(response);
        }

        public async Task<CommandResponse> SendPutAsync(string url)
        {
            var response = await _httpClient.PutAsync(url, null);

            return await ConvertToCommandResponse(response);
        }

        public async Task SendDeleteAsync(string url)
        {
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
            }
        }
        public async Task<CommandResponse> SendDeleteWithResponseAsync(string url)
        {
            var response = await _httpClient.DeleteAsync(url);

            return await ConvertToCommandResponse(response);
        }

        private static async Task<CommandResponse> ConvertToCommandResponse(HttpResponseMessage response)
        {
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CommandResponse>(result);
        }
    }
}
