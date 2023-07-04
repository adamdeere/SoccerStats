using Microsoft.AspNetCore.Mvc;
using SoccerStatsNew.DbServices;
using SoccerStatsNew.Models;

namespace SoccerStatsNew.Controllers
{
    public class TeamController : Controller
    {
       
        private readonly SeasonDbService _seasonDbService;
        public TeamController(SeasonDbService seasonDbService)
        {
            _seasonDbService = seasonDbService;
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
