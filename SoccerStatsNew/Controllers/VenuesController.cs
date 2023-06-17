using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SoccerStatsNew.Data;
using SoccerStatsNew.Models;
using SoccerStatsNew.RequestModels;

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
            using (StreamReader sr = new StreamReader("Test/venues.json"))
            {
                string line = sr.ReadToEnd();

                VenueRoot venues = JsonConvert.DeserializeObject<VenueRoot>(line);
                foreach (var venue in venues.response)
                {
                    VenuesModel model = new VenuesModel
                    {
                        StadiumId = venue.id,
                        Address = venue.address,
                        City = venue.city,
                        Capacity = venue.capacity,
                        Image = venue.image,
                        Country = venue.country,
                        Surface = venue.surface,

                    };
                    _context.VenuesModel.Add(model);
                    _context.SaveChanges();
                }
            }

              return _context.VenuesModel != null ? 
                          View(await _context.VenuesModel.ToListAsync()) :
                          Problem("Entity set 'SoccerStatsDbContext.VenuesModel'  is null.");
        }

        // GET: Venues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VenuesModel == null)
            {
                return NotFound();
            }

            var venuesModel = await _context.VenuesModel
                .FirstOrDefaultAsync(m => m.StadiumId == id);
            if (venuesModel == null)
            {
                return NotFound();
            }

            return View(venuesModel);
        }

        // GET: Venues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Venues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StadiumId,Address,City,Country,Capacity,Surface,Image")] VenuesModel venuesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venuesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venuesModel);
        }

        // GET: Venues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VenuesModel == null)
            {
                return NotFound();
            }

            var venuesModel = await _context.VenuesModel.FindAsync(id);
            if (venuesModel == null)
            {
                return NotFound();
            }
            return View(venuesModel);
        }

        // POST: Venues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StadiumId,Address,City,Country,Capacity,Surface,Image")] VenuesModel venuesModel)
        {
            if (id != venuesModel.StadiumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venuesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VenuesModelExists(venuesModel.StadiumId))
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
            return View(venuesModel);
        }

        // GET: Venues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VenuesModel == null)
            {
                return NotFound();
            }

            var venuesModel = await _context.VenuesModel
                .FirstOrDefaultAsync(m => m.StadiumId == id);
            if (venuesModel == null)
            {
                return NotFound();
            }

            return View(venuesModel);
        }

        // POST: Venues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VenuesModel == null)
            {
                return Problem("Entity set 'SoccerStatsDbContext.VenuesModel'  is null.");
            }
            var venuesModel = await _context.VenuesModel.FindAsync(id);
            if (venuesModel != null)
            {
                _context.VenuesModel.Remove(venuesModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VenuesModelExists(int id)
        {
          return (_context.VenuesModel?.Any(e => e.StadiumId == id)).GetValueOrDefault();
        }
    }
}
