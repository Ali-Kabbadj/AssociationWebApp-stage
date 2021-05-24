using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Services.MemberService;

namespace WebApplication1.Controllers.QuiSommeNous
{
    public class MembersController : Controller
    {
        private MemberTaskService membereService;
        private ApplicationDbContext _context;
        public MembersController( ApplicationDbContext context)
        {
            _context = context;
            membereService = new MemberTaskService(_context);

        }

        public IActionResult Index()
        {
            var Members = membereService.GetAll();
            return View(Members);
        }
    }
}
