using Microsoft.AspNetCore.Mvc;

namespace SoccerStats.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Pizza()
        {
            return View();
        }
    }
}
