using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerStatsNew.Data;

namespace SoccerStatsNew.Controllers
{
    public class SeasonController : Controller
    {
        private readonly SoccerStatsDbContext _context;

        public SeasonController(SoccerStatsDbContext context)
        {
            _context = context;
        }

        // GET: Season
        public async Task<IActionResult> Index()
        {
            //var soccerStatsDbContext = _context.SeasonModel.Include(s => s.Country).Include(s => s.League);
            return View();
        }

        // GET: Season/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.SeasonModel == null)
            {
                return NotFound();
            }

            var seasonModel = await _context.SeasonModel
                .FirstOrDefaultAsync(m => m.SeasonId == id);
            if (seasonModel == null)
            {
                return NotFound();
            }

            return View(seasonModel);
        }
    }
}