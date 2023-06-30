using Microsoft.AspNetCore.Mvc;
using SoccerStatsNew.Models;
using SoccerStatsNew.RequestModels;
using SoccerStatsNew.Services;
using SoccerStatsNew.Utils;
using System.Diagnostics;

namespace SoccerStatsNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly TeamHttpService _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, TeamHttpService context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

          // await _context.GetTeams("?country=");

            //var teams = JsonConverterUtil.GetObjectFromJsonFile<TeamRoot>("Test/teams.json");
            //if (teams != null)
            //{
            //    await DbUtil.UpdateTeams(teams, _context._context);

            //    await DbUtil.UpdateVenues(teams, _context._context);
            //}


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