using Microsoft.AspNetCore.Mvc;

namespace SoccerStatsNew.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
