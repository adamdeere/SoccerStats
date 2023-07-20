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
        public async Task<ActionResult> Index(int team, string season)
        {
            var players = await _playerService.GetPlayers(team, season);
            
            return players != null 
                ? View(players) 
                : NotFound();
        }
    }
}