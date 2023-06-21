using Microsoft.EntityFrameworkCore;
using PracticeApp.Models;

namespace PracticeApp.Data
{
    public class PracticeAppDbContext : DbContext
    {
        public PracticeAppDbContext(DbContextOptions<PracticeAppDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProductModel> ProductModel { get; set; } = default!;

        public DbSet<ItemModel> ItemModel { get; set; } = default!;

        public DbSet<LocationModel> LocationModel { get; set; } = default!;

        public DbSet<ReceiptModel> ReceiptModel { get; set; } = default!;

        public DbSet<ItemLocationModel> ItemLocationModel { get; set; } = default!;
    }
}