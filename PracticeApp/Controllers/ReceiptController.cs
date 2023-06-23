using Microsoft.AspNetCore.Mvc;
using PracticeApp.Models;
using PracticeApp.Services;
using PracticeApp.Utils;

namespace PracticeApp.Controllers
{
    public class ReceiptController : Controller
    {
        private readonly ReceiptService _service;

        public ReceiptController(ReceiptService service)
        {
            _service = service;
          
        }

        // GET: Receipt
        public async Task<IActionResult> Index()
        {
            var modelList = await _service.GetReceipts();
            return modelList != null
                ? View(modelList)
                : Problem("Entity set 'PracticeAppDbContext.ReceiptModel'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (ControllerErrorChecker.CheckDbAndId(id, _service.Context.ReceiptModel))
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
                await _service.CreateReceipt(receiptModel);
                return RedirectToAction(nameof(Index));
            }
            return View(receiptModel);
        }

        // GET: Receipt/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return id != null 
                ? View(await _service.EditReceipt(id)) 
                : NotFound();
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