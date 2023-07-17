using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using SoccerStatsData.RequestModels.PredictionRequestFiles;
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
        [HttpPost]
        public IActionResult Fixtures(int leagueId)
        {

            return View(leagueId);
        }

        public IActionResult League_Fixtures([DataSourceRequest] DataSourceRequest request, int leagueId)
        {
            var fixture = _Service.GetFixtureData("");
           

            return Json(fixture.ToDataSourceResult(request));
        }
    }
}