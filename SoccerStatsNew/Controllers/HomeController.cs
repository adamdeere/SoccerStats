using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoccerStatsData;
using SoccerStatsNew.DbServices;
using SoccerStatsNew.Services;
using System.Diagnostics;
using UtilityLibraries;


namespace SoccerStatsNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebService _webService;
        private readonly TeamDbService _countryService;  
        public HomeController(WebService webService, TeamDbService service)
        {
            _webService = webService;
            _countryService = service;
        }

        public async Task<IActionResult> Index()
        {
            //var countries = null;// await _countryService.GetAllCountries();
            using StreamReader sr = new("Test/teams.json");
            var teams = JsonHelper.GetObjectFromJson<TeamRoot>(sr.ReadToEnd());
            if (teams != null)
            {
               await _countryService.SaveTeamsAndVenues(teams);
            }
            return View();
            //return countries != null
            //    ? View(countries)
            //    : NotFound();
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