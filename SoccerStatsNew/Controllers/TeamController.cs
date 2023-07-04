using Microsoft.AspNetCore.Mvc;
using SoccerStatsData;
using SoccerStatsNew.DbServices;
using SoccerStatsNew.Models;
using UtilityLibraries;

namespace SoccerStatsNew.Controllers
{
    public class TeamController : Controller
    {
       
        private readonly SeasonDbService _seasonDbService;
        public TeamController(SeasonDbService seasonDbService)
        {
            _seasonDbService = seasonDbService;
        }
        public async Task<IActionResult> Index(int? league)
        {
            TeamPageDisplay? team = null;
            if (league != null) 
            {
                team = await _seasonDbService.GetTeamsDisplayPage((int)league);
            }
            return team != null 
                ? View(team) 
                : NotFound();
        }
    }
}
