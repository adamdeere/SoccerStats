using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using SoccerStatsNew.DbServices;

namespace SoccerStatsNew.Controllers
{
    public class PlayerController : Controller
    {
        private readonly PlayerService _playerService;
        public PlayerController(PlayerService service)
        {
            _playerService = service;
        }
        public async Task<ActionResult> Index(int team)
        {
            var year = "2023";
            string url = $"players?season={year}&team={team}";
            var players = await _playerService.GetPlayers(team);
            
            return players != null 
                ? View(players) 
                : NotFound();
        }
        public async Task<ActionResult> Players_Read([DataSourceRequest] DataSourceRequest request, int id)
        {
            var year = "2023";
            string url = $"players?season={year}&team={id}";
            var players = await _playerService.GetPlayers(id);  
            if (players != null)
            {
                return Json(await players.Response.ToDataSourceResultAsync(request));
            }
            return Json(null);
        }
    }
}