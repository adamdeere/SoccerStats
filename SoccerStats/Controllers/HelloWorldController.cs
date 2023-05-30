using Microsoft.AspNetCore.Mvc;
using SoccerStats.Models;

namespace SoccerStats.Controllers
{
    public class HelloWorldController : Controller
    {
        private static List<DogViewModel> dogs = new List<DogViewModel>(); 
        public IActionResult Index()
        {
            return View(dogs);
        }

        public IActionResult CreateDog(DogViewModel model)
        {
            dogs.Add(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            DogViewModel doggo = new DogViewModel();
            return View(doggo);
        }
    }
}