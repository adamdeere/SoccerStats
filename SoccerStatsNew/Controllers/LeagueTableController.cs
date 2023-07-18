using Microsoft.AspNetCore.Mvc;
using SoccerStatsData.RequestModels;
using UtilityLibraries;

namespace SoccerStatsNew.Controllers
{
    public class LeagueTableController : Controller
    {
        public IActionResult Index()
        {
            LeagueTableRoot? lol = null;
            try
            {
                 lol = JsonHelper.GetObjectFromJsonFile<LeagueTableRoot>("Test/tables.json");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
           
            return View(lol);
        }
    }
}
