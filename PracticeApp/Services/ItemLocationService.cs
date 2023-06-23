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

        public async Task<LocationModel?> CreateItemLocation(ItemLocationModel model)
        {
            Context.ItemLocationModel.Add(model);
            await Context.SaveChangesAsync();

            return null;
        }

        public async Task<ItemLocationModel?> GetItemLocationAsync(int? id)
        {
            return await Context.ItemLocationModel.FindAsync(id) ?? null;
        }

        public async Task<ItemLocationModel?> EditItemLocation(int id, ItemLocationModel itemLocationModel)
        {
            var itemLocation = await Context.ItemLocationModel
                        .FirstOrDefaultAsync(m => m.Id == id);
            if (itemLocation == null)
            {
                return null;
            }
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
                    storedItem.GRN = itemLocation.GRN;
                    Context.ItemModel.Update(storedItem);
                    await Context.SaveChangesAsync();
                }
               

                return itemLocation;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemLocationModelExists(itemLocationModel.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<ItemLocationModel?> RemoveItemLocation(int id)
        {
            var itemLocationModel = await GetItemLocationAsync(id);

            if (itemLocationModel != null)
            {
                Context.ItemLocationModel.Remove(itemLocationModel);
                await Context.SaveChangesAsync();
                return itemLocationModel;
            }
            return null;
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