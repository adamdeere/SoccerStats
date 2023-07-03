using Microsoft.AspNetCore.Mvc;
using SoccerStatsNew.Services;

namespace SoccerStatsNew.Controllers
{
    public class LeagueController : Controller
    {
        private readonly LeagueDbService _leagueService;

        public LeagueController(LeagueDbService service)
        {
            _leagueService = service;
        }

        // GET: League
        public async Task<IActionResult> Index()
        {
            var league = await _leagueService.GetLeagues();
            if (league != null)
            {
                return View(league);
            }
            return NotFound();
        }

        // GET: League/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();

            var leagueModel = await _leagueService.GetLeagueDetails(id);

            return leagueModel != null 
                ? View(leagueModel) 
                : NotFound();
        }
    }
}