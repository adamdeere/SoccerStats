using SoccerStatsData.RequestModels;
using SoccerStatsNew.Models;
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

        public async Task<PlayerData?> GetPlayers(int id)
        {
            var year = "2023";
            string url = $"players?season={year}&team={id}";
            PlayerData playerData = new();
            var players = await _webService.ObjectGetRequest<PlayerRoot>(url);
            if (players != null)
            {
                FillList(playerData, players);
                
                var page = players.Paging.Total;
                var current = players.Paging.Current;

                for (int i = current; i < page; i++)
                {
                    url = $"players?season={year}&team={id}&page={i + 1}";
                    players = await _webService.ObjectGetRequest<PlayerRoot>(url);
                    if (players != null)
                    {
                       FillList(playerData, players);
                    }
                   
                }
            }
            
            return playerData ?? null;
        }

        private void FillList(PlayerData data, PlayerRoot root)
        {
            foreach (var player in root.Response)
            {
                data.Response.Add(player);
            }
        }
    }
}
