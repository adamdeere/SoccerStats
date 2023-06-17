using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SoccerStatsNew.Data;
using SoccerStatsNew.Models;
using SoccerStatsNew.RequestModels;

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
            using (StreamReader sr = new StreamReader("Test/leagues.json"))
            {
                string line = sr.ReadToEnd();

                LeagueRoot venues = JsonConvert.DeserializeObject<LeagueRoot>(line);
                foreach (var venue in venues.Response)
                {
                    try
                    {
                        if (!venue.Country.Code.IsNullOrEmpty())
                        {
                            for (int i = 0; i < venue.Seasons.Count; i++)
                            {
                                Guid id = Guid.NewGuid();
                                SeasonModel model = new SeasonModel
                                {
                                    SeasonId = id.ToString(),
                                    Id = venue.League.Id,
                                    CountryCode = venue.Country.Code,
                                    Year = venue.Seasons[i].Year,
                                    StartDate = venue.Seasons[i].Start,
                                    EndDate = venue.Seasons[i].End,
                                    Standings = venue.Seasons[i].Coverage.Standings,
                                    Players = venue.Seasons[i].Coverage.Players,

                                    TopScorers = venue.Seasons[i].Coverage.TopScorers,
                                    TopAssists = venue.Seasons[i].Coverage.TopAssists,
                                    TopCards = venue.Seasons[i].Coverage.TopCards,
                                    Injuries = venue.Seasons[i].Coverage.Injuries,
                                    Predictions = venue.Seasons[i].Coverage.Predictions,
                                    Odds = venue.Seasons[i].Coverage.Odds,
                                };
                                _context.SeasonModel.Add(model);
                                _context.SaveChanges();
                            }

                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }


            var soccerStatsDbContext = _context.SeasonModel.Include(s => s.Country).Include(s => s.League);
            return View(await soccerStatsDbContext.ToListAsync());
        }

        // GET: Season/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.SeasonModel == null)
            {
                return NotFound();
            }

            var seasonModel = await _context.SeasonModel
                .Include(s => s.Country)
                .Include(s => s.League)
                .FirstOrDefaultAsync(m => m.SeasonId == id);
            if (seasonModel == null)
            {
                return NotFound();
            }

            return View(seasonModel);
        }

        // GET: Season/Create
        public IActionResult Create()
        {
            ViewData["CountryCode"] = new SelectList(_context.CountryModel, "CountryCode", "CountryCode");
            ViewData["Id"] = new SelectList(_context.LeagueModel, "Id", "Id");
            return View();
        }

        // POST: Season/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SeasonId,Id,CountryCode,Year,StartDate,EndDate,Standings,Players,TopScorers,TopAssists,TopCards,Injuries,Predictions,Odds")] SeasonModel seasonModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seasonModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryCode"] = new SelectList(_context.CountryModel, "CountryCode", "CountryCode", seasonModel.CountryCode);
            ViewData["Id"] = new SelectList(_context.LeagueModel, "Id", "Id", seasonModel.Id);
            return View(seasonModel);
        }

        // GET: Season/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.SeasonModel == null)
            {
                return NotFound();
            }

            var seasonModel = await _context.SeasonModel.FindAsync(id);
            if (seasonModel == null)
            {
                return NotFound();
            }
            ViewData["CountryCode"] = new SelectList(_context.CountryModel, "CountryCode", "CountryCode", seasonModel.CountryCode);
            ViewData["Id"] = new SelectList(_context.LeagueModel, "Id", "Id", seasonModel.Id);
            return View(seasonModel);
        }

        // POST: Season/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SeasonId,Id,CountryCode,Year,StartDate,EndDate,Standings,Players,TopScorers,TopAssists,TopCards,Injuries,Predictions,Odds")] SeasonModel seasonModel)
        {
            if (id != seasonModel.SeasonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seasonModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeasonModelExists(seasonModel.SeasonId))
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
            ViewData["CountryCode"] = new SelectList(_context.CountryModel, "CountryCode", "CountryCode", seasonModel.CountryCode);
            ViewData["Id"] = new SelectList(_context.LeagueModel, "Id", "Id", seasonModel.Id);
            return View(seasonModel);
        }

        // GET: Season/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.SeasonModel == null)
            {
                return NotFound();
            }

            var seasonModel = await _context.SeasonModel
                .Include(s => s.Country)
                .Include(s => s.League)
                .FirstOrDefaultAsync(m => m.SeasonId == id);
            if (seasonModel == null)
            {
                return NotFound();
            }

            return View(seasonModel);
        }

        // POST: Season/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.SeasonModel == null)
            {
                return Problem("Entity set 'SoccerStatsDbContext.SeasonModel'  is null.");
            }
            var seasonModel = await _context.SeasonModel.FindAsync(id);
            if (seasonModel != null)
            {
                _context.SeasonModel.Remove(seasonModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeasonModelExists(string id)
        {
          return (_context.SeasonModel?.Any(e => e.SeasonId == id)).GetValueOrDefault();
        }
    }
}
