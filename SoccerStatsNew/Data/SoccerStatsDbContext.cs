using Microsoft.EntityFrameworkCore;
using SoccerStatsNew.Models;

namespace SoccerStatsNew.Data
{
    public class SoccerStatsDbContext : DbContext
    {
        public SoccerStatsDbContext(DbContextOptions<SoccerStatsDbContext> options)
            : base(options)
        {
        }

        public DbSet<CountryModel> CountryModel { get; set; } = default!;

        public DbSet<LeagueModel> LeagueModel { get; set; } = default!;

        public DbSet<VenuesModel> VenuesModel { get; set; } = default!;

        public DbSet<SeasonModel> SeasonModel { get; set; } = default!;

        public DbSet<TeamModel> TeamModel { get; set; } = default!;
    }
}