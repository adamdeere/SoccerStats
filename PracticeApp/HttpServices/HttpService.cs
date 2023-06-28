using PracticeApp.Utils;
using static PracticeApp.RequestModels.ItemRequestModel;

namespace PracticeApp.HttpServices
{
    public class HttpService : BaseHttpService
    {
        public HttpService(HttpClient httpClient) 
            : base(httpClient)
        {
        }

        public async Task<T?> GetObjectJson<T>(string url)
        {
            return await ConvertResponseToJson<T>(url);
        }

        public async Task<ItemRoot?> GetItemList()
        {
            string url = $"whbase2/rest/whbase2Service/item";
            var data = await ReadResponseData(url);

            if (data != null)
            {
                return JsonConverterUtil.GetObjectFromJson<ItemRoot>(data);
            }

            return null;
        }

        public override void Dispose()
        {
            base.Dispose();
        }

       
    }
}
