using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Services.PartnerService;

namespace WebApplication1.Controllers
{
    public class PartnersController : Controller
    {

        private PartnerTaskService PartnerService;
        private ApplicationDbContext _context;

        public PartnersController( ApplicationDbContext context)
        {
            _context = context;
            PartnerService = new PartnerTaskService(_context);
        }

        public IActionResult Index()
        {
            var partners = PartnerService.GetAll();
            return View(partners);
        }
    }
}
