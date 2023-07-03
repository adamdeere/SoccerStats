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
        public async Task<ICollection<CountryModel>?> GetAllCountries()
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