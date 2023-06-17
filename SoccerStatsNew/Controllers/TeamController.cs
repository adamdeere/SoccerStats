using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoccerStatsNew.Data;
using SoccerStatsNew.Models;

namespace SoccerStatsNew.Controllers
{
    public class TeamController : Controller
    {
        private readonly SoccerStatsDbContext _context;

        public TeamController(SoccerStatsDbContext context)
        {
            _context = context;
        }

        // GET: Team
        public async Task<IActionResult> Index()
        {
            var soccerStatsDbContext = _context.TeamModel.Include(t => t.VenueModel);
            return View(await soccerStatsDbContext.ToListAsync());
        }

        // GET: Team/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TeamModel == null)
            {
                return NotFound();
            }

            var teamModel = await _context.TeamModel
                .Include(t => t.VenueModel)
                .FirstOrDefaultAsync(m => m.TeamId == id);
            if (teamModel == null)
            {
                return NotFound();
            }

            return View(teamModel);
        }

        // GET: Team/Create
        public IActionResult Create()
        {
            ViewData["StadiumId"] = new SelectList(_context.VenuesModel, "StadiumId", "StadiumId");
            return View();
        }

        // POST: Team/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamId,StadiumId,Name,Code,Country,Founded,National,Logo")] TeamModel teamModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teamModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StadiumId"] = new SelectList(_context.VenuesModel, "StadiumId", "StadiumId", teamModel.StadiumId);
            return View(teamModel);
        }

        // GET: Team/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TeamModel == null)
            {
                return NotFound();
            }

            var teamModel = await _context.TeamModel.FindAsync(id);
            if (teamModel == null)
            {
                return NotFound();
            }
            ViewData["StadiumId"] = new SelectList(_context.VenuesModel, "StadiumId", "StadiumId", teamModel.StadiumId);
            return View(teamModel);
        }

        // POST: Team/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamId,StadiumId,Name,Code,Country,Founded,National,Logo")] TeamModel teamModel)
        {
            if (id != teamModel.TeamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teamModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamModelExists(teamModel.TeamId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StadiumId"] = new SelectList(_context.VenuesModel, "StadiumId", "StadiumId", teamModel.StadiumId);
            return View(teamModel);
        }

        // GET: Team/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TeamModel == null)
            {
                return NotFound();
            }

            var teamModel = await _context.TeamModel
                .Include(t => t.VenueModel)
                .FirstOrDefaultAsync(m => m.TeamId == id);
            if (teamModel == null)
            {
                return NotFound();
            }

            return View(teamModel);
        }

        // POST: Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TeamModel == null)
            {
                return Problem("Entity set 'SoccerStatsDbContext.TeamModel'  is null.");
            }
            var teamModel = await _context.TeamModel.FindAsync(id);
            if (teamModel != null)
            {
                _context.TeamModel.Remove(teamModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamModelExists(int id)
        {
          return (_context.TeamModel?.Any(e => e.TeamId == id)).GetValueOrDefault();
        }
    }
}
