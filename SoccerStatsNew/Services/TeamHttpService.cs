using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using SoccerStatsNew.Data;
using SoccerStatsNew.RequestModels;
using SoccerStatsNew.Utils;

namespace SoccerStatsNew.Services
{
    public class TeamHttpService : IDisposable
    {
        private readonly HttpClient? _httpClient;
        public SoccerStatsDbContext _context { get; set; }
        private string Address { get; } = "https://v3.football.api-sports.io/teams";

        public TeamHttpService(HttpClient httpClient, SoccerStatsDbContext context)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri(Address);

            _httpClient.DefaultRequestHeaders.Add(
                HeaderNames.Accept, "*/*");

            _httpClient.DefaultRequestHeaders.Add(
                HeaderNames.UserAgent, "HttpRequestsSample");

            _httpClient.DefaultRequestHeaders.Add(
              "x-rapidapi-key", "60553e4650d7942cb159d23481c9cbba");

            _context = context;
        }

        public async Task GetTeams(string url)
        {
            var countries = await _context.CountryModel.ToListAsync();

            foreach (var country in countries)
            {
                if (_httpClient != null)
                {
                    if (country.Name != null)
                    {
                        string name = country.Name;
                        HttpResponseMessage response = await _httpClient.GetAsync($"{url}{name}");
                        if (response.IsSuccessStatusCode)
                        {
                            var data = await response.Content.ReadAsStringAsync();

                            var responseObjet = JsonConverterUtil.GetObjectFromJson<TeamRoot>(data);
                            if (responseObjet != null)
                            {
                               await DbUtil.UpdateTeams(responseObjet, _context);
                            }
                          
                        }
                    }
                 
                   
                }
            }
        }


        public async Task<TeamRoot?> GetCountry(string id)
        {
            var countries = await _context.CountryModel.ToListAsync();

            foreach (var country in countries)
            {
                if (_httpClient != null)
                {
                    HttpResponseMessage response = await _httpClient.GetAsync($"teams/?league={id}&season=2022");
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();

                        return JsonConverterUtil.GetObjectFromJsonFile<TeamRoot>(data);
                    }
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