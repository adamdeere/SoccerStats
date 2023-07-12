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

        public async Task SaveSeasons()
        {
            var root = await _webService.GetObjectRequest<LeagueRoot>("leagues");
            if (root != null)
            {
                foreach (var item in root.Response)
                {
                    if (item.Country.Code != null)
                    {

                        foreach (var seasons in item.Seasons)
                        {
                            string g = Guid.NewGuid().ToString();

                            SeasonModel seasonDbModel = new SeasonModel()
                            {
                                SeasonId = Guid.NewGuid().ToString(),
                                LeagueId = item.League.Id,
                                CountryName = item.Country.Name,
                                Year = seasons.Year,
                                StartDate = seasons.Start,
                                EndDate = seasons.End,
                                Standings = seasons.Coverage.Standings,
                                Players = seasons.Coverage.Players,
                                TopScorers = seasons.Coverage.TopScorers,
                                TopAssists = seasons.Coverage.TopAssists,
                                TopCards = seasons.Coverage.TopCards,
                                Injuries = seasons.Coverage.Injuries,
                                Predictions = seasons.Coverage.Predictions,
                                Odds = seasons.Coverage.Odds,
                            };
                            _dbContext.SeasonModel.Add(seasonDbModel);
                            await _dbContext.SaveChangesAsync();
                        }
                    }
                }
            }
           
        }
        
        public async Task<TeamPageDisplay?> GetTeamsDisplayPage(int league, string season)
        {
            TeamPageDisplay? team = null;

            var seasons = await GetLeagueAvailableSeasons(league);

            if (seasons != null)
            {
                string year;
                if (string.IsNullOrEmpty(season))
                {
                    year = seasons.Last().Year.ToString();
                }
                else
                {
                    year = season;
                }
               
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
