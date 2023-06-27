using Microsoft.EntityFrameworkCore;
using PracticeApp.Data;
using PracticeApp.Models;

namespace PracticeApp.Services
{
    public class ItemLocationService
    {
        public PracticeAppDbContext Context { get; }
        public DbSet<LocationModel> Locations { get; }

        public ItemLocationService(PracticeAppDbContext context)
        {
            Context = context;
            Locations = Context.LocationModel;
        }

        public async Task<ICollection<LocationModel>?> GetLocationModels(string id)
        {
            var location = await Context.LocationModel
                    .FirstOrDefaultAsync(m => m.LocationId == id);

            await Context.ItemLocationModel
                          .Join(Context.LocationModel,
                          item => item.LocationId,
                          location => location.LocationId,
                          (item, location) => new
                          {
                              Item = item
                          }).ToListAsync();

            return (ICollection<LocationModel>?)(location ?? null);
        }

        public async Task<ICollection<ItemLocationModel>?> GetItemLocationList()
        {
            return await Context.ItemLocationModel
                .Include(i => i.Item)
                .Include(i => i.Location)
                .Include(i => i.Receipt).ToListAsync() ?? null;
        }

        public async Task<ItemLocationModel?> GetItemLocationModel(int? id)
        {
            return await Context.ItemLocationModel
               .Include(i => i.Item)
               .Include(i => i.Location)
               .Include(i => i.Receipt)
               .FirstOrDefaultAsync(m => m.Id == id) ?? null;
        }

        public async Task CreateItemLocation(ItemLocationModel model)
        {
            Context.ItemLocationModel.Add(model);
            await Context.SaveChangesAsync();

            var item = await Context.ItemModel.
                FirstOrDefaultAsync(i => i.ItemNo == model.ItemNo);
            if (item != null)
            {
                item.LocationId = model.LocationId;
                Context.ItemModel.Update(item);
                await Context.SaveChangesAsync();
            }
            
        }

        public async Task<ItemLocationModel?> GetItemLocationAsync(int? id)
        {
            var itemLocation = await Context.ItemLocationModel
                .FirstOrDefaultAsync(i => i.ItemNo == id);

            await Context.ItemLocationModel
                .Join(Context.LocationModel,
                item => item.LocationId,
                location => location.LocationId,
                (item, location) => new { Item = item, Location = location })
                .FirstOrDefaultAsync();

            return itemLocation ?? null;
        }

        public async Task EditItemLocation(int id, ItemLocationModel itemLocationModel)
        {
            var itemLocation = await Context.ItemLocationModel
                        .FirstOrDefaultAsync(m => m.ItemNo == id);
            if (itemLocation != null)
            {
                try
                {
                    itemLocation.LocationId = itemLocationModel.LocationId;
                    itemLocation.GRN = itemLocationModel.GRN;

                    Context.ItemLocationModel.Update(itemLocation);
                    await Context.SaveChangesAsync();

                    var storedItem = await Context.ItemModel
                        .FirstOrDefaultAsync(m => m.ItemNo == itemLocation.ItemNo);
                    if (storedItem != null)
                    {
                        storedItem.GRN = itemLocationModel.GRN;
                        storedItem.LocationId = itemLocationModel.LocationId;
                        storedItem.Quantity = itemLocationModel.Quantity;
                        Context.ItemModel.Update(storedItem);
                        await Context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (ItemLocationModelExists(itemLocationModel.Id))
                    {
                        throw;
                    }
                }
            }
          
        }

        public async Task RemoveItemLocation(int id)
        {
            var itemLocationModel = await GetItemLocationAsync(id);

            if (itemLocationModel != null)
            {
                Context.ItemLocationModel.Remove(itemLocationModel);
                await Context.SaveChangesAsync();
             
            }
        }

        private bool ItemLocationModelExists(int id)
        {
            return (Context.ItemLocationModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public bool CheckMax(int QTY, float maxQTY)
        {
            return maxQTY > QTY;
        }
    }
}