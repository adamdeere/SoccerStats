using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoccerStatsData;
using SoccerStatsNew.Services;
using System.Diagnostics;
using UtilityLibraries;


namespace SoccerStatsNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly CountryDbService _countryService;  
        public HomeController(CountryDbService service)
        {
            _countryService = service;
        }

        public async Task<IActionResult> Index()
        {
            var countries = await _countryService.GetAllCountries();
            
            ViewData["CountryId"] = new SelectList(countries, "Name", "Name");
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