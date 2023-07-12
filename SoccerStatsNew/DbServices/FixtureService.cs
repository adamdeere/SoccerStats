using SoccerStatsData.RequestModels;
using SoccerStatsNew.Models;
using UtilityLibraries;

namespace SoccerStatsNew.DbServices
{
    public class FixtureService
    {
        private readonly WebService _WebService;

        public FixtureService(WebService service)
        {
            _WebService = service;
        }

        public IEnumerable<FixturePageData> GetFixtureData(string id)
        {
            Console.WriteLine(id);
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
            return list;
        }
    }
}