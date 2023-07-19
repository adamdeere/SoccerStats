using System.Net.Http;
using System.Text;

namespace UtilityLibraries
{
    public class WebService : BaseHttpService
    {
        public WebService(HttpClient httpClient)
            : base(httpClient)
        {
        }

        public async Task<string?> GetJsonString(string parameters)
        {
            if (ClientStatus())
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(parameters);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        return responseData;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return default;
        }

        public async Task<T?> ObjectGetRequest<T>(string parameters)
        {
            if (ClientStatus())
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(parameters);

                    response.EnsureSuccessStatusCode()
                            .LogRequestToConsole();

                    var responseData = await response.Content.ReadAsStringAsync();
                    return JsonHelper.GetObjectFromJson<T>(responseData);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return default;
        }

        public async Task ObjectPostRequest(object postObject)
        {
            if (ClientStatus())
            {
                using StringContent jsonContent = new(
                      JsonHelper.ConvertObjectToJson(postObject),
                      Encoding.UTF8,
                      "application/json");
                try
                {
                    using HttpResponseMessage response = await
                    _httpClient.PostAsync(
                    "todos",
                    jsonContent);

                    response.EnsureSuccessStatusCode()
                            .LogRequestToConsole();

                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"{jsonResponse}\n");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}