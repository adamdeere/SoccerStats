using Microsoft.EntityFrameworkCore;
using SoccerStatsData;
using SoccerStatsNew.Data;


namespace SoccerStatsNew.Services
{
    public class LeagueDbService
    {
        private readonly SoccerStatsDbContext _context;

        public LeagueDbService(SoccerStatsDbContext context)
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

            foreach (var item in leagueModel)
            {
                item.Seasons = await _context.SeasonModel
                    .Where(s => s.LeagueId == item.LeagueId)
                    .OrderBy(x => x.Year)
                    .ToListAsync();
            }
            return leagueModel ?? null;
        }
    }
}