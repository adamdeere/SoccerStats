using Microsoft.EntityFrameworkCore;
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

        private async Task JoinProductTable()
        {
            await Context.ItemModel
                .Join(Context.ProductModel,
                item => item.SKUCode,
                product => product.SKUCode,
                (item, product) => new { Item = item, Product = product })
                .ToListAsync();
        }

        public async Task<ICollection<ProductModel>?> GetProducts()
        {

            if (Context.ProductModel == null)
            {
                return null;
            }
            var products = await Context.ProductModel.ToListAsync();

            await JoinProductTable();
            
            return products ?? null;
        }

        public async Task<ICollection<ProductModel>?> SearchForProducts(string sku)
        {
            if (Context.ProductModel == null)
            {
                return null;
            }
           var list = await Context.ProductModel
                .Where(m => m.SKUCode.Contains(sku))
                .ToListAsync();

            await JoinProductTable();

            return list ?? null;
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

        public async Task ConfirmDelete(string id)
        {
            var productModel = await GetProductAsync(id);

            if (productModel != null)
            {
                Context.ProductModel.Remove(productModel);
                await Context.SaveChangesAsync();
            }
        }

        public async Task EditProductModel(ProductModel model)
        {
            try
            {
                Context.Update(model);
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (ProductModelExists(model.SKUCode))
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