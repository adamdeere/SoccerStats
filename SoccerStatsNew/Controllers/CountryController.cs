using Microsoft.AspNetCore.Mvc;
using SoccerStatsNew.Services;

namespace SoccerStatsNew.Controllers
{
    public class CountryController : Controller
    {
        private readonly CountryDbService _countryService;

        public CountryController(CountryDbService service)
        {
            _countryService = service;
        }

        // GET: Country
        public async Task<IActionResult> Index(string id)
        {
            if (string.IsNullOrEmpty(id)) 
            {
                id = "A";
            }
            var countries = await _countryService.GetCountrys(id);

            return countries != null 
                ? View(countries) 
                : Problem("Entity set 'SoccerStatsDbContext.CountryModel'  is null.");
        }

        // GET: Country/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();

            var details = await _countryService.GetCountryDetails(id);
            if (details != null)
            {
                return View(details);
            }
            return NotFound();
        }
    }
}