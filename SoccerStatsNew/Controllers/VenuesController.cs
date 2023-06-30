using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerStatsNew.Data;

namespace SoccerStatsNew.Controllers
{
    public class VenuesController : Controller
    {
        private readonly SoccerStatsDbContext _context;

        public VenuesController(SoccerStatsDbContext context)
        {
            _context = context;
        }

        // GET: Venues
        public async Task<IActionResult> Index()
        {
            var venues = await _context.VenuesModel.ToListAsync();
            if (venues == null)
            {
                return Problem("Entity set 'SoccerStatsDbContext.VenuesModel'  is null.");
            }
            return View(venues);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string city)
        {
            var venues = await _context.VenuesModel
                .Where(v => v.City.ToLower().Contains(city.ToLower()))
                .ToListAsync();

            return venues != null
                ? View(venues)
                : Problem("Entity set 'SoccerStatsDbContext.VenuesModel'  is null.");
        }

        // GET: Venues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VenuesModel == null)
            {
                return NotFound();
            }

            var venuesModel = await _context.VenuesModel
                .FirstOrDefaultAsync(m => m.VenueId == id);
            if (venuesModel == null)
            {
                return NotFound();
            }

            return View(venuesModel);
        }
    }
}