using SoccerStatsData.RequestModels;
using SoccerStatsNew.Data;
using SoccerStatsNew.Models;
using UtilityLibraries;

namespace SoccerStatsNew.DbServices
{
    public class FixtureService
    {
        private readonly WebService _WebService;
        private readonly SoccerStatsDbContext _dbContext;

        public FixtureService(WebService service, SoccerStatsDbContext context)
        {
            _WebService = service;
            _dbContext = context;
        }

        public IEnumerable<FixturePageData> GetFixtureData(string id)
        {
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

        public async Task<FixtureRoot?> GetTeamFixtures(int leagueId, string year)
        {
            year = "2023";
            var url = $"fixtures?team={leagueId}&season={year}";

            var fixtures = await _WebService.GetObjectRequest<FixtureRoot>(url);

            return fixtures ?? null;
        }

        public async Task<FixtureRoot?> GetLeagueFixtures(int leagueId, string year)
        {
            var url = $"fixtures?league={leagueId}&season={year}";

            var fixtures = await _WebService.GetObjectRequest<FixtureRoot>(url);

            return fixtures ?? null;
        }
    }
}