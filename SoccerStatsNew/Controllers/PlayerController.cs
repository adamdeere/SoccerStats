using Microsoft.AspNetCore.Mvc;

namespace SoccerStatsNew.Controllers
{
    public class PlayerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
