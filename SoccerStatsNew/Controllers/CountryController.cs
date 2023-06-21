using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerStatsNew.Data;
using SoccerStatsNew.Services;

namespace SoccerStatsNew.Controllers
{
    public class CountryController : Controller
    {
        private readonly CountryService _countryService;

        public CountryController(CountryService service)
        {
            _countryService = service;
        }

        // GET: Country
        public async Task<IActionResult> Index()
        {
            var countries = await _countryService.GetCountrys();
            if (countries != null)
            {
                return View(countries);
            }
            return Problem("Entity set 'SoccerStatsDbContext.CountryModel'  is null.");
        }

        // GET: Country/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var details = await _countryService.GetCountryDetails(id);
            if (details != null)
            {
                return View(details);
            }
            return NotFound();
        }
    }
}