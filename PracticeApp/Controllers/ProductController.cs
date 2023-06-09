﻿using Microsoft.AspNetCore.Mvc;
using PracticeApp.HttpServices;
using PracticeApp.Models;
using PracticeApp.RequestModels;
using PracticeApp.Services;
using PracticeApp.Utils;

namespace PracticeApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly HttpService _httpService;

        public ProductController(ProductService service, HttpService httpservice)
        {
            _productService = service;
            _httpService = httpservice;
        }

        // GET: Product
        public async Task<IActionResult> Index(string sku)
        {
            string url = $"product";
            var product = await _httpService.GetObjectFromJson<ProductRoot>(url);

            if (product != null)
            {
                Console.WriteLine("success in the product controller");
                foreach (var item in product.List)
                {
                    Console.WriteLine($"Product Width is : {item.Width} && Sku is : {item.SKU}");
                }
            }
            else
            {
                Console.WriteLine("this has messed up somewhere in the product controller");
            }

            if (!string.IsNullOrEmpty(sku))
            {
                var searchProductList = await _productService.SearchForProducts(sku);
                return searchProductList != null ?
                            View(searchProductList) :
                            Problem("Entity set 'PracticeAppDbContext.ProductModel'  is null.");
            }

            var productList = await _productService.GetProducts();
            return productList != null ?
                        View(productList) :
                        Problem("Entity set 'PracticeAppDbContext.ProductModel'  is null.");

        }
        // GET: Product/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var productModel = await _productService.GetProductBySku(id);

                return id != null || productModel != null
                    ? View(productModel)
                    : NotFound();
            }
            return NotFound();
        }
        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SKUCode,Description,Length,Height,Width,Weight")] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                await _productService.CreateProductModel(productModel);
                return RedirectToAction(nameof(Index));
            }
            return View(productModel);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var product = await _productService.GetProductAsync(id);
                return product != null
                    ? View(product)
                    : NotFound();
            }
            return NotFound();
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SKUCode,Description,Length,Height,Width,Weight")] ProductModel productModel)
        {
            if (id != productModel.SKUCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _productService.EditProductModel(productModel);
                return RedirectToAction(nameof(Index));
                    
            }
            return View(productModel);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var product = await _productService.GetProductBySku(id);

                return product != null
                    ? View(product)
                    : NotFound();
            }
            return NotFound();
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (ControllerErrorChecker.CheckDbAndId(id, _productService.Context))
            {
                return Problem("Entity set 'PracticeAppDbContext.ProductModel'  is null.");
            }

            await _productService.ConfirmDelete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}