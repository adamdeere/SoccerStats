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
            char[] X = @"¿/˙'\‾¡zʎxʍʌnʇsɹbdouɯlʞɾıɥƃɟǝpɔqɐ".ToCharArray();
            string V = @"?\.,/_!zyxwvutsrqponmlkjihgfedcba";

            string InputString = "this will be rendered upside down";

            string lols = new string((from char obj in InputString.ToCharArray()
                                      select (V.IndexOf(obj) != -1) ? X[V.IndexOf(obj)] : obj).Reverse().ToArray());

            char[] Y = lols.ToCharArray();
            foreach (char c in Y)
            {
                Console.Write(c);
            }

            return View();
        }

        public IActionResult TestResult(CountryModel result)
        {
            return View();
        }
    }
}
