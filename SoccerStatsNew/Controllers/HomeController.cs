using Microsoft.AspNetCore.Mvc;
using SoccerStatsData;
using SoccerStatsNew.Services;
using System.Diagnostics;
using UtilityLibraries;


namespace SoccerStatsNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebService _webService;
        private readonly CountryDbService _countryService;  
        public HomeController(WebService webService, CountryDbService service)
        {
            _webService = webService;
            _countryService = service;
        }

        public async Task<IActionResult> Index()
        {
            var countries = await _countryService.GetAllCountries();
            if (countries != null)
            {
                HomePageDisplay homePageDisplay = new HomePageDisplay()
                {
                    CountryList = (IEnumerable<CountryModel>)countries,
                };
                return View(homePageDisplay.CountryList);
            }
          
            return View(countries);
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