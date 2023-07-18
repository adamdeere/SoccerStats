using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using SoccerStatsData.RequestModels;
using SoccerStatsNew.DbServices;
using UtilityLibraries;

namespace SoccerStatsNew.Controllers
{
    public class PlayerController : Controller
    {
        private readonly PlayerService _playerService;
        public PlayerController(PlayerService service)
        {
            _playerService = service;
        }
        public async Task<ActionResult> Players_Read([DataSourceRequest] DataSourceRequest request, int id)
        {
            var year = "2023";
            string url = $"players?season={year}&team={id}";
            var players = await _playerService.GetPlayers(id);  
            if (players != null)
            {
                return Json(await players.Response.ToDataSourceResultAsync(request));
            }
            return Json(null);
        }
    }
}