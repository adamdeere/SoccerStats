﻿using Microsoft.EntityFrameworkCore;
using PracticeApp.Data;
using PracticeApp.Models;

namespace PracticeApp.Services
{
    public class ReceiptService
    {
        public PracticeAppDbContext Context { get; set; }

        public ReceiptService(PracticeAppDbContext context)
        {
            Context = context;
        }

        public async Task<ICollection<ReceiptModel>?> GetReceipts()
        {
            return Context.ReceiptModel != null
                ? await Context.ReceiptModel.ToListAsync()
                : null;
        }

        public async Task<ReceiptModel?> GetReceiptDetails(int? id)
        {
            var receiptModel = await Context.ReceiptModel
                .FirstOrDefaultAsync(m => m.GRN == id);

            await Context.ItemModel
               .Join(Context.ProductModel,
                     item => item.SKUCode,
                     product => product.SKUCode,
                     (item, product) => new
                     {
                         ProductModel = product,
                         Item = item
                     }).ToListAsync();
            if (receiptModel != null)
            {
                foreach (var item in receiptModel.ReceiptItems)
                {
                  
                    var itemLocation = await Context.ItemLocationModel
                        .Where(m => m.GRN == item.GRN)
                        .Where(m => m.ItemNo == item.ItemNo)
                        .FirstOrDefaultAsync();

                    await Context.LocationModel
                        .Join(Context.ItemLocationModel,
                     location => location.LocationId,
                     itemLocation => itemLocation.LocationId,
                     (location, itemLocation) => new
                     {
                         ItemLocation = itemLocation,
                         Location = location
                     }).ToListAsync();
                    if (itemLocation != null)
                    {
                        item.Location = itemLocation.Location;
                    }
                }
            }
            return receiptModel ?? null;
        }

        /// <summary>
        /// async void methods cannot be used inside services that contain
        /// a DB context as the dependancy injection manager disposes of the context
        /// before the thread is finished and thus throws an exception.
        /// This is why this method returns null and the result is discarded
        /// as the method needs to return something
        /// </summary>
        /// <param name="receiptModel"></param>
        /// <returns></returns>
        /// 

        public async void CreateReceiptModel(ReceiptModel receiptModel)
        {
            Context.Add(receiptModel);
            await Context.SaveChangesAsync();
        }
        public async Task<ReceiptModel?> CreateReceipt(ReceiptModel receiptModel)
        {
            Context.Add(receiptModel);
            await Context.SaveChangesAsync();
            return receiptModel ?? null;
        }

        public async Task<ReceiptModel?> EditReceipt(int? id)
        {
            return Context.ReceiptModel != null ?
                await Context.ReceiptModel.FindAsync(id)
                : null;
        }

        private bool ReceiptModelExists(int id)
        {
            return (Context.ReceiptModel?.Any(e => e.GRN == id)).GetValueOrDefault();
        }

        /// <summary>
        /// async void methods cannot be used inside services that contain
        /// a DB context as the dependancy injection manager disposes of the context
        /// before its finished. Hence the method is written like this
        /// </summary>
        /// <param name="receiptModel"></param>
        /// <returns></returns>
        public async Task<ReceiptModel?> EditReceipt(ReceiptModel receiptModel)
        {
            try
            {
                Context.Update(receiptModel);
                await Context.SaveChangesAsync();
               
                return receiptModel ?? null;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceiptModelExists(receiptModel.GRN))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<ReceiptModel?> Delete(int? id)
        {
            return Context.ReceiptModel != null ?
                await Context.ReceiptModel.FirstOrDefaultAsync(m => m.GRN == id) :
                null;
        }

        public async Task<ReceiptModel?> DeleteConfirmed(int id)
        {
            if (Context.ReceiptModel != null)
            {
                var receiptModel = await Context.ReceiptModel.FindAsync(id);
                if (receiptModel != null)
                {
                    Context.ReceiptModel.Remove(receiptModel);
                    await Context.SaveChangesAsync();

                    return receiptModel;
                }
            }
            return null;
        }
    }
}