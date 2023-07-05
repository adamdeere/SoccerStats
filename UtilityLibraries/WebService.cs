namespace UtilityLibraries
{
    public class WebService : BaseHttpService
    {
        public WebService(HttpClient httpClient) 
            : base(httpClient)
        {
        }
        public async Task<string> GetJsonString(string parameters)
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
        public async Task<T?> GetObjectRequest<T>(string parameters)
        {
            if (ClientStatus())
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(parameters);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        return JsonHelper.GetObjectFromJson<T>(responseData);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return default;
        }
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
