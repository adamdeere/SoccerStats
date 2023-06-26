﻿using Microsoft.EntityFrameworkCore;
using PracticeApp.Data;
using PracticeApp.Models;

namespace PracticeApp.Services
{
    public class ProductService
    {
        public PracticeAppDbContext Context { get; }

        public ProductService(PracticeAppDbContext context)
        {
            Context = context;
        }

        public async Task<ICollection<ProductModel>?> GetProducts()
        {

            if (Context.ProductModel == null)
            {
                return null;
            }
            var products = await Context.ProductModel.ToListAsync();

            foreach (var item in products)
            {
                item.Items = await Context.ItemModel
                    .Where(i => i.SKUCode == item.SKUCode)
                    .ToListAsync();
            }
            return Context.ProductModel != null
                ? await Context.ProductModel.ToListAsync()
                : null;
        }

        public async Task<ICollection<ProductModel>?> SearchForProducts(string sku)
        {
            return Context.ProductModel != null
                ? await Context.ProductModel
                .Where(m => m.SKUCode.Contains(sku))
                .ToListAsync()
                : null;
        }

        public async Task<ProductModel?> GetProductBySku(string id)
        {
            return Context.ProductModel != null
                ? await Context.ProductModel
                               .FirstOrDefaultAsync(m => m.SKUCode == id)
                : null;
        }

        public async Task<ProductModel?> GetProductAsync(string id)
        {
            return Context.ProductModel != null
                 ? await Context.ProductModel
                                .FindAsync(id)
                 : null;
        }

        public async Task<ProductModel?> ConfirmDelete(string id)
        {
            var productModel = await GetProductAsync(id);

            if (productModel != null)
            {
                Context.ProductModel.Remove(productModel);
                await Context.SaveChangesAsync();
            }
            return productModel ?? null;
        }

        public async Task<ProductModel?> EditProductModel(ProductModel model)
        {
            try
            {
                Context.Update(model);
                await Context.SaveChangesAsync();
                return model;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductModelExists(model.SKUCode))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task CreateProductModel(ProductModel model)
        {
            Context.ProductModel.Add(model);
            await Context.SaveChangesAsync();
          
        }

        private bool ProductModelExists(string id)
        {
            return (Context.ProductModel?
                .Any(e => e.SKUCode == id))
                .GetValueOrDefault();
        }
    }
}