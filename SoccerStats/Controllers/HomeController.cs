using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using NuGet.Protocol;
using SoccerStats.Data;
using SoccerStats.Models;
using SoccerStats.RequestModel;
using SoccerStats.Services;
using System.Diagnostics;
using System.Net.Http;


namespace SoccerStats.Controllers
{
    public class HomeController : Controller
    {
        private readonly CountryService _CountryService;
        private readonly ApplicationDbContext _context;
        public CountryResponse? countryResponse { get; set; }
        public HomeController(CountryService countryService, ApplicationDbContext context)
        {
           
            _CountryService = countryService;
            _context = context;
        } 

        public IList<CountryModel>? Countries { get; set; }  
        public async Task OnGetAsync()
        {
            Countries = await _context.Countries.ToListAsync();
        }

        public async Task<IActionResult> Index()
        {
           
            countryResponse = await _CountryService.GetCountries();

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