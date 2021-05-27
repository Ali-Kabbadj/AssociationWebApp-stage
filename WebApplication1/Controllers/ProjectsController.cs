using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Services.ProjectService;

namespace WebApplication1.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ProjectTaskService ProjectService;
        public ProjectsController( ApplicationDbContext context)
        {
            _context = context;
            ProjectService = new ProjectTaskService(_context);

        }

        public IActionResult Index()
        {
            var Projects = ProjectService.GetAll();
            return View(Projects);
        }


        public IActionResult ViewPDF(int id)
        { var Project = ProjectService.GetAll().Where(i=> i.Id == id).First();


            return View(Project);
        }
    }
}
