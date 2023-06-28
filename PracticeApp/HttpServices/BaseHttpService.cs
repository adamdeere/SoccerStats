using Microsoft.Net.Http.Headers;
using PracticeApp.Utils;
using static PracticeApp.RequestModels.ItemRequestModel;

namespace PracticeApp.HttpServices
{
    public abstract class BaseHttpService : IDisposable
    {
        protected readonly HttpClient _httpClient;
        protected readonly string Address = "https://192.168.200.70:4911/";
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

        protected async Task<T?> ConvertResponseToJson<T>(string url)
        {
            if (ClientStatus())
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        return JsonConverterUtil.GetObjectFromJson<T>(data);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return default;
        }

        protected async Task<string?> ReadResponseData(string url)
        {
            if (ClientStatus()) 
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        return data;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return null;
        }
    }
}
