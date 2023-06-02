using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoccerStats.Models;

namespace SoccerStats.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<CountryModel>? Countries { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}