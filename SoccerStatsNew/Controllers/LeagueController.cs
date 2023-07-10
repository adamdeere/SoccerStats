using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using SoccerStatsData;
using SoccerStatsNew.Services;
using UtilityLibraries;

namespace SoccerStatsNew.Controllers
{
    public class LeagueController : Controller
    {
        private readonly LeagueDbService _leagueService;
        private readonly WebService _teamService;
        public LeagueController(LeagueDbService leagueService, WebService teamService)
        {
            _teamService = teamService;
            _leagueService = leagueService;
        }
        public async Task<IActionResult> Index(string country)
        {
            var leagues = await _leagueService.GetLeagueDetails(country);
            
            return leagues != null 
                ? View(leagues)
                : NotFound();
        }

        public async Task<ActionResult> Team_Read([DataSourceRequest] DataSourceRequest request, int league, string year)
        {
            string endPoint = $"teams?league={league}&season={year}";
            var teamResponse = JsonHelper.GetObjectFromJsonFile<TeamRoot>("Test/teamsByLeague.json");
            List<TeamsPage> teams = new();
            if (teamResponse != null)
            {
                foreach (var item in teamResponse.Response)
                {
                    teams.Add(item.Team);
                }
            }
            return Json(await teams.ToDataSourceResultAsync(request));
        }

        public async Task<JsonResult> Season_Read(int? LeagueId)
        {
            if (LeagueId == null) 
            { 
                return Json(null);
            }
            var leagues = await _leagueService.GetLeagueAvailableSeasons((int)LeagueId);

            return Json(leagues);

        }
    }
}
