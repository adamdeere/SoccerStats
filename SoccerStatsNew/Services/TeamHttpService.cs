using Microsoft.Net.Http.Headers;
using SoccerStatsNew.RequestModels;
using SoccerStatsNew.Utils;

namespace SoccerStatsNew.Services
{
    public class TeamHttpService : IDisposable
    {
        private readonly HttpClient? _httpClient;
        private string Address { get; } = "https://v3.football.api-sports.io/";

        public TeamHttpService(HttpClient httpClient)
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

        public async Task<TeamRoot?> GetCountry(string id)
        {
            if (_httpClient != null)
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"teams/?league={id}&season=2022");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();

                    return JsonConverterUtil.GetObjectFromJson<TeamRoot>(data);
                }
            }
            return null;
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}