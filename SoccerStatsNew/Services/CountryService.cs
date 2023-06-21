using Microsoft.EntityFrameworkCore;
using SoccerStatsNew.Data;
using SoccerStatsNew.Models;

namespace SoccerStatsNew.Services
{
    public class CountryService
    {
        private readonly SoccerStatsDbContext _dbContext;

        public CountryService(SoccerStatsDbContext context)
        {
            _dbContext = context;
        }

        public async Task<ICollection<CountryModel>?> GetCountrys()
        {
            return _dbContext.CountryModel != null ?
                await _dbContext.CountryModel.ToListAsync()
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