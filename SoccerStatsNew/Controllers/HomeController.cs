using Microsoft.AspNetCore.Mvc;
using SoccerStatsData;
using SoccerStatsNew.Models;
using SoccerStatsNew.Services;
using System.Diagnostics;


namespace SoccerStatsNew.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly CountryDbService _countryService;  
        public HomeController(CountryDbService service)
        {
           
            _countryService = service;
        }

        public async Task<IActionResult> Index(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                var countries = await _countryService.GetAllCountriesToList();
                if (countries != null)
                {
                    return View(countries);
                }
            }
            else
            {
                var country = await _countryService.GetCountryDetails(code);
                if (country != null)
                {
                    return View(country);
                }
            }
            return NotFound();
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
            
            return countries != null 
                ? Json(countries)
                : Json("");
        }

        

    }
}