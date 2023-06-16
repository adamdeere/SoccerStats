using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoccerStatsNew.Data;
using SoccerStatsNew.Models;

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
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LeagueModel == null)
            {
                return NotFound();
            }

            var leagueModel = await _context.LeagueModel
                .Include(l => l.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leagueModel == null)
            {
                return NotFound();
            }

            return View(leagueModel);
        }

        // GET: League/Create
        public IActionResult Create()
        {
            ViewData["CountryCode"] = new SelectList(_context.CountryModel, "CountryCode", "CountryCode");
            return View();
        }

        // POST: League/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,LogoURL,CountryCode")] LeagueModel leagueModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leagueModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryCode"] = new SelectList(_context.CountryModel, "CountryCode", "CountryCode", leagueModel.CountryCode);
            return View(leagueModel);
        }

        // GET: League/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LeagueModel == null)
            {
                return NotFound();
            }

            var leagueModel = await _context.LeagueModel.FindAsync(id);
            if (leagueModel == null)
            {
                return NotFound();
            }
            ViewData["CountryCode"] = new SelectList(_context.CountryModel, "CountryCode", "CountryCode", leagueModel.CountryCode);
            return View(leagueModel);
        }

        // POST: League/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,LogoURL,CountryCode")] LeagueModel leagueModel)
        {
            if (id != leagueModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leagueModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeagueModelExists(leagueModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryCode"] = new SelectList(_context.CountryModel, "CountryCode", "CountryCode", leagueModel.CountryCode);
            return View(leagueModel);
        }

        // GET: League/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LeagueModel == null)
            {
                return NotFound();
            }

            var leagueModel = await _context.LeagueModel
                .Include(l => l.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leagueModel == null)
            {
                return NotFound();
            }

            return View(leagueModel);
        }

        // POST: League/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LeagueModel == null)
            {
                return Problem("Entity set 'SoccerStatsDbContext.LeagueModel'  is null.");
            }
            var leagueModel = await _context.LeagueModel.FindAsync(id);
            if (leagueModel != null)
            {
                _context.LeagueModel.Remove(leagueModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeagueModelExists(int id)
        {
          return (_context.LeagueModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
