using Microsoft.AspNetCore.Mvc;
using SoccerStatsData;
using SoccerStatsNew.Models;
using SoccerStatsNew.Services;
using System.Diagnostics;
using UtilityLibraries;


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
            HomeDisplay home = new()
            {
                CountryList = countries
            };

            if (code != null)
            {
               home.LeagueList = await _leagueService.GetLeagueDetails(code);
            }

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
    }
}