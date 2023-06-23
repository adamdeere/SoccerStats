using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PracticeApp.Models;
using PracticeApp.Services;
using PracticeApp.Utils;

namespace PracticeApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemService _service;
        public static string LastAddress { get; set; } = "";

        public ItemController(ItemService service)
        {
            _service = service;
        }

        // GET: Item
        public async Task<IActionResult> Index()
        {
            var practiceAppDbContext = await _service.GetItemModels();

            return practiceAppDbContext != null
                ? View(practiceAppDbContext)
                : NotFound();
        }

        // GET: Item/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return ControllerErrorChecker.CheckDbAndIntId(id, _service.Context.ItemModel) == false
                ? View(await _service.GetDetails(id))
                : NotFound();
        }

        // GET: Item/Create
        public IActionResult Create()
        {
            LastAddress = Request.Headers["Referer"].ToString();
            ViewData["SKUCode"] = new SelectList(_service.Context.ProductModel, "SKUCode", "SKUCode");
            ViewData["GRN"] = new SelectList(_service.Context.Set<ReceiptModel>(), "GRN", "GRN");
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
                _ = await _service.CreateItemModel(itemModel);
                return Redirect(LastAddress);
            }
            ViewData["SKUCode"] = new SelectList(_service.Context.ProductModel, "SKUCode", "SKUCode", itemModel.SKUCode);
            ViewData["GRN"] = new SelectList(_service.Context.Set<ReceiptModel>(), "GRN", "GRN", itemModel.GRN);

            return View(itemModel);
        }

        // GET: Item/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (ControllerErrorChecker.CheckDbAndIntId(id, _service.Context.ItemModel))
            {
                return NotFound();
            }
            var itemModel = await _service.FindItemAsync(id);
            if (itemModel != null)
            {
                ViewData["SKUCode"] = new SelectList(_service.Context.ProductModel, "SKUCode", "SKUCode", itemModel.SKUCode);
                ViewData["GRN"] = new SelectList(_service.Context.Set<ReceiptModel>(), "GRN", "GRN", itemModel.GRN);
                return View(itemModel);
            }
            return NotFound();
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
                return await _service.UpdateItemModel(itemModel) != null
                    ? RedirectToAction(nameof(Index))
                    : NotFound();
            }
            ViewData["SKUCode"] = new SelectList(_service.Context.ProductModel, "SKUCode", "SKUCode", itemModel.SKUCode);
            ViewData["GRN"] = new SelectList(_service.Context.Set<ReceiptModel>(), "GRN", "GRN", itemModel.GRN);
            return View(itemModel);
        }

        // GET: Item/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            LastAddress = RedirectBack();

            return ControllerErrorChecker.CheckDbAndIntId(id, _service.Context.ItemModel) == false
                ? View(await _service.GetItemModelAsync(id))
                : NotFound();
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (ControllerErrorChecker.CheckDb(_service.Context.ItemModel))
            {
                return Problem("Entity set 'PracticeAppDbContext.ItemModel'  is null.");
            }

            _ = await _service.ConfirmDelete(id);

            return Redirect(LastAddress);
        }

        private string RedirectBack()
        {
            return Request.Headers["Referer"].ToString();
        }
    }
}