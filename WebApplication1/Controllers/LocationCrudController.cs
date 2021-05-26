using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models.Contact_Us;
using WebApplication1.Services.LocationService;
using Location = WebApplication1.Models.Contact_Us.Location;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LocationCrudController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly LocationTaskService LocationService;
        public LocationCrudController(ApplicationDbContext context)
        {
            _context = context;
            LocationService = new LocationTaskService(_context);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Location location)
        {
            if (location != null)
            {

                LocationService.Insert(location);

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Index()
        {

            var locations = LocationService.GetAll();

            return View(locations);
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var location = _context.Locations.Find(id);
            return View(location);
        }


        [HttpPost]
        public IActionResult Edit(Location location)
        {
            LocationService.Update(location);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var location = _context.Locations.Find(id);
            return View(location);
        }

        [HttpPost]
        public IActionResult Delete(Location location)
        {
            LocationService.Delete(location);
            return RedirectToAction("Index");
        }
    }
}
