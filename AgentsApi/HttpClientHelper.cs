using System.Net.Http;

namespace AgentsApi.Services
{
    public class HttpClientHelper
    {
        private readonly HttpClient _httpClient;

        public HttpClientHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public HttpClient GetClient()
        {
            return _httpClient;
        }
    }
}
