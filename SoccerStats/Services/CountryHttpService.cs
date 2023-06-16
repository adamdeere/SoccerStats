using Microsoft.Net.Http.Headers;

namespace SoccerStats.Services
{
    public class CountryHttpService
    {
        private readonly HttpClient? _httpClient;
        private string Address { get; } = "https://v3.football.api-sports.io/countries";

        public CountryHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri(Address);

            _httpClient.DefaultRequestHeaders.Add(
                HeaderNames.Accept, "*/*");

            _httpClient.DefaultRequestHeaders.Add(
                HeaderNames.UserAgent, "HttpRequestsSample");

            _httpClient.DefaultRequestHeaders.Add(
              "x-rapidapi-key", "60553e4650d7942cb159d23481c9cbba");
        }
    }
}