using Microsoft.AspNetCore.Mvc;
using SoccerStatsNew.DbServices;
using SoccerStatsNew.Models;

namespace SoccerStatsNew.Controllers
{
    public class TeamController : Controller
    {
       
        private readonly SeasonDbService _seasonDbService;
        private readonly TeamDbService _teamDbService;
        public TeamController(SeasonDbService seasonDbService, TeamDbService service)
        {
            _teamDbService = service;
            _seasonDbService = seasonDbService;
        }

        public async Task<IActionResult> Index(string team)
        {
            
            var individualTeam = await _teamDbService.GetTeam(team);
            return individualTeam != null
                ? View(individualTeam)
                : NotFound();
        }
    }
}
