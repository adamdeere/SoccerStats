using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RazorPizza.Models;
using SoccerStats.Models;
using SoccerStats.Services;
using System.Data;
using System.Diagnostics;


namespace SoccerStats.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ICountriesDBService _testservice;
        public HomeController(IConfiguration config, ICountriesDBService testService)
        {
            _testservice = testService;
            _configuration = config;
        } 

        public IList<CountryModel>? Countries { get; set; }  

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {

            string connString = ConfigurationExtensions.GetConnectionString(_configuration, "DefaultConnection");
            List<CountryModel> orders = _testservice.RetriveCountries(connString, "RetriveCountries");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}