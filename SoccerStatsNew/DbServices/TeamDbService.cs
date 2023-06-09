﻿using Microsoft.EntityFrameworkCore;
using SoccerStatsData;
using SoccerStatsNew.Data;
using UtilityLibraries;

namespace SoccerStatsNew.DbServices
{
    public class TeamDbService
    {
        private readonly SoccerStatsDbContext _dbContext;
        private readonly WebService _webService;

        public TeamDbService(SoccerStatsDbContext context, WebService service)
        {
            _dbContext = context;
            _webService = service;
        }

        public async Task SaveTeamsAndVenues(TeamRoot roo)
        {
            foreach (var item in roo.Response)
            {
                VenuesModel vMod = new()
                {
                    VenueId = (int)item.Venue.Id,
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
            if (_dbContext.TeamModel != null)
            {
                var teamModel = await _dbContext.TeamModel
                .FirstOrDefaultAsync(i => i.Name == team);

                await _dbContext.LeagueModel
                 .Join(_dbContext.TeamModel,
                 league => league.LeagueId,
                 team => team.LeagueId,
                 (league, team) => new
                 {
                     League = league,
                     Team = team
                 }).ToListAsync();

                await _dbContext.VenuesModel
                 .Join(_dbContext.TeamModel,
                 venue => venue.VenueId,
                 team => team.StadiumId,
                 (venue, team) => new
                 {
                     Venue = venue,
                     Team = team
                 }).ToListAsync();
                return teamModel ?? null;
            }
            return null;
        }

        public async Task<CountryModel?> GetCountry(string country)
        {
            if (_dbContext.CountryModel != null)
            {
                var countryModel = await _dbContext.CountryModel
                    .Where(id => id.Name == country)
                    .FirstOrDefaultAsync();

                return countryModel ?? null;
            }

            return null;
        }
    }
}