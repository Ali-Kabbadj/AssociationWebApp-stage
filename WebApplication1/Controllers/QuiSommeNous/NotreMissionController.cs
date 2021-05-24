using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Services.MissionService;

namespace WebApplication1.Controllers.QuiSommeNous
{
    public class NotreMissionController : Controller
    {

        private MissionTaskService MissionService;
        private ApplicationDbContext _context;
        public NotreMissionController(ApplicationDbContext context)
        {
            _context = context;
            MissionService = new MissionTaskService(_context);

        }

        public IActionResult Index()
        {
            //ViewBag.Projects
            //ViewBag.Mombers
            //ViewBag.Partenaires
            var MissionSections = MissionService.GetAll();
            return View(MissionSections);
        }



    }
}
