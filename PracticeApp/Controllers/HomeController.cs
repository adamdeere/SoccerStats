using Microsoft.AspNetCore.Mvc;
using PracticeApp.HttpServices;
using PracticeApp.Models;
using PracticeApp.RequestModels;
using PracticeApp.Utils;
using System.Diagnostics;
using System.Text;
using YamlDotNet.Serialization;

namespace PracticeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpService _httpService;
       
      
        public HomeController(ILogger<HomeController> logger, HttpService httpService)
        {
            _httpService = httpService;
            _logger = logger;
        }

        private  void DumpAsYaml(object data)
        {
            Console.WriteLine("***Dumping Object Using Yaml Serializer***");
            var stringBuilder = new StringBuilder();
            var serializer = new Serializer();
            stringBuilder.AppendLine(serializer.Serialize(data));
            Console.WriteLine(stringBuilder);
            Console.WriteLine("");
        }

        public async Task<IActionResult> Index()
        {
            string parameters = $"health";
            var health = await _httpService.GetObjectFromJson<HealthCheckRequestModel>(parameters);
            if (health != null)
            {
                Console.WriteLine($"staus code {health.ResultCode} message is {health.ResultMsg}");

                string healthJson = JsonConverterUtil.ConvertObjectToJson(health);
                Console.WriteLine(healthJson);
            }
            else
            {
                Console.WriteLine("Somethings gone wrong in home controller");
            }
            DumpAsYaml(parameters);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}