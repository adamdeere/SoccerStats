using Microsoft.AspNetCore.Mvc;
using SoccerStatsNew.DbServices;

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
    }
}