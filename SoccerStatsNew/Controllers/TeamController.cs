using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using SoccerStatsData.RequestModels;
using SoccerStatsNew.DbServices;
using UtilityLibraries;

namespace SoccerStatsNew.Controllers
{
    public class TeamController : Controller
    {
        private readonly SeasonDbService _seasonDbService;
        private readonly TeamDbService _teamDbService;
        private readonly WebService _webService;

        public TeamController(SeasonDbService seasonDbService, TeamDbService service, WebService wservice)
        {
            _teamDbService = service;
            _seasonDbService = seasonDbService;
            _webService = wservice;
        }

        public async Task<IActionResult> Index(string team)
        {
            var individualTeam = await _teamDbService.GetTeam(team);
            return individualTeam != null
                ? View(individualTeam)
                : NotFound();
        }

        public async Task<ActionResult> Players_Read([DataSourceRequest] DataSourceRequest request, int id)
        {
            var year = "2023";
            string url = $"players?season={year}&team={id}";
            var players = await _webService.ObjectGetRequest<PlayerRoot>(url);
            if (players != null)
            {
                return Json(await players.Response.ToDataSourceResultAsync(request));
            }
            return Json(null);
        }
    }
}