using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerStatsNew.Data;
using SoccerStatsNew.Models;

namespace SoccerStatsNew.Controllers
{
    public class CountryController : Controller
    {
        private readonly SoccerStatsDbContext _context;

        public CountryController(SoccerStatsDbContext context)
        {
            _context = context;
        }

        // GET: Country
        public async Task<IActionResult> Index()
        {
            return _context.CountryModel != null ?
                        View(await _context.CountryModel.ToListAsync()) :
                        Problem("Entity set 'SoccerStatsDbContext.CountryModel'  is null.");
        }

        // GET: Country/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.CountryModel == null)
            {
                return NotFound();
            }

            var countryModel = await _context.CountryModel
                .FirstOrDefaultAsync(m => m.CountryCode == id);
            if (countryModel == null)
            {
                return NotFound();
            }

            return View(countryModel);
        }
    }
}