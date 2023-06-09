﻿using PracticeApp.Utils;

namespace PracticeApp.HttpServices
{
    public class HttpService : BaseHttpService
    {
        public HttpService(HttpClient httpClient) 
            : base(httpClient)
        {
        }

        public async Task<T?> GetObjectFromJson<T>(string parameters)
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
        public override void Dispose()
        {
            base.Dispose();
        }

       
    }
}
