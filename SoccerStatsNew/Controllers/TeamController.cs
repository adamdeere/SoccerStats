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

        public async Task<IActionResult> Display(string team)
        {
            string g = team.Trim();
            string[] split = g.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var individualTeam = await _teamDbService.GetTeam(split[0]);
            return individualTeam != null
                ? View(individualTeam)
                : NotFound();
        }

        public async Task<IActionResult> Index(int? league, string season)
        {
            TeamPageDisplay? team = null;
            if (league != null) 
            {
                team = await _seasonDbService.GetTeamsDisplayPage((int)league, season);
            }
            return team != null 
                ? View(team) 
                : NotFound();
        }
    }
}
