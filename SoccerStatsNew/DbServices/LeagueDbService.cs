using Microsoft.EntityFrameworkCore;
using SoccerStatsData;
using SoccerStatsNew.Data;


namespace SoccerStatsNew.Services
{
    public class LeagueDbService
    {
        private readonly SoccerStatsDbContext _context;
        public async Task SaveLeagueAndSeason(LeagueRoot root)
        {
            if (_context.LeagueModel != null && _context.SeasonModel != null)
            {
                foreach (var item in root.Response)
                {
                    if (item.Country.Code != null)
                    {
                        foreach (var seasons in item.Seasons)
                        {
                            string g = Guid.NewGuid().ToString();

                            SeasonModel seasonDbModel = new SeasonModel()
                            {
                                SeasonId = Guid.NewGuid().ToString(),
                                LeagueId = item.League.Id,
                                CountryName = item.Country.Name,
                                Year = seasons.Year,
                                StartDate = seasons.Start,
                                EndDate = seasons.End,
                                Standings = seasons.Coverage.Standings,
                                Players = seasons.Coverage.Players,
                                TopScorers = seasons.Coverage.TopScorers,
                                TopAssists = seasons.Coverage.TopAssists,
                                TopCards = seasons.Coverage.TopCards,
                                Injuries = seasons.Coverage.Injuries,
                                Predictions = seasons.Coverage.Predictions,
                                Odds = seasons.Coverage.Odds,
                            };
                            _dbContext.SeasonModel.Add(seasonDbModel);
                            await _dbContext.SaveChangesAsync();
                        }
                        LeagueModel model = new()
                        {
                            LeagueId = item.League.Id,
                            Name = item.League.Name,
                            Type = item.League.Type,
                            LogoURL = item.League.Logo,
                            CountryName = item.Country.Name,
                            CountryCode = item.Country.Code
                        };

                        _dbContext.LeagueModel.Add(model);
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }
        }

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