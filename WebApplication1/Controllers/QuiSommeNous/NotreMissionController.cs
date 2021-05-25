using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Services.MemberService;
using WebApplication1.Services.MissionService;

namespace WebApplication1.Controllers.QuiSommeNous
{
    public class NotreMissionController : Controller
    {

        private MissionTaskService MissionService;
        private ApplicationDbContext _context;
        private MemberTaskService MemberService;
        public NotreMissionController(ApplicationDbContext context)
        {
            _context = context;
            MissionService = new MissionTaskService(_context);
            MemberService = new MemberTaskService(_context);

        }

        public IActionResult Index()
        {
            ViewBag.Projects = 2;
            ViewBag.Mombers = MemberService.GetAll().Count();
            ViewBag.Partenaires = 3;
            var MissionSections = MissionService.GetAll();
            return View(MissionSections);
        }



    }
}
