using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models.TimeRelated;
using WebApplication1.Services.CalendarService;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CalendarEventCrudController : Controller
    {
        private CalendarEventTaskService EventService;
        private ApplicationDbContext _context;
        public CalendarEventCrudController(ApplicationDbContext context)
        {
            _context = context;
            EventService = new CalendarEventTaskService(_context);

        }


        public IActionResult Index()
        {
            var events = EventService.GetAll();
            return View(events);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CalendarEvent Event)
        {
            if (Event != null)
            {
                EventService.Insert(Event);
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
           
            var Event = _context.Events.Find(id);
            ViewBag.Id = Event.TaskId;
            @ViewBag.Color = Event.Color;
            return View(Event);
        }


        [HttpPost]
        public IActionResult Edit(CalendarEvent Event,int id)
        {
            Event.TaskId = id;
            EventService.Update(Event);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Event = _context.Events.Find(id);
            @ViewBag.Color = Event.Color;
            return View(Event);
        }

        [HttpPost]
        public IActionResult Delete(CalendarEvent Event, int id)
        {
            Event.TaskId = id;
            EventService.Delete(Event);
            return RedirectToAction("Index");
        }

    }
}
