using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SoccerStatsNew.Data;
using SoccerStatsNew.Models;
using SoccerStatsNew.RequestModels;
using System.Diagnostics;

namespace SoccerStatsNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly SoccerStatsDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, SoccerStatsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
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