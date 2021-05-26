using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Services.JournalService;

namespace WebApplication1.Controllers.EventsEndCalendar
{
    public class JournalController : Controller
    {
        private readonly ApplicationDbContext Db;
        private readonly JournalTaskService JournalService;

        public JournalController(ApplicationDbContext _db)
        {
            Db = _db;
            JournalService = new JournalTaskService(Db);
        }

        public IActionResult Index()
        {
            var Journals = JournalService.GetAll();
            return View(Journals);
        }
    }
}
