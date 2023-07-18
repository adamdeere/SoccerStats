using SoccerStatsData.RequestModels;
using SoccerStatsNew.Data;
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