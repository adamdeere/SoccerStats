using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using SoccerStatsData;
using SoccerStatsNew.Services;
using System.Diagnostics;

namespace SoccerStatsNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly LeagueDbService _leagueDbService;
        private readonly CountryDbService _countryService;

        public HomeController(CountryDbService service, LeagueDbService seasonDbService)
        {
            _leagueDbService = seasonDbService;
            _countryService = service;
        }

        public async Task<IActionResult> Index(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                var countries = await _countryService.GetAllCountriesToList();
                return countries != null
                       ? View(countries)
                       : NotFound();
            }
            var country = await _countryService.GetCountryDetails(code);
            
            return country != null 
                ? View(country) 
                : NotFound();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<JsonResult> ServerFiltering_Countries(string text)
        {
            var countries = await _countryService.GetCountrys(text);

            return countries != null
                ? Json(countries)
                : Json("");
        }
    }
}