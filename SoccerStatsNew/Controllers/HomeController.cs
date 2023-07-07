using Microsoft.AspNetCore.Mvc;
using SoccerStatsData;
using SoccerStatsNew.Models;
using SoccerStatsNew.Services;
using System.Diagnostics;


namespace SoccerStatsNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly LeagueDbService _leagueService;
        private readonly CountryDbService _countryService;  
        public HomeController(LeagueDbService webService, CountryDbService service)
        {
            _leagueService = webService;
            _countryService = service;
        }

        public async Task<IActionResult> Index(string code)
        {
            
            var countries = await _countryService.GetAllCountriesToList();

            return countries != null
                ? View(countries)
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

        public async Task<JsonResult> ServerFiltering_GetProducts(string text)
        {
            var countries = await _countryService.GetCountrys(text);

            return Json(countries);
        }
    }
}