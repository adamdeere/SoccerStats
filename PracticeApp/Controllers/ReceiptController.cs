using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeApp.Data;
using PracticeApp.Models;
using Rotativa.AspNetCore;

namespace PracticeApp.Controllers
{
    public class ReceiptController : Controller
    {
        private readonly PracticeAppDbContext _context;

        public ReceiptController(PracticeAppDbContext context)
        {
            _context = context;
        }

        // GET: Receipt
        public async Task<IActionResult> Index()
        {
            var model = await _context.ReceiptModel.ToListAsync();
            if (model == null)
            {
                return Problem("Entity set 'PracticeAppDbContext.ReceiptModel'  is null.");
            }
            return View(model);
        }

        //Convert Index Page as PDF
        public async Task<IActionResult> Print(int? id)
        {
            if (id == null || _context.ReceiptModel == null)
            {
                return NotFound();
            }

            var receiptModel = await _context.ReceiptModel
                .FirstOrDefaultAsync(m => m.GRN == id);

            await _context.ItemModel
               .Join(_context.ProductModel,
                     item => item.SKUCode,
                     product => product.SKUCode,

                     (item, product) => new
                     {
                         ProductModel = product,
                         Item = item
                     }).ToListAsync();

            if (receiptModel == null)
            {
                return NotFound();
            }
            var report = new ViewAsPdf($"Details", receiptModel)
            {
                FileName = "File.pdf",
            };

            return report;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReceiptModel == null)
            {
                return NotFound();
            }

            var receiptModel = await _context.ReceiptModel
                .FirstOrDefaultAsync(m => m.GRN == id);

            await _context.ItemModel
               .Join(_context.ProductModel,
                     item => item.SKUCode,
                     product => product.SKUCode,
                     (item, product) => new
                     {
                         ProductModel = product,
                         Item = item
                     }).ToListAsync();

            if (receiptModel != null)
            {
                // retrives each individual location model from the db
                foreach (var item in receiptModel.ReceiptItems)
                {
                    if (item.LocationId != null)
                    {
                        var itemLocations = await _context.ItemLocationModel
                            .Where(m => m.ItemNo == item.ItemNo)
                            .ToListAsync();

                        item.Location = await _context.LocationModel
                            .FirstOrDefaultAsync(m => m.LocationId == item.LocationId);

                        if (item.Location != null)
                        {
                            item.Location.ItemLocations.Clear();
                            foreach (var locationItem in itemLocations)
                            {
                                item.Location.ItemLocations.Add(locationItem);
                                item.Quantity -= locationItem.Quantity;
                            }
                        }
                    }
                }
            }
            else
            {
               return NotFound();
            }
            return View(receiptModel);
        }

        // GET: Receipt/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GRN,Arrival,ExpectedArrival,TotalWeight,TotalCube")] ReceiptModel receiptModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receiptModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(receiptModel);
        }

        // GET: Receipt/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReceiptModel == null)
            {
                return NotFound();
            }

            var receiptModel = await _context.ReceiptModel.FindAsync(id);
            if (receiptModel == null)
            {
                return NotFound();
            }
            return View(receiptModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GRN,Arrival,ExpectedArrival,TotalWeight,TotalCube")] ReceiptModel receiptModel)
        {
            if (id != receiptModel.GRN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receiptModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceiptModelExists(receiptModel.GRN))
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
            return View(receiptModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReceiptModel == null)
            {
                return NotFound();
            }

            var receiptModel = await _context.ReceiptModel
                .FirstOrDefaultAsync(m => m.GRN == id);
            if (receiptModel == null)
            {
                return NotFound();
            }

            return View(receiptModel);
        }

        // POST: Receipt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReceiptModel == null)
            {
                return Problem("Entity set 'PracticeAppDbContext.ReceiptModel'  is null.");
            }
            var receiptModel = await _context.ReceiptModel.FindAsync(id);
            if (receiptModel != null)
            {
                _context.ReceiptModel.Remove(receiptModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceiptModelExists(int id)
        {
            return (_context.ReceiptModel?.Any(e => e.GRN == id)).GetValueOrDefault();
        }
    }
}