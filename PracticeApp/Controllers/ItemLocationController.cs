using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticeApp.Data;
using PracticeApp.Models;

namespace PracticeApp.Controllers
{
    public class ItemLocationController : Controller
    {
        private readonly PracticeAppDbContext _context;

        public ItemLocationController(PracticeAppDbContext context)
        {
            _context = context;
        }

        private static string LastAddress { get; set; } = string.Empty;
        // GET: ItemLocation
        public async Task<IActionResult> Index()
        {
            var practiceAppDbContext = _context.ItemLocationModel.Include(i => i.Item).Include(i => i.Location).Include(i => i.Receipt);
            return View(await practiceAppDbContext.ToListAsync());
        }

        // GET: ItemLocation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ItemLocationModel == null)
            {
                return NotFound();
            }

            var itemLocationModel = await _context.ItemLocationModel
                .Include(i => i.Item)
                .Include(i => i.Location)
                .Include(i => i.Receipt)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemLocationModel == null)
            {
                return NotFound();
            }

            return View(itemLocationModel);
        }

        // GET: ItemLocation/Create
        public IActionResult Create()
        {
            LastAddress = RedirectBack();
            ViewData["LocationId"] = new SelectList(_context.LocationModel, "LocationId", "LocationId");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LocationId,GRN,ItemNo,Quantity")] ItemLocationModel itemLocationModel, int? item, int? grn)
        {
            if (item != null && grn != null)
            {
                itemLocationModel.GRN = (int)grn;
                itemLocationModel.ItemNo = (int)item;
            }
            LastAddress = RedirectBack();
            if (ModelState.IsValid)
            {
                // return a list of all LocationId
                var location = await _context.LocationModel
                    .FirstOrDefaultAsync(m => m.LocationId == itemLocationModel.LocationId);

                await _context.ItemLocationModel
                              .Join(_context.LocationModel,
                              item => item.LocationId,
                              location => location.LocationId,
                              (item, location) => new
                              {
                                  Item = item
                              }).ToListAsync();

                if (location != null && location.ItemLocations != null && location.ItemLocations.Count > 0)
                {
                    foreach (var items in location.ItemLocations)
                    {
                        if (items.ItemNo == itemLocationModel.ItemNo)
                        {
                            items.Quantity += itemLocationModel.Quantity;
                            _context.ItemLocationModel.Update(items);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                // if we get here theres nothing in the items list so add it to the DB
                else
                {
                    //if none found
                    _context.ItemLocationModel.Add(itemLocationModel);
                    UpdateItemModel(itemLocationModel.ItemNo, itemLocationModel.LocationId);
                    await _context.SaveChangesAsync();
                }
                return Redirect(LastAddress);
            }

            ViewData["LocationId"] = new SelectList(_context.LocationModel, "LocationId", "LocationId", itemLocationModel.LocationId);

            return View(itemLocationModel);
        }
        private bool CheckMax(int itemNo, float inputQTY)
        {
            var item =  _context.ItemModel
                .FirstOrDefault(m => m.ItemNo == itemNo);

            if (item != null)
            {
                return inputQTY > item.Quantity;
            }
          
            return false;
        }
        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckMaxQTY([Bind("Id,LocationId,GRN,ItemNo,Quantity")] ItemLocationModel itemLocationModel, int ItemNo)
        {
            if (itemLocationModel.Quantity <= 0)
            {
                return Json($"you cannot store {itemLocationModel.Quantity} items here!!");
            }
            return Json(true);
        }

        // GET: ItemLocation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ItemLocationModel == null)
            {
                return NotFound();
            }

            var itemLocationModel = await _context.ItemLocationModel.FindAsync(id);
            if (itemLocationModel == null)
            {
                return NotFound();
            }
            ViewData["ItemNo"] = new SelectList(_context.ItemModel, "ItemNo", "ItemNo", itemLocationModel.ItemNo);
            ViewData["LocationId"] = new SelectList(_context.LocationModel, "LocationId", "LocationId", itemLocationModel.LocationId);
            ViewData["GRN"] = new SelectList(_context.ReceiptModel, "GRN", "GRN", itemLocationModel.GRN);
            return View(itemLocationModel);
        }
        private async void UpdateItemModel(int id, string locationId)
        {
            var itemModel = await _context.ItemModel.FindAsync(id);
            if (itemModel != null)
            {
                itemModel.LocationId = locationId;
                itemModel.ItemNo = id;
                _context.ItemModel.Update(itemModel);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LocationId,GRN,ItemNo,Quantity")] ItemLocationModel itemLocationModel)
        {
            if (id != itemLocationModel.Id)
            {
                return NotFound();
            }

            var itemLocation = await _context.ItemLocationModel
                        .FirstOrDefaultAsync(m => m.Id == id);
            if (itemLocation == null)
            {
                return NotFound();
            }
           
            if (ModelState.IsValid)
            {
                try
                {
                    itemLocation.LocationId = itemLocationModel.LocationId;
                    itemLocation.GRN = itemLocationModel.GRN;

                    _context.Update(itemLocation);
                    await _context.SaveChangesAsync();

                    var itemModel = await _context.ItemModel.FindAsync(itemLocation.ItemNo);
                    if (itemModel != null)
                    {
                        itemModel.LocationId = itemLocationModel.LocationId;
                        itemModel.GRN = itemLocationModel.GRN;
                        _context.ItemModel.Update(itemModel);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemLocationModelExists(itemLocationModel.Id))
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
            ViewData["LocationId"] = new SelectList(_context.LocationModel, "LocationId", "LocationId", itemLocationModel.LocationId);
            ViewData["GRN"] = new SelectList(_context.ReceiptModel, "GRN", "GRN", itemLocationModel.GRN);
            return View(itemLocation);
        }

        // GET: ItemLocation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ItemLocationModel == null)
            {
                return NotFound();
            }

            var itemLocationModel = await _context.ItemLocationModel
                .Include(i => i.Item)
                .Include(i => i.Location)
                .Include(i => i.Receipt)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemLocationModel == null)
            {
                return NotFound();
            }

            return View(itemLocationModel);
        }

        // POST: ItemLocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ItemLocationModel == null)
            {
                return Problem("Entity set 'PracticeAppDbContext.ItemLocationModel'  is null.");
            }
            var itemLocationModel = await _context.ItemLocationModel.FindAsync(id);
            if (itemLocationModel != null)
            {
                _context.ItemLocationModel.Remove(itemLocationModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private string RedirectBack()
        {
            return Request.Headers["Referer"].ToString();
        }

        private bool ItemLocationModelExists(int id)
        {
            return (_context.ItemLocationModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}