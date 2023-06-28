using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using PracticeApp.HttpServices;
using PracticeApp.Models;
using PracticeApp.RequestModels;
using PracticeApp.Services;
using PracticeApp.Utils;

namespace PracticeApp.Controllers
{
    public class LocationController : Controller
    {
        private readonly LocationService _locationService;
        private readonly HttpService _httpService;

        public LocationController(LocationService service, HttpService httpService)
        {
            _locationService = service;
            _httpService = httpService;
        }
        // GET: Location
        public async Task<IActionResult> Index(string? id)
        {
            string parameters = $"location";
            var location = await _httpService.GetObjectJson<LocationRoot>(parameters);

            if (location != null)
            {
                Console.WriteLine("success in the location controller");
                foreach (var item in location.List)
                {
                    Console.WriteLine($"Location Weight is : {item.Weight} && Height is {item.Height}");
                }
            }
            else
            {
                Console.WriteLine("Somethings gone wrong in location Controller");
            }

            if (string.IsNullOrEmpty(id))
            {
                var locationList = await _locationService.GetLocationList();
                return locationList != null
                    ? View(locationList)
                    : Problem("Entity set 'PracticeAppDbContext.LocationModel'  is null.");
            }
            var locationSearchList = await _locationService.GetLocationSearchList(id);
            return locationSearchList != null
                ? View(locationSearchList)
                : Problem("Entity set 'PracticeAppDbContext.LocationModel'  is null.");

        }

        // GET: Location/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (ControllerErrorChecker.CheckDbAndId(id, _locationService.Context.LocationModel))
            {
                return NotFound();
            }

            var locationModel = await _locationService.GetLocationDetails(id);

            return locationModel != null
                ? View(locationModel)
                : NotFound();
        }

        // GET: Location/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationId,Length,Height,Width")] LocationModel locationModel)
        {
            if (ModelState.IsValid)
            {
                await _locationService.CreateLocation(locationModel);
                return RedirectToAction(nameof(Index));
            }
            return View(locationModel);
        }

        // GET: Location/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (ControllerErrorChecker.CheckDbAndId(id, _locationService.Context.LocationModel))
            {
                return NotFound();
            }

            var locationModel = await _locationService.GetLocationAsync(id);
            return locationModel != null
                ? View(locationModel)
                : NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LocationId,Length,Height,Width")] LocationModel locationModel)
        {
            if (id != locationModel.LocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _locationService.EditLocation(id, locationModel);
                return RedirectToAction(nameof(Index));
            }
            return View(locationModel);
        }

        // GET: Location/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteItem(int? id)
        {
            if (id != null)
            {
                await _locationService.DeleteItem(id);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            return ControllerErrorChecker.CheckDbAndId(id, _locationService.Context.LocationModel) == false
                ? View(await _locationService.GetLocation(id))
                : NotFound();
        }

        // POST: Location/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (ControllerErrorChecker.CheckDbAndId(_locationService.Context.LocationModel))
            {
                return Problem("Entity set 'PracticeAppDbContext.LocationModel'  is null.");
            }

            await _locationService.ConfirmDelete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}