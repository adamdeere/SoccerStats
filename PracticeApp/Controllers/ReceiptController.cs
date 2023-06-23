using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeApp.Data;
using PracticeApp.Models;
using PracticeApp.Services;
using PracticeApp.Utils;
using Rotativa.AspNetCore;

namespace PracticeApp.Controllers
{
    public class ReceiptController : Controller
    {
        private readonly PracticeAppDbContext _context;

        private readonly ReceiptService _service;

        public ReceiptController(ReceiptService service, PracticeAppDbContext context)
        {
            _service = service;
            _context = context;
        }

        // GET: Receipt
        public async Task<IActionResult> Index()
        {
            var modelList = await _service.GetReceipts();
            return modelList != null
                ? View(modelList)
                : Problem("Entity set 'PracticeAppDbContext.ReceiptModel'  is null.");
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
            if (ControllerErrorChecker.CheckDbAndIntId(id, _context.ReceiptModel))
            {
                return NotFound();
            }

            var receiptModel = await _service.GetReceiptDetails(id);

            return receiptModel != null
                ? View(receiptModel)
                : NotFound();
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
                // discard used intentionlly. see notes left above the service method
                _ = await _service.CreateReceipt(receiptModel);
                return RedirectToAction(nameof(Index));
            }
            return View(receiptModel);
        }

        // GET: Receipt/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return id != null ? View(await _service.EditReceipt(id)) : NotFound();
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
                var result = await _service.EditReceipt(receiptModel);

                return result != null
                    ? RedirectToAction(nameof(Index))
                    : NotFound();
            }
            return View(receiptModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            return id != null
                ? View(await _service.Delete(id))
                : NotFound();
        }

        // POST: Receipt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return await _service.DeleteConfirmed(id) != null
                ? RedirectToAction(nameof(Index))
                : Problem("Entity set 'PracticeAppDbContext.ReceiptModel'  is null.");
        }
    }
}