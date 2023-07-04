using Microsoft.EntityFrameworkCore;
using SoccerStatsData;
using SoccerStatsNew.Data;

namespace SoccerStatsNew.Services
{
    public class CountryDbService
    {
        private readonly SoccerStatsDbContext _dbContext;

        public CountryDbService(SoccerStatsDbContext context)
        {
            _dbContext = context;
        }

        public async Task SaveLeagueAndSeason(LeagueRoot root)
        {
            if (_dbContext.LeagueModel != null && _dbContext.SeasonModel != null)
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

        public async Task SaveCountries(ICollection<CountryHttpResponse> countries)
        {
            if (_dbContext.CountryModel != null)
            {
                foreach (var country in countries)
                {
                    if (country.Code != null)
                    {
                        CountryModel countryModel = new CountryModel()
                        {
                            Name = country.Name,
                            CountryCode = country.Code,
                            FlagURL = country.Flag
                        };

                       _dbContext.CountryModel.Add(countryModel);
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }
            
        }
        public async Task<ICollection<CountryModel>?> GetAllCountriesToList()
        {
            return _dbContext.CountryModel != null 
                ? await _dbContext.CountryModel.ToListAsync() 
                : null;
        }

        public async Task<ICollection<CountryModel>?> GetCountrys(string id)
        {
            return _dbContext.CountryModel != null ?
                await _dbContext.CountryModel
                .Where(c => c.Name.StartsWith(id))
                .ToListAsync()
                : null;
        }

        public async Task<CountryModel?> GetCountryDetails(string id)
        {
            return _dbContext.CountryModel != null ?
                await _dbContext.CountryModel
                      .FirstOrDefaultAsync(m => m.CountryCode == id)
               : null;
        }
    }
}