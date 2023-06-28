using Microsoft.Net.Http.Headers;
using PracticeApp.Utils;

namespace PracticeApp.HttpServices
{
    public abstract class BaseHttpService : IDisposable
    {
        protected readonly HttpClient _httpClient;
        protected readonly string Address = "https://192.168.200.70:4911/whbase2/rest/whbase2Service/";
        public BaseHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri(Address);

            _httpClient.DefaultRequestHeaders.Add(
                HeaderNames.Accept, "*/*");

            _httpClient.DefaultRequestHeaders.Add(
                HeaderNames.UserAgent, "HttpRequestsSample");
        }
        public virtual void Dispose()
        {
            _httpClient?.Dispose();
        }

        private bool ClientStatus()
        {
            return _httpClient != null;
        }

        protected async Task<T?> ConvertResponseToJson<T>(string parameters)
        {
            if (ClientStatus())
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(parameters);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        return JsonConverterUtil.GetObjectFromJson<T>(responseData);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return default;
        }
    }
}
