using PracticeApp.RequestModels;
using PracticeApp.Utils;

namespace PracticeApp.HttpServices
{
    public class AnotherAbstractionService : BaseHttpService
    {
        public AnotherAbstractionService(HttpClient httpClient) 
            : base(httpClient)
        {
        }

        public async Task<T?> GetGenericObject<T>(string url)
        {
            return await ConvertResponseToJson<T>(url);
        }

        public async Task<ProductRoot?> GetProductList()
        {

            string url = $"whbase2/rest/whbase2Service/product";
            var data = await ReadResponseData(url);
            if (data != null)
            {
                return JsonConverterUtil.GetObjectFromJson<ProductRoot>(data);
            }
            return null;
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
