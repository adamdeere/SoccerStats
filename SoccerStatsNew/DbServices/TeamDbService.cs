using Microsoft.EntityFrameworkCore;
using SoccerStatsData;
using SoccerStatsNew.Data;

namespace SoccerStatsNew.DbServices
{
    public class TeamDbService
    {
        private readonly SoccerStatsDbContext _dbContext;
        public TeamDbService(SoccerStatsDbContext context)
        {
            _dbContext = context;
        }
        public async Task SaveTeamsAndVenues(TeamRoot roo)
        {
            foreach (var item in roo.Response)
            {
                VenuesModel vMod = new()
                {
                    VenueId = item.Venue.Id,
                    Name = item.Venue.Name,
                    Address = item.Venue.Address,
                    City = item.Venue.City,
                    Capacity = item.Venue.Capacity,
                    Surface = item.Venue.Surface,
                    Image = item.Venue.Image,
                    Country = item.Team.Country,
                };


                TeamModel vTeam = new()
                {
                    TeamId = item.Team.Id,
                    StadiumId = item.Venue.Id,
                    Name = item.Team.Name,
                    Code = item.Team.Code,
                    Country = item.Team.Country,
                    Founded = item.Team.Founded,
                    National = item.Team.National,
                    Logo = item.Team.Logo,
                };

                _dbContext.VenuesModel.Add(vMod);
                await _dbContext.SaveChangesAsync();
                _dbContext.TeamModel.Add(vTeam);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<TeamModel?> GetTeam(string team)
        {
            return _dbContext.TeamModel != null
                ? await _dbContext.TeamModel
                .FirstOrDefaultAsync(i => i.Name.Contains(team))
                : null;
        }
    }
}
