using SoccerStatsData.RequestModels;
using UtilityLibraries;

namespace SoccerStatsNew.DbServices
{
    public class LeagueTableService
    {
        private readonly WebService _WebService;   
        public LeagueTableService(WebService service)
        {
            _WebService = service;
        }

        public async Task<LeagueTableRoot?> GetLeagueTable(int id, string year)
        {
            var url = $"standings?league={id}&season={year}";

            var table = await _WebService.ObjectGetRequest<LeagueTableRoot>(url);
             
            return table ?? null;
        }
    }
}
