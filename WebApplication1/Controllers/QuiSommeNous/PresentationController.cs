using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Services.PresentationService;

namespace WebApplication1.Controllers.QuiSommeNous
{
    public class PresentationController : Controller
    {



        private readonly ApplicationDbContext _context;
        private readonly PresentationTaskService PresentationService;

        public PresentationController(ApplicationDbContext context)
        {
            _context = context;
            PresentationService = new PresentationTaskService(_context);

        }


        public IActionResult Presentation()
        {
            var Sections = PresentationService.GetAll();

            return View(Sections);
        }

    }
}
