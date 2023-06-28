using Microsoft.AspNetCore.Mvc;
using PracticeApp.HttpServices;
using PracticeApp.Models;
using System.Diagnostics;
using static PracticeApp.RequestModels.ItemRequestModel;

namespace PracticeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpService _contextAccessor;
      
        public HomeController(ILogger<HomeController> logger, HttpService service)
        {
            _contextAccessor = service;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            string url = $"whbase2/rest/whbase2Service/item";
            var item = await _contextAccessor.GetObjectJson<ItemRoot>(url);

            if (item != null)
            {
                Console.WriteLine("success in the home controller");
            }
            else 
            {
                Console.WriteLine("Somethings gone wrong in Home Controller");
            }
            
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