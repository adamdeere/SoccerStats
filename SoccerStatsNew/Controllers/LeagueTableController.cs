using Microsoft.AspNetCore.Mvc;
using SoccerStatsNew.DbServices;

namespace SoccerStatsNew.Controllers
{
    public class LeagueTableController : Controller
    {
        private readonly LeagueTableService _tableService;
        public LeagueTableController(LeagueTableService service)
        {
            _tableService = service;    
        }
        public async Task<IActionResult> Index()
        {
            var table = await _tableService.GetLeagueTable(41, "2022");
           
            return table != null 
                    ? View(table) 
                    : NotFound();
        }
    }
}
