using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoccerStatsNew.Models;

namespace SoccerStatsNew.Data
{
    public class SoccerStatsDbContext : DbContext
    {
        public SoccerStatsDbContext (DbContextOptions<SoccerStatsDbContext> options)
            : base(options)
        {
        }

        public DbSet<SoccerStatsNew.Models.CountryModel> CountryModel { get; set; } = default!;

        public DbSet<SoccerStatsNew.Models.LeagueModel> LeagueModel { get; set; } = default!;
    }
}
