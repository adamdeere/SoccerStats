using Microsoft.EntityFrameworkCore;
using SoccerStatsData;
using SoccerStatsNew.Data;
using SoccerStatsNew.Models;
using UtilityLibraries;

namespace SoccerStatsNew.DbServices
{
    public class SeasonDbService
    {
        private readonly SoccerStatsDbContext _dbContext;
        private readonly WebService _webService;
        public SeasonDbService(WebService webService, SoccerStatsDbContext context)
        {
            _webService = webService;
            _dbContext = context;   
        }

        public async Task<TeamPageDisplay?> GetTeamsDisplayPage(int league)
        {
            TeamPageDisplay? team = null;

            var seasons = await GetLeagueAvailableSeasons(league);

            if (seasons != null)
            {
                var year = seasons.Last().Year;
                string endPoint = $"teams?league={league}&season={year}";
                var teamResponse = await _webService.GetObjectRequest<TeamRoot>(endPoint);

                team = new()
                {
                    SeasonModelList = seasons,
                };
                if (teamResponse != null)
                {
                    foreach (var item in teamResponse.Response)
                    {
                        if (team != null)
                        {
                            if (team.TeamsModelList != null && team.VenueModelList != null)
                            {
                                team.TeamsModelList.Add(item.Team);
                                team.VenueModelList.Add(item.Venue);
                            }
                        }
                    }
                }
            }

            return team;
        }

        public async Task<ICollection<SeasonModel>?> GetLeagueAvailableSeasons(int id)
        {
            return _dbContext.SeasonModel != null
                ? await _dbContext.SeasonModel
                .Where(i => i.LeagueId == id)
                .OrderBy(i => i.Year)
                .ToListAsync() 
                : null;
        }

    }
}
