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

            var teamResponse = await _leagueService.GetTeamModels(39);
            
            return Json(await teamResponse.ToDataSourceResultAsync(request));
        }
    }
}
