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

        // GET: Country/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountryCode,Name,FlagURL")] CountryModel countryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(countryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(countryModel);
        }

        // GET: Country/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.CountryModel == null)
            {
                return NotFound();
            }

            var countryModel = await _context.CountryModel.FindAsync(id);
            if (countryModel == null)
            {
                return NotFound();
            }
            return View(countryModel);
        }

        // POST: Country/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CountryCode,Name,FlagURL")] CountryModel countryModel)
        {
            if (id != countryModel.CountryCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(countryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryModelExists(countryModel.CountryCode))
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
            return View(countryModel);
        }

        // GET: Country/Delete/5
        public async Task<IActionResult> Delete(string id)
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

        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.CountryModel == null)
            {
                return Problem("Entity set 'SoccerStatsDbContext.CountryModel'  is null.");
            }
            var countryModel = await _context.CountryModel.FindAsync(id);
            if (countryModel != null)
            {
                _context.CountryModel.Remove(countryModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryModelExists(string id)
        {
            return (_context.CountryModel?.Any(e => e.CountryCode == id)).GetValueOrDefault();
        }
    }
}