using Microsoft.EntityFrameworkCore;
using SoccerStatsData;
using SoccerStatsNew.Data;
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
            var root = await _webService.ObjectGetRequest<LeagueRoot>("leagues");
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