﻿using Microsoft.AspNetCore.Mvc;
using PracticeApp.HttpServices;
using PracticeApp.Models;
using PracticeApp.RequestModels;
using System.Diagnostics;

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
        public async Task<IActionResult> Index()
        {
            string parameters = $"health";
            var health = await _httpService.GetObjectJson<HealthCheckRequestModel>(parameters);
            if (health != null)
            {
                Console.WriteLine($"staus code {health.ResultCode} message is {health.ResultMsg}");
            }
            else
            {
                Console.WriteLine("Somethings gone wrong in home controller");
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