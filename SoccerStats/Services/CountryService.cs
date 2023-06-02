using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using SoccerStats.RequestModel;
using System;

namespace SoccerStats.Services
{
    public class CountryService
    {
        private readonly HttpClient? _httpClient;

        public CountryService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri("https://v3.football.api-sports.io/countries");

            // using Microsoft.Net.Http.Headers;
            // The GitHub API requires two headers.
            _httpClient.DefaultRequestHeaders.Add(
                HeaderNames.Accept, "*/*");

            _httpClient.DefaultRequestHeaders.Add(
                HeaderNames.UserAgent, "HttpRequestsSample");

            _httpClient.DefaultRequestHeaders.Add(
              "x-rapidapi-key", "60553e4650d7942cb159d23481c9cbba");
        }

        public async Task<CountryResponse?> GetCountries()
        {
            try
            {
                if (_httpClient != null)
                {
                   // using HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress);

                  //  response.EnsureSuccessStatusCode();
                    string responseBody = await _httpClient.GetStringAsync(_httpClient.BaseAddress);
                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    Console.WriteLine(responseBody);

                    CountryResponse? deserializedProduct = JsonConvert.DeserializeObject<CountryResponse>(responseBody);

                    return deserializedProduct;
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }
    }
}