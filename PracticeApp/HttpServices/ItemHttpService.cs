using PracticeApp.Controllers;
using PracticeApp.RequestModels;
using PracticeApp.Utils;
using static PracticeApp.RequestModels.ItemRequestModel;

namespace PracticeApp.HttpServices
{


    public class ItemHttpService : IDisposable
    {
       
        private readonly HttpClient _httpClient;
        public ItemHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void Dispose()
        {
           _httpClient?.Dispose();
        }

        public async Task<ItemRoot?> GetItemList()
        {
            if (_httpClient != null)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync($"whbase2/rest/whbase2Service/item");
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        return JsonConverterUtil.GetObjectFromJson<ItemRoot>(data);
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
