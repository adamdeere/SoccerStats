using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
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

        public async Task<IActionResult> Index(int team, string year)
        {
            var fixture = await _Service.GetTeamFixtures(team, year);
            return fixture != null
                ? View(fixture.Response)
                : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Fixtures(int leagueId)
        {
            var fixture = await _Service.GetLeagueFixtures(leagueId, "2023");

            return fixture != null
                ? View(fixture.Response)
                : NotFound();
        }
    }
}