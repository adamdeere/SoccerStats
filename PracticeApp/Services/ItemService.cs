using Microsoft.EntityFrameworkCore;
using PracticeApp.Data;
using PracticeApp.Models;

namespace PracticeApp.Services
{
    public class ItemService
    {
        public PracticeAppDbContext Context { get; }

        public ItemService(PracticeAppDbContext context)
        {
            Context = context;
        }

        public async Task<ICollection<ItemModel>?> GetItemModels()
        {
            var itemList = await Context.ItemModel
                .Include(i => i.Product)
                .Include(i => i.Receipt)
                .OrderBy(m => m.Receipt).ToListAsync();

            return itemList ?? null;
        }

        public async Task<ItemModel?> GetItemModelAsync(int? id)
        {
            return await Context.ItemModel
             .Include(i => i.Product)
             .Include(i => i.Receipt)
             .FirstOrDefaultAsync(m => m.ItemNo == id) ?? null;
        }
        public async Task ConfirmDelete(int id)
        {
            var itemModel = await FindItemAsync(id);

            if (itemModel != null)
            {
                Context.ItemModel.Remove(itemModel);
                await Context.SaveChangesAsync();
            }
        }
        public async Task CreateItemModel(ItemModel itemModel)
        {
            Context.Add(itemModel);
            await Context.SaveChangesAsync();
        }

        public async Task<ItemModel?> GetDetails(int? id)
        {
            var itemModel = await Context.ItemModel
                .Include(i => i.Product)
                .Include(i => i.Receipt)
                .FirstOrDefaultAsync(m => m.ItemNo == id);

            return itemModel ?? null;
        }

        public async Task UpdateItemModel(ItemModel model)
        {
            try
            {
                Context.Update(model);
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (ItemModelExists(model.ItemNo))
                {
                    throw;
                }
            }
        }

        public void Remove(ItemModel model)
        {
            Context.ItemModel.Remove(model);
        }

        public async Task<ItemModel?> FindItemAsync(int? id)
        {
            return await Context.ItemModel.FindAsync(id) ?? null;
        }

        private bool ItemModelExists(int id)
        {
            return (Context.ItemModel?.Any(e => e.ItemNo == id)).GetValueOrDefault();
        }
    }
}