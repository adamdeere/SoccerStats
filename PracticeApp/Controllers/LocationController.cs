using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeApp.Data;
using PracticeApp.Models;

namespace PracticeApp.Controllers
{
    public class LocationController : Controller
    {
        private readonly PracticeAppDbContext _context;

        public LocationController(PracticeAppDbContext context)
        {
            _context = context;
        }

        // GET: Location
        public async Task<IActionResult> Index()
        {
            return _context.LocationModel != null ?
                        View(await _context.LocationModel.ToListAsync()) :
                        Problem("Entity set 'PracticeAppDbContext.LocationModel'  is null.");
        }

        // GET: Location/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.LocationModel == null)
            {
                return NotFound();
            }

            var locationModel = await _context.LocationModel
                .FirstOrDefaultAsync(m => m.LocationId == id);

            await _context.ItemLocationModel
             .Join(_context.LocationModel,
                   item => item.LocationId,
                   location => location.LocationId,
                   (item, location) => new
                   {
                       Item = item
                   })
             .Join(_context.ItemModel,
                   item => item.Item.ItemNo,
                   location => location.ItemNo,
                   (item, location) => new
                   {
                       item.Item,
                       Location = location
                   })
             .Join(_context.ProductModel,
             item => item.Item.Item.SKUCode,
             product => product.SKUCode,
             (item, product) => new { Item = item, Product = product })
             .ToListAsync();

            if (locationModel == null)
            {
                return NotFound();
            }

            return View(locationModel);
        }

        // GET: Location/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationId,Length,Height,Width")] LocationModel locationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locationModel);
        }

        // GET: Location/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.LocationModel == null)
            {
                return NotFound();
            }

            var locationModel = await _context.LocationModel.FindAsync(id);
            if (locationModel == null)
            {
                return NotFound();
            }
            return View(locationModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LocationId,Length,Height,Width")] LocationModel locationModel)
        {
            if (id != locationModel.LocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationModelExists(locationModel.LocationId))
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
            return View(locationModel);
        }

        // GET: Location/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteItem(int? id)
        {
            if (id != null)
            {
                var itemLocationModel = await _context.ItemLocationModel.FindAsync(id);
                if (itemLocationModel != null)
                {
                    _context.ItemLocationModel.Remove(itemLocationModel);
                    var item = await _context.ItemModel
                        .FirstOrDefaultAsync(m => m.ItemNo == itemLocationModel.ItemNo);
                    if (item != null)
                    {
                        item.LocationId = null;
                        _context.ItemModel.Update(item);
                    }
                   
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.LocationModel == null)
            {
                return NotFound();
            }

            var locationModel = await _context.LocationModel
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (locationModel == null)
            {
                return NotFound();
            }

            return View(locationModel);
        }

        // POST: Location/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.LocationModel == null)
            {
                return Problem("Entity set 'PracticeAppDbContext.LocationModel'  is null.");
            }
            var locationModel = await _context.LocationModel.FindAsync(id);
            if (locationModel != null)
            {
                _context.LocationModel.Remove(locationModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationModelExists(string id)
        {
            return (_context.LocationModel?.Any(e => e.LocationId == id)).GetValueOrDefault();
        }
    }
}