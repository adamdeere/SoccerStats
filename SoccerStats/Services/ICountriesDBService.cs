using SoccerStats.Models;

namespace SoccerStats.Services
{
    public interface ICountriesDBService
    {
        List<CountryModel> RetriveCountries(string connection, string proc);
       
    }
}
