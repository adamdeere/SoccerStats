using Microsoft.AspNetCore.Mvc;
using SoccerStatsData;
using SoccerStatsNew.DbServices;
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

        public async Task<JsonResult> Team_Read()
        {

            var teams = await _teamService.GetObjectRequest<TeamRoot>("teams?league=39&season=2023");

            return teams != null
                ? Json(teams)
                : Json("");
        }
    }
}
