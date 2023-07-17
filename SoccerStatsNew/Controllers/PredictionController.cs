using Microsoft.AspNetCore.Mvc;
using SoccerStatsData.RequestModels.PredictionRequestFiles;
using UtilityLibraries;

namespace SoccerStatsNew.Controllers
{
    public class PredictionController : Controller
    {
        public IActionResult Index(int? fixture)
        {
            string urlParams = $"predictions?fixture={fixture}";

            var predictions = JsonHelper.GetObjectFromJsonFile<PredictionRoot>("Test/predictions.json");

            return predictions != null
                ? View(predictions.Response[0])
                : NotFound();
        }
    }
}