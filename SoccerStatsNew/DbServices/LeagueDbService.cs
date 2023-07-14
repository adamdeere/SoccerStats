using Microsoft.EntityFrameworkCore;
using SoccerStatsData;
using SoccerStatsNew.Data;
using SoccerStatsNew.DbServices;
using UtilityLibraries;

namespace SoccerStatsNew.Services
{
    public class LeagueDbService
    {
        private readonly SoccerStatsDbContext _context;
        private readonly SeasonDbService _seasonService;
        private readonly WebService _webService;

        public async Task SaveLeagueAndSeason(LeagueRoot root)
        {
            if (_context.LeagueModel != null && _context.SeasonModel != null)
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
                            _context.SeasonModel.Add(seasonDbModel);
                            await _context.SaveChangesAsync();
                        }
                        LeagueModel model = new()
                        {
                            LeagueId = item.League.Id,
                            Name = item.League.Name,
                            Type = item.League.Type,
                            LogoURL = item.League.Logo,
                            CountryName = item.Country.Name
                        };

                        _context.LeagueModel.Add(model);
                        await _context.SaveChangesAsync();
                    }
                }
            }
        }

        public LeagueDbService(SoccerStatsDbContext context, SeasonDbService season, WebService service)
        {
            _webService = service;
            _seasonService = season;
            _context = context;
        }

        public async Task<IEnumerable<SeasonModel>?> GetSeasons(int leagueId)
        {
            if (_context.SeasonModel != null)
            {
                var seasons = await _context.SeasonModel
                    .Where(id => id.LeagueId == leagueId)
                    .OrderByDescending(id => id.Year)
                    .ToListAsync();

                return seasons ?? null;
            }
            return null;
        }

        public async Task SaveTeamsAndVenues(int id, string year)
        {
            string url = $"teams?league={id}&season={year}";
            var teamRoot = await _webService.GetObjectRequest<TeamRoot>(url);
            if (teamRoot != null)
            {
                foreach (var item in teamRoot.Response)
                {
                    /*
                    if (item.Venue.Id != null)
                    {
                        VenuesModel venue = new()
                        {
                            VenueId = (int)item.Venue.Id,
                            Name = item.Venue.Name,
                            Address = item.Venue.Address,
                            City = item.Venue.City,
                            Country = item.Team.Country,
                            Capacity = item.Venue.Capacity,
                            Surface = item.Venue.Surface,
                            Image = item.Venue.Image,
                        };
                        if (!VenueModelExists(venue))
                        {
                            _context.VenuesModel.Add(venue);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            _context.VenuesModel.Update(venue);
                            await _context.SaveChangesAsync();
                        }
                    }
                    */
                    if (item.Team.Id != null)
                    {
                        TeamModel teamModel = new()
                        {
                            TeamId = item.Team.Id,
                            StadiumId = item.Venue.Id,
                            Name = item.Team.Name,
                            Code = item.Team.Code,
                            Country = item.Team.Country,
                            Founded = item.Team.Founded,
                            National = item.Team.National,
                            Logo = item.Team.Logo,
                            LeagueId = id,
                        };

                        if (!TeamModelExists(teamModel))
                        {
                            _context.TeamModel.Add(teamModel);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            _context.TeamModel.Update(teamModel);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
            }
        }

        public async Task<IEnumerable<TeamModel>?> GetTeamModels(int id)
        {
            var teamModel = await _context.TeamModel
                .Where(m => m.LeagueId == id)
                .ToListAsync();

            return teamModel ?? null;
        }

        private bool VenueModelExists(VenuesModel id)
        {
            return (_context.VenuesModel?.Any(e => e == id)).GetValueOrDefault();
        }

        private bool TeamModelExists(TeamModel id)
        {
            return (_context.TeamModel?.Any(e => e == id)).GetValueOrDefault();
        }

        public async Task<ICollection<LeagueModel>?> GetLeagues()
        {
            var soccerStatsDbContext = _context.LeagueModel.Include(l => l.Country);
            return soccerStatsDbContext != null ?
                  await soccerStatsDbContext.ToListAsync()
            : null;
        }

        public async Task<IEnumerable<LeagueModel>?> GetLeagueDetails(string country)
        {
            var leagueModel = await _context.LeagueModel
                 .Where(m => m.CountryName == country).ToListAsync();

            await _context.LeagueModel
                .Join(_context.CountryModel,
                league => league.CountryName,
                country => country.Name,
                (league, country) => new
                {
                    League = league,
                    Country = country
                }).ToListAsync();

            foreach (var item in leagueModel)
            {
                item.Seasons = await _context.SeasonModel
                    .Where(s => s.LeagueId == item.LeagueId)
                    .OrderBy(x => x.Year)
                    .ToListAsync();
            }
            return leagueModel ?? null;
        }

        public async Task<IEnumerable<CountryModel>?> GetCountriesTemp()
        {
            return _context.CountryModel != null
               ? await _context.CountryModel.ToListAsync()
               : null;
        }

        public async Task<ICollection<SeasonModel>?> GetLeagueAvailableSeasons(int id)
        {
            return await _seasonService.GetLeagueAvailableSeasons(id);
        }
    }
}