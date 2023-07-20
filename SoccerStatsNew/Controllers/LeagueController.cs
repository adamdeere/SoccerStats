using Azure.Core;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using SoccerStatsData.RequestModels.PredictionRequestFiles;
using SoccerStatsNew.DbServices;
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
            var leagueResponse = await _leagueService.ConstructLeagueData(league, year);

            return leagueResponse != null
                ? View(leagueResponse)
            : NotFound();
        }

        public async Task<IActionResult> Team(string team)
        {
            var individualTeam = await _leagueService.GetTeam(team);
            return individualTeam != null
                ? View(individualTeam)
                : NotFound();
        }

        public async Task<JsonResult> Teams_Read([DataSourceRequest] DataSourceRequest request, int league, string year)
        {
            var teamResponse = await _leagueService.GetTeamModels(league, year);

            return teamResponse != null
                ? Json(teamResponse.ToDataSourceResult(request))
                : Json(null);
        }
    }
}