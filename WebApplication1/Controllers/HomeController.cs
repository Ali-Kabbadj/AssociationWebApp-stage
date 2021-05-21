using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services.HomeService;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HomeTaskService _HomeService;
        private readonly IWebHostEnvironment _environment;
        private ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _environment = environment;
            _context = context;
            _logger = logger;
            _HomeService = new HomeTaskService(_context,_environment);

        }

        public IActionResult Index()
        {
            var Slides = _HomeService.GetAll();
            return View(Slides);
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
