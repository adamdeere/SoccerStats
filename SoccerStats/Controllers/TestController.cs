using Microsoft.AspNetCore.Mvc;
using SoccerStats.Models;
using SoccerStats.Services;

namespace SoccerStats.Controllers
{
    public class TestController : Controller
    {
        private readonly ICountriesDBService _testservice;
        public TestController(ICountriesDBService testservice)
        {
            _testservice = testservice;   
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TestResult(CountryModel result)
        {
            return View();
        }
    }
}
