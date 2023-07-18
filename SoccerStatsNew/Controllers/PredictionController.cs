using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using SoccerStatsData.RequestModels.PredictionRequestFiles;
using UtilityLibraries;

namespace SoccerStatsNew.Controllers
{
    public class PredictionController : Controller
    {
        private readonly WebService _webService;

        public PredictionController(WebService webService)
        {
            _webService = webService;
        }

        public IActionResult Index(int? fixture)
        {
            string urlParams = $"predictions?fixture={fixture}";

            var predictions = JsonHelper.GetObjectFromJsonFile<PredictionRoot>("Test/predictions.json");

            return predictions != null
                ? View(predictions.Response[0])
                : NotFound();
        }

        public IActionResult Last_Five_Read([DataSourceRequest] DataSourceRequest request)
        {
            var predictions = JsonHelper.GetObjectFromJsonFile<PredictionRoot>("Test/predictions.json");

            if (predictions != null)
            {
                return Json(predictions.Response[0].HeadToHeadStats.ToDataSourceResult(request));
            }

            return Json(null);
        }
    }
}