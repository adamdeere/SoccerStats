using Microsoft.AspNetCore.Mvc;
using PracticeApp.Models;
using System.Diagnostics;

namespace PracticeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            char[] X = @"¿/˙'\‾¡zʎxʍʌnʇsɹbdouɯlʞɾıɥƃɟǝpɔqɐ".ToCharArray();
            string V = @"?\.,/_!zyxwvutsrqponmlkjihgfedcba";

            string InputString = "this will be rendered upside down";

            string lols =  new string((from char obj in InputString.ToCharArray()
                               select (V.IndexOf(obj) != -1) ? X[V.IndexOf(obj)] : obj).Reverse().ToArray());

            char[] Y = lols.ToCharArray();
            foreach (char c in Y) 
            {
                Console.Write(c);
            }

            return View();
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