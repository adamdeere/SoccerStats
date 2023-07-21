using Microsoft.EntityFrameworkCore;
using SoccerStatsData;
using SoccerStatsData.DtoModels;
using SoccerStatsNew.Data;
using SoccerStatsNew.DbServices;
using SoccerStatsNew.Models;
using UtilityLibraries;

namespace SoccerStatsNew.Services
{
    public class LeagueDbService
    {
        private readonly SoccerStatsDbContext _dbContext;
        private readonly SeasonDbService _seasonService;
        private readonly WebService _webService;

        public async Task<LeagueDataDto?> ConstructLeagueData(int leagueId, string year)
        {
            
            if (_dbContext != null)
            {
                var league = await _dbContext.LeagueModel
                   .FirstOrDefaultAsync(id => id.LeagueId == leagueId);

                await _dbContext.LeagueModel
                .Join(_dbContext.CountryModel,
                league => league.CountryName,
                country => country.Name,
                (league, country) => new
                {
                    League = league,
                    Country = country
                }).ToListAsync();
                var yearNumber = int.Parse(year);
                var season = await _dbContext.SeasonModel
                    .Where(id => id.LeagueId == leagueId)
                    .Where(yr => yr.Year == yearNumber)
                    .FirstOrDefaultAsync();

                if (league != null && season != null)
                {
                    return new LeagueDataDto(league, season);
                }
            }
            return null;
           
        }

        
        public async Task<TeamDto?> GetTeam(int team, int year)
        {
            var url = $"teams?id={team}";
            var teamLol = await _webService.ObjectGetRequest<TeamRoot>(url);

            if (teamLol != null)
            {
                return new TeamDto(teamLol.Response[0], year.ToString());
            }
            return null;
        }

        public LeagueDbService(SoccerStatsDbContext context, SeasonDbService season, WebService service)
        {
            _webService = service;
            _seasonService = season;
            _dbContext = context;
        }

        public async Task<IEnumerable<SeasonModel>?> GetSeasons(int leagueId)
        {
            if (_dbContext.SeasonModel != null)
            {
                var seasons = await _dbContext.SeasonModel
                    .Where(id => id.LeagueId == leagueId)
                    .OrderByDescending(id => id.Year)
                    .ToListAsync();

                return seasons ?? null;
            }
            return null;
        }


        public async Task<IEnumerable<TeamResponse>?> GetTeamModels(int id, string year)
        {
            var url = $"teams?league={id}&season={year}";
            var teams = await _webService.ObjectGetRequest<TeamRoot>(url);

            return teams?.Response;
        }


        public async Task<IEnumerable<LeagueModel>?> GetLeagues()
        {
            var soccerStatsDbContext = _dbContext.LeagueModel.Include(l => l.Country);
            return soccerStatsDbContext != null ?
                  await soccerStatsDbContext.ToListAsync()
            : null;
        }

        public async Task<IEnumerable<LeagueModel>?> GetLeagueDetails(string country)
        {
            var leagueModel = await _dbContext.LeagueModel
                 .Where(m => m.CountryName == country).ToListAsync();

            await _dbContext.LeagueModel
                .Join(_dbContext.CountryModel,
                league => league.CountryName,
                country => country.Name,
                (league, country) => new
                {
                    League = league,
                    Country = country
                }).ToListAsync();

            foreach (var item in leagueModel)
            {
                item.Seasons = await _dbContext.SeasonModel
                    .Where(s => s.LeagueId == item.LeagueId)
                    .OrderBy(x => x.Year)
                    .ToListAsync();
            }
            return leagueModel ?? null;
        }

        public async Task<IEnumerable<CountryModel>?> GetCountriesTemp()
        {
            return _dbContext.CountryModel != null
               ? await _dbContext.CountryModel.ToListAsync()
               : null;
        }

        public async Task<IEnumerable<SeasonModel>?> GetLeagueAvailableSeasons(int id)
        {
            return await _seasonService.GetLeagueAvailableSeasons(id);
        }
    }
}