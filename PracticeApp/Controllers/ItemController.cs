using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticeApp.Data;
using PracticeApp.Models;

namespace PracticeApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly PracticeAppDbContext _context;
        public static string LastAddress { get; set; } = "";

        public ItemController(PracticeAppDbContext context)
        {
            _context = context;
        }

        // GET: Item
        public async Task<IActionResult> Index()
        {
            var practiceAppDbContext = _context.ItemModel
                .Include(i => i.Product)
                .Include(i => i.Receipt)
                .OrderBy(m => m.Receipt);
            return View(await practiceAppDbContext.ToListAsync());
        }

        // GET: Item/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ItemModel == null)
            {
                return NotFound();
            }

            var itemModel = await _context.ItemModel
                .Include(i => i.Product)
                .Include(i => i.Receipt)
                .FirstOrDefaultAsync(m => m.ItemNo == id);
            if (itemModel == null)
            {
                return NotFound();
            }

            return View(itemModel);
        }

        // GET: Item/Create
        public IActionResult Create()
        {
            LastAddress = Request.Headers["Referer"].ToString();
            ViewData["SKUCode"] = new SelectList(_context.ProductModel, "SKUCode", "SKUCode");
            ViewData["GRN"] = new SelectList(_context.Set<ReceiptModel>(), "GRN", "GRN");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemNo,GRN,Quantity,SKUCode")] ItemModel itemModel, int? id)
        {
            if (ModelState.IsValid)
            {
                if (id != null)
                {
                    itemModel.GRN = (int)id;
                }
                _context.Add(itemModel);
                await _context.SaveChangesAsync();
                return Redirect(LastAddress);
            }
            ViewData["SKUCode"] = new SelectList(_context.ProductModel, "SKUCode", "SKUCode", itemModel.SKUCode);
            ViewData["GRN"] = new SelectList(_context.Set<ReceiptModel>(), "GRN", "GRN", itemModel.GRN);

            return View(itemModel);
        }

        // GET: Item/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ItemModel == null)
            {
                return NotFound();
            }

            var itemModel = await _context.ItemModel.FindAsync(id);
            if (itemModel == null)
            {
                return NotFound();
            }
            ViewData["SKUCode"] = new SelectList(_context.ProductModel, "SKUCode", "SKUCode", itemModel.SKUCode);
            ViewData["GRN"] = new SelectList(_context.Set<ReceiptModel>(), "GRN", "GRN", itemModel.GRN);
            return View(itemModel);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemNo,GRN,Quantity,SKUCode")] ItemModel itemModel)
        {
            if (id != itemModel.ItemNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemModelExists(itemModel.ItemNo))
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
            ViewData["SKUCode"] = new SelectList(_context.ProductModel, "SKUCode", "SKUCode", itemModel.SKUCode);
            ViewData["GRN"] = new SelectList(_context.Set<ReceiptModel>(), "GRN", "GRN", itemModel.GRN);
            return View(itemModel);
        }

        // GET: Item/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            LastAddress = RedirectBack();
            if (id == null || _context.ItemModel == null)
            {
                return NotFound();
            }

            var itemModel = await _context.ItemModel
                .Include(i => i.Product)
                .Include(i => i.Receipt)
                .FirstOrDefaultAsync(m => m.ItemNo == id);
            if (itemModel == null)
            {
                return NotFound();
            }

            return View(itemModel);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ItemModel == null)
            {
                return Problem("Entity set 'PracticeAppDbContext.ItemModel'  is null.");
            }
            var itemModel = await _context.ItemModel.FindAsync(id);
            if (itemModel != null)
            {
                _context.ItemModel.Remove(itemModel);
            }

            await _context.SaveChangesAsync();
            return Redirect(LastAddress);
        }

        private string RedirectBack()
        {
            return Request.Headers["Referer"].ToString();
        }
        private bool ItemModelExists(int id)
        {
            return (_context.ItemModel?.Any(e => e.ItemNo == id)).GetValueOrDefault();
        }
    }
}