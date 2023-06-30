using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerStatsNew.Data;
using SoccerStatsNew.Services;

namespace SoccerStatsNew.Controllers
{
    public class TeamController : Controller
    {
        private readonly SoccerStatsDbContext _context;
       

        public TeamController(SoccerStatsDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TeamModel == null)
            {
                return NotFound();
            }

            var teamModel = await _context.TeamModel
                .FirstOrDefaultAsync(m => m.TeamId == id);

            await _context.TeamModel
           .Join(_context.VenuesModel,
               team => team.StadiumId,
               venue => venue.VenueId,
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