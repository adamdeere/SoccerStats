using Microsoft.AspNetCore.Mvc;
using SoccerStatsData.RequestModels;
using SoccerStatsData.RequestModels.PredictionRequestFiles;
using SoccerStatsNew.Models;
using UtilityLibraries;


namespace SoccerStatsNew.Controllers
{
    public class FixtureController : Controller
    {
        private readonly WebService _Service;

        public FixtureController(WebService service)
        {
                _Service = service;
        }
        public async Task<IActionResult> Index()
        {
            string urlParams = "predictions?fixture=881252";

            var predictions = await _Service.GetObjectRequest<PredictionRoot>(urlParams);

            var fixture = JsonHelper.GetObjectFromJsonFile<FixtureRoot>("Test/individualTeamFixtures.json");
            List<FixturePageData> list = new();
            if (fixture != null)
            {
                foreach (var item in fixture.Response)
                {
                    FixturePageData page = new()
                    {
                        Date = item.Fixture.Date,
                        FixtureId = item.Fixture.Id,
                        League = item.League.Name,
                        LeagueLogo = item.League.Logo,
                        HomeTeam = item.Teams.Home.Name,
                        HomeTeamLogo = item.Teams.Home.Logo,
                        AwayTeam = item.Teams.Away.Name,
                        AwayTeamLogo = item.Teams.Away.Logo,
                    };
                    list.Add(page);
                }
            }
            return fixture != null 
                ? View(list) 
                : NotFound();

           
        }

        public IActionResult Details(int? fixture)
        { 
            return View();
        }
    }
}
