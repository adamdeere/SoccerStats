using Microsoft.AspNetCore.Mvc;
using PracticeApp.Models;
using System.Diagnostics;

namespace PracticeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            TestModel model = new TestModel()
            {
                Email = 66.ToString(),
            };


            return View(model);
        }
        public IActionResult Lol([Bind("Email")] TestModel itemModel)
        {
            return View(itemModel);
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

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyEmail(string email)
        {
            if (email == string.Empty)
            {
                return Json($"Email {email} is already in use.");
            }
            return Json(true);
        }

        
       
        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckMax([Bind("Total")] TestModel itemModel)
        {
            if (itemModel.Total > 20)
            {
                return Json($"you cannot store {itemModel.Total} items here!!");
            }
            return Json(true);
        }
    }
}