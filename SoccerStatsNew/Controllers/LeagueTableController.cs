﻿using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
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
        public async Task<IActionResult> Index(int leagueid, string year)
        {
            var table = await _tableService.GetLeagueTable(leagueid, year);
           
            return table != null 
                    ? View(table) 
                    : NotFound();
        }
        
    }
}
