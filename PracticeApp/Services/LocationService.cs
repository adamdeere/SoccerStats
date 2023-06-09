﻿using Microsoft.EntityFrameworkCore;
using PracticeApp.Data;
using PracticeApp.Models;

namespace PracticeApp.Services
{
    public class LocationService
    {
        public PracticeAppDbContext Context { get; }

        public LocationService(PracticeAppDbContext context)
        {
            Context = context;
        }
        private async Task JoinTables()
        {
            await Context.ItemLocationModel
            .Join(Context.LocationModel,
                  item => item.LocationId,
                  location => location.LocationId,
                  (item, location) => new { Item = item })
            .Join(Context.ItemModel,
                  item => item.Item.ItemNo,
                  location => location.ItemNo,
                  (item, location) => new { item.Item, Location = location })
            .Join(Context.ProductModel,
                  item => item.Item.Item.SKUCode,
                  product => product.SKUCode,
                  (item, product) => new { Item = item, Product = product })
            .Join(Context.ReceiptModel,
                  item => item.Item.Location.GRN,
                  receipt => receipt.GRN,
                  (item, receipt) => new { Item = item, Receipt = receipt })
            .ToListAsync();
        }
        public async Task<ICollection<LocationModel>?> GetLocationSearchList(string id)
        {
            if (Context.LocationModel == null)
            {
                return null;
            }

            var locations = await Context.LocationModel
                .Where(l=> l.LocationId.Contains(id))
                .ToListAsync();

            await JoinTables();

            return locations ?? null;


        }

        public async Task<ICollection<LocationModel>?> GetLocationList()
        {
            if (Context.LocationModel == null)
            {
                return null;
            }
            var locationModel = await Context.LocationModel
                .ToListAsync();

            await JoinTables();

            return locationModel ?? null;
        }

        public async Task<LocationModel?> GetLocation(string id)
        {
            return await Context.LocationModel
                .FirstOrDefaultAsync(m => m.LocationId == id) ?? null;
        }

        public async Task<LocationModel?> GetLocationAsync(string id)
        {
            return await Context.LocationModel
                .FindAsync(id) ?? null;
        }

        public async Task<ItemLocationModel?> GetItemLocation(int? id)
        {
            return await Context.ItemLocationModel
                .FindAsync(id) ?? null;
        }

        public async Task<ItemModel?> GetItemModel(int id)
        {
            return await Context.ItemModel
                        .FirstOrDefaultAsync(m => m.ItemNo == id) ?? null;
        }

        public async Task<LocationModel?> GetLocationDetails(string id)
        {
            var locationModel = await Context.LocationModel
                .FirstOrDefaultAsync(m => m.LocationId == id);

            await JoinTables();

            return locationModel ?? null;
        }

        public void Add(LocationModel model)
        {
            Context.Add(model);
        }

        public async Task CreateLocation(LocationModel locationModel)
        {
            Context.Add(locationModel);
            await Context.SaveChangesAsync();
        }

        public async Task EditLocation(string id, LocationModel locationModel)
        {
            try
            {
                Context.Update(locationModel);
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (LocationModelExists(locationModel.LocationId))
                {
                    throw;
                }
            }
        }

        public bool LocationModelExists(string id)
        {
            return (Context.LocationModel?.Any(e => e.LocationId == id)).GetValueOrDefault();
        }

        public async Task DeleteItem(int? id)
        {
            var itemLocationModel = await GetItemLocation(id);
            if (itemLocationModel != null)
            {
                Context.ItemLocationModel.Remove(itemLocationModel);
                await Context.SaveChangesAsync();
                var item = await GetItemModel(itemLocationModel.Id);
                // Not sure I need this any more as it was part of a failed idea
                if (item != null)
                {
                    item.LocationId = null;
                    Context.ItemModel.Update(item);
                    await Context.SaveChangesAsync();
                }
            }
        }

        public async Task ConfirmDelete(string id)
        {
            var locationModel = await GetLocationAsync(id);
            if (locationModel != null)
            {
                Context.LocationModel.Remove(locationModel);
                await Context.SaveChangesAsync();
            }
        }
    }
}