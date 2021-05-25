using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Services.LocationService;

namespace WebApplication1.Controllers.Contact_US
{
    public class LocationController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly LocationTaskService LocationService;
        public LocationController( ApplicationDbContext _db)
        {
            db = _db;
            LocationService = new LocationTaskService(db);
        }

        public IActionResult Index()
        {
            var Locations = LocationService.GetAll();
            return View(Locations);
        }
    }
}
