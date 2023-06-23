using Microsoft.EntityFrameworkCore;
using SoccerStatsNew.Data;
using SoccerStatsNew.Models;

namespace SoccerStatsNew.Services
{
    public class LeagueService
    {
        private readonly SoccerStatsDbContext _context;

        public LeagueService(SoccerStatsDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<LeagueModel>?> GetLeagues()
        {
            var soccerStatsDbContext = _context.LeagueModel.Include(l => l.Country);
            return soccerStatsDbContext != null ?
                  await soccerStatsDbContext.ToListAsync()
            : null;
        }

        public async Task<ICollection<LeagueModel>?> GetLeagueDetails(string id)
        {
            var leagueModel = await _context.LeagueModel
                 .Where(m => m.CountryName == id).ToListAsync();

            await _context.LeagueModel
                .Join(_context.CountryModel,
                league => league.CountryName,
                country => country.Name,
                (league, country) => new
                {
                    League = league,
                    Country = country
                }).ToListAsync();

            return leagueModel ?? null;
        }
    }
}