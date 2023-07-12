using Microsoft.AspNetCore.Mvc;
using SoccerStatsData.RequestModels;
using SoccerStatsData.RequestModels.PredictionRequestFiles;
using SoccerStatsNew.DbServices;
using SoccerStatsNew.Models;
using UtilityLibraries;


namespace SoccerStatsNew.Controllers
{
    public class FixtureController : Controller
    {
        private readonly FixtureService _Service;

        public FixtureController(FixtureService service)
        {
           _Service = service;
        }
        public IActionResult Index(string team)
        {
            var fixture = _Service.GetFixtureData(team);
            return fixture != null 
                ? View(fixture) 
                : NotFound();
        }

        public IActionResult Details(int? fixture)
        { 
            return View();
        }
    }
}
