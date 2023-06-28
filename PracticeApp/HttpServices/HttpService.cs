namespace PracticeApp.HttpServices
{
    public class HttpService : BaseHttpService
    {
        public HttpService(HttpClient httpClient) 
            : base(httpClient)
        {
        }

        public async Task<T?> GetObjectJson<T>(string parameters)
        {
            return await ConvertResponseToJson<T>(parameters);
        }
        public override void Dispose()
        {
            base.Dispose();
        }

       
    }
}
