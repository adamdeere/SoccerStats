﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PracticeApp.Models;
using PracticeApp.Services;
using PracticeApp.Utils;

namespace PracticeApp.Controllers
{
    public class ItemLocationController : Controller
    {
        private readonly ItemLocationService _itemLocationService;

        public ItemLocationController(ItemLocationService service)
        {
            _itemLocationService = service;
        }

        // GET: ItemLocation
        public async Task<IActionResult> Index()
        {
            var practiceAppDbContext = await _itemLocationService.GetItemLocationList();
            return practiceAppDbContext != null
                ? View(practiceAppDbContext)
                : NotFound();
        }

        // GET: ItemLocation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (ControllerErrorChecker.CheckDbAndIntId(id, _itemLocationService.Context.ItemLocationModel))
            {
                return NotFound();
            }

            var itemLocationModel = await _itemLocationService.GetItemLocationModel(id);

            return itemLocationModel != null
                ? View(itemLocationModel)
                : NotFound();
        }

        // GET: ItemLocation/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_itemLocationService.Locations, "LocationId", "LocationId");

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
            if (ModelState.IsValid)
            {
                _ = await _itemLocationService.CreateItemLocation(itemLocationModel);

                return RedirectToAction(nameof(Index));
            }

            ViewData["LocationId"] = new SelectList(_itemLocationService.Locations, "LocationId", "LocationId", itemLocationModel.LocationId);

            return View(itemLocationModel);
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
            if (ControllerErrorChecker.CheckDbAndIntId(id, _itemLocationService.Context.ItemLocationModel))
            {
                return NotFound();
            }

            var itemLocationModel = await _itemLocationService.GetItemLocationAsync(id);
            if (itemLocationModel == null)
            {
                return NotFound();
            }
            ViewData["ItemNo"] = new SelectList(_itemLocationService.Context.ItemModel, "ItemNo", "ItemNo", itemLocationModel.ItemNo);
            ViewData["LocationId"] = new SelectList(_itemLocationService.Locations, "LocationId", "LocationId", itemLocationModel.LocationId);
            ViewData["GRN"] = new SelectList(_itemLocationService.Context.ReceiptModel, "GRN", "GRN", itemLocationModel.GRN);
            return View(itemLocationModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LocationId,GRN,ItemNo,Quantity")] ItemLocationModel itemLocationModel)
        {
            if (id != itemLocationModel.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _ = await _itemLocationService.EditItemLocation(id, itemLocationModel);
            }

            ViewData["LocationId"] = new SelectList(_itemLocationService.Locations, "LocationId", "LocationId", itemLocationModel.LocationId);
            ViewData["GRN"] = new SelectList(_itemLocationService.Context.ReceiptModel, "GRN", "GRN", itemLocationModel.GRN);
            return View(itemLocationModel);
        }

        // GET: ItemLocation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (ControllerErrorChecker.CheckDbAndIntId(id, _itemLocationService.Context.ItemLocationModel))
            {
                return NotFound();
            }

            var itemLocationModel = await _itemLocationService.GetItemLocationModel(id);

            return itemLocationModel != null
                ? View(itemLocationModel)
                : NotFound();
        }

        // POST: ItemLocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (ControllerErrorChecker.CheckDb(_itemLocationService.Context.ItemLocationModel))
            {
                return Problem("Entity set 'PracticeAppDbContext.ItemLocationModel'  is null.");
            }

            _ = await _itemLocationService.RemoveItemLocation(id);

            return RedirectToAction(nameof(Index));
        }
    }
}