using Microsoft.AspNetCore.Mvc;

namespace SoccerStats.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Hello()
        {
            return "Hello human!";
        }
    }
}
