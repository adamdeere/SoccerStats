using Azure.Core;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using SoccerStatsNew.Services;
using UtilityLibraries;

namespace SoccerStatsNew.Controllers
{
    public class LeagueController : Controller
    {
        private readonly LeagueDbService _leagueService;
       

        public LeagueController(LeagueDbService leagueService)
        {
            _leagueService = leagueService;
        }

        public async Task<IActionResult> Index(string country)
        {
            var leagues = await _leagueService.GetLeagueDetails(country);

            return leagues != null
                ? View(leagues)
                : NotFound();
        }

        public async Task<IActionResult> Details(int league, string year)
        {
            var teamResponse = await _leagueService.GetTeamModels(league, year);

            return teamResponse != null
                ? View(teamResponse)
                : NotFound();
        }
    }
}