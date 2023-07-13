using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using SoccerStatsData.RequestModels;
using SoccerStatsData;
using SoccerStatsNew.DbServices;
using UtilityLibraries;
using Kendo.Mvc.Extensions;

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

        public async Task<ActionResult> Players_Read([DataSourceRequest] DataSourceRequest request, int league)
        {
            var teamId = 57;
            var year = "2023";
            string url = $"players?season={year}&team={teamId}";
            var players = await _webService.GetObjectRequest<PlayerRoot>(url);
            List<Player> list = new();
            if (players != null)
            {
                foreach (var player in players.Response) 
                {
                    list.Add(player.Player);
                }
               
            }
            return Json(await list.ToDataSourceResultAsync(request));
        }
    }
}