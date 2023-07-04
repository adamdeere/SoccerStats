using Microsoft.AspNetCore.Mvc;
using SoccerStatsData.RequestModels;
using SoccerStatsNew.Models;
using UtilityLibraries;

namespace SoccerStatsNew.Controllers
{
    public class FixtureController : Controller
    {
        public IActionResult Index()
        {
            var fixture = JsonHelper.GetObjectFromJsonFile<FixtureRoot>("Test/individualTeamFixtures.json");
            List<FixturePageData> list = new List<FixturePageData>();
            if (fixture != null)
            {
                foreach (var item in fixture.Response)
                {
                    FixturePageData page = new()
                    {
                        Date = item.Fixture.Date,
                        League = item.League.Name,
                        LeagueLogo = item.League.Flag,
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
    }
}
