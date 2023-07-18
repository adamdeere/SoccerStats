using SoccerStatsData.RequestModels;
using UtilityLibraries;

namespace SoccerStatsNew.DbServices
{
    public class PlayerService
    {
        private readonly WebService _webService;
        public PlayerService(WebService service)
        {
            _webService = service;
        }

        public async Task<PlayerRoot?> GetPlayers(int id)
        {
            var year = "2023";
            string url = $"players?season={year}&team={id}";
            var players = await _webService.GetObjectRequest<PlayerRoot>(url);

            return players ?? null;
        }
    }
}
