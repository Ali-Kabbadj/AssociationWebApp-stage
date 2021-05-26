using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models.TimeRelated;
using WebApplication1.Services.CalendarService;
using WebApplication1.Services.PartnerService;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class EventCrudController : Controller
    { 
        private readonly ApplicationDbContext _context;
        private readonly CalendarEventTaskService EventService;
        public EventCrudController(ApplicationDbContext context)
        {
            _context = context;
            EventService = new CalendarEventTaskService(_context);
        }





















       
        [HttpGet]
        public IActionResult Index()
        {

            var Events = EventService.GetAll();

            return View(Events);
        }




        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateEvent(CalendarEvent @event)
        {
            if (@event != null)
            {
                _context.Events.Add(@event);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult EditEvent(int id)
        {
            var partner = _context.Events.Find(id);
            
            return View(partner);
        }


        [HttpPost]
        public IActionResult EditEvent(CalendarEvent Event)
        {
            _context.Events.Attach(Event);
            _context.Entry(Event).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult DeleteEvent(int id)
        {
            var Event = _context.Events.Find(id);
            return View(Event);
        }

        [HttpPost]
        public IActionResult DeleteEvent(CalendarEvent task)
        {
            _context.Events.Attach(task);
            _context.Events.Remove(task);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
