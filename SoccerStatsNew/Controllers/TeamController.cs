using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerStatsNew.Data;
using SoccerStatsNew.Services;

namespace SoccerStatsNew.Controllers
{
    public class TeamController : Controller
    {
        private readonly SoccerStatsDbContext _context;
        private readonly TeamHttpService? _service;
        public TeamController(SoccerStatsDbContext context, TeamHttpService service)
        {
            _service = service;
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id == null || _service == null)
            {
                return NotFound();
            }
            string idString = id.ToString();
            var teams = await _service.GetCountry(idString);
            if (teams == null)
            {
                return NotFound();
            }
            return View(teams.Response);
        }
        [HttpPost]
        public async Task<IActionResult> Details(int? id, int? b)
        {
            if (id == null || _context.TeamModel == null || b == null)
            {
                return NotFound();
            }

            var teamModel = await _context.TeamModel
                .FirstOrDefaultAsync(m => m.TeamId == id);
            
                await _context.TeamModel
               .Join(_context.VenuesModel,
                   team => team.StadiumId,
                   venue => venue.StadiumId,
                (team, venue) => new
                {
                    Venue = venue,
                    Team = team,
                }).ToListAsync();
           
            if (teamModel == null)
            {
                return NotFound();
            }
            return View(teamModel);
        }
    }
}
