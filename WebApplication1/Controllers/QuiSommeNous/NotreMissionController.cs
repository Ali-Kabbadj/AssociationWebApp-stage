using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Services.MemberService;
using WebApplication1.Services.MissionService;
using WebApplication1.Services.PartnerService;
using WebApplication1.Services.ProjectService;

namespace WebApplication1.Controllers.QuiSommeNous
{
    public class NotreMissionController : Controller
    {

        private MissionTaskService MissionService;
        private ApplicationDbContext _context;

        private MemberTaskService MemberService;
        private PartnerTaskService PartnersService;
        private ProjectTaskService ProjectSrvice;
        public NotreMissionController(ApplicationDbContext context)
        {
            _context = context;
            MissionService = new MissionTaskService(_context);
            MemberService = new MemberTaskService(_context);
            ProjectSrvice = new ProjectTaskService(_context);
            PartnersService = new PartnerTaskService(_context);

        }

        public IActionResult Index()
        {
            ViewBag.Projects = ProjectSrvice.GetAll().Count();
            ViewBag.Mombers = MemberService.GetAll().Count();
            ViewBag.Partenaires = PartnersService.GetAll().Count();
            var MissionSections = MissionService.GetAll();
            return View(MissionSections);
        }



    }
}
