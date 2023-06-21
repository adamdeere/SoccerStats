using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerStatsNew.Data;
using SoccerStatsNew.RequestModels;

namespace SoccerStatsNew.Controllers
{
    public class LeagueController : Controller
    {
        private readonly SoccerStatsDbContext _context;

        public LeagueController(SoccerStatsDbContext context)
        {
            _context = context;
        }

        // GET: League
        public async Task<IActionResult> Index()
        {
            var soccerStatsDbContext = _context.LeagueModel.Include(l => l.Country);
            return View(await soccerStatsDbContext.ToListAsync());
        }

        // GET: League/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null || _context.LeagueModel == null)
            {
                return NotFound();
            }
           
            var leagueModel = await _context.LeagueModel
                .Where(m => m.CountryName == id).ToListAsync();

            await _context.LeagueModel
                .Join(_context.CountryModel,
                league => league.CountryName,
                country => country.Name,
                (league, country) => new 
                {
                    League = league,
                    Country = country
                }).ToListAsync();

            if (leagueModel == null)
            {
                return NotFound();
            }
            return View(leagueModel);
        }
    }
}