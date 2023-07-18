using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using SoccerStatsData;
using SoccerStatsData.RequestModels;
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

        public async Task<IActionResult> Index(int team, string year)
        {
            var fixture = await _Service.GetTeamFixtures(50, year); 
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

        public IActionResult League_Fixtures([DataSourceRequest] DataSourceRequest request, int leagueId)
        {
            var fixture = _Service.GetFixtureData("");
           

            return Json(fixture.ToDataSourceResult(request));
        }
    }
}