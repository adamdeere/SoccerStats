using Microsoft.EntityFrameworkCore;
using Nest;
using SoccerStatsNew.Data;
using SoccerStatsNew.Models;
using SoccerStatsNew.RequestModels;
using System.Diagnostics.Metrics;

namespace SoccerStatsNew.Utils
{
    public static class DbUtil
    {
        public static bool IsDBNull(object obj)
        {
            return obj == null;
        }
        public static async Task UpdateCountries(CountryRoot country, SoccerStatsDbContext _context)
        {
            foreach (var item in country.Response)
            {
                CountryModel model = new()
                {
                    Name = item.Name,
                    CountryCode = item.Code,
                    FlagURL = item.Flag
                };
                _context.CountryModel.Add(model);
                await _context.SaveChangesAsync();
            }
        }

        public static async Task UpdateVenues(TeamRoot venues, SoccerStatsDbContext _context)
        {
            foreach(var item in venues.Response)
            {
                if (item.Venue.Id != null)
                {
                    VenuesModel venueModel = new()
                    {
                        VenueId = (int)item.Venue.Id,
                        Name = item.Venue.Name,
                        Address = item.Venue.Address,
                        City = item.Venue.City,
                        Country = item.Team.Country,
                        Capacity = (int)item.Venue.Capacity,
                        Surface = item.Venue.Surface,
                        Image = item.Venue.Image,
                    };

                    var existingVenue = await _context.VenuesModel
                        .FirstOrDefaultAsync(x => x.VenueId == venueModel.VenueId);    
                    if (existingVenue == null) 
                    {
                        _context.VenuesModel.Add(venueModel);
                        await _context.SaveChangesAsync();
                    }
                   

                }
            }
        
           
        }
        public static async Task UpdateTeams(TeamRoot teams, SoccerStatsDbContext _context)
        {
            foreach(var item in teams.Response) 
            {
                TeamModel model = new()
                {
                    TeamId = (int)item.Team.Id,
                    StadiumId = item.Venue.Id,
                    Name = item.Team.Name,
                    Code = item.Team.Code,
                    Country = item.Team.Country,
                    Founded = item.Team.Founded,
                    National = item.Team.National,
                    Logo = item.Team.Logo,
                };
               
              
                _context.TeamModel.Add(model);
                await _context.SaveChangesAsync();
            }
        }
    
        public static async Task UpdateLeagues(LeagueRoot leagues, SoccerStatsDbContext _context)
        {
            foreach (var item in leagues.Response)
            {
                LeagueModel model = new()
                {
                    LeagueId = item.League.Id,
                    Name = item.League.Name,
                    Type = item.League.Type,
                    LogoURL = item.League.Logo,
                    CountryName = item.Country.Name,
                };
                _context.LeagueModel.Add(model);
                await _context.SaveChangesAsync();
                foreach (var season in item.Seasons)
                {
                    SeasonModel sModel = new() 
                    {
                        SeasonId = Guid.NewGuid().ToString(),
                        LeagueId = model.LeagueId,
                        CountryName = model.CountryName,
                        Year = season.Year, 
                        StartDate = season.Start,
                        EndDate = season.End,
                        Standings = season.Coverage.Standings,
                        Players = season.Coverage.Players,
                        TopScorers = season.Coverage.TopScorers,
                        TopAssists = season.Coverage.TopAssists,
                        TopCards = season.Coverage.TopCards,
                        Injuries = season.Coverage.Injuries,
                        Predictions = season.Coverage.Predictions,
                        Odds = season.Coverage.Odds,
                };
                    _context.SeasonModel.Add(sModel);
                    await _context.SaveChangesAsync();
                }
               
            }
        }


    }
}