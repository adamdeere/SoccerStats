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
        public async Task<ActionResult> Index(int team, string season, int league)
        {
            var players = await _playerService.GetPlayers(team, season, league);
            
            return players != null 
                ? View(players) 
                : NotFound();
        }
    }
}