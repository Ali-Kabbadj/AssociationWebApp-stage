using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models.TimeRelated;
using WebApplication1.Services.CalendarService;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace WebApplication1.Controllers.EventsEndCalendar
{
    public class CalendarController : Controller
    {

        private ApplicationDbContext _db;



        public ActionResult Index()
        {
            return View();
        }


        private CalendarEventTaskService taskService;
     

        public CalendarController(ApplicationDbContext context)
        {
            _db = context;
            taskService = new CalendarEventTaskService(context);
        }

        public virtual JsonResult Read([DataSourceRequest] DataSourceRequest request)
        {
            //return Json(taskService.GetRangebyid(GetCurrentUserId().Result).ToDataSourceResult(request));
            return Json(taskService.GetAll().ToDataSourceResult(request)); ;
        }

        public virtual JsonResult Destroy([DataSourceRequest] DataSourceRequest request, CalendarEvent task)
        {
            if (ModelState.IsValid)
            {
                taskService.Delete(task);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Create([DataSourceRequest] DataSourceRequest request, CalendarEvent task)
        {
            if (ModelState.IsValid)
            {
                taskService.Insert(task);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Update([DataSourceRequest] DataSourceRequest request, CalendarEvent task)
        {
            if (ModelState.IsValid)
            {
                taskService.Update(task);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            taskService.Dispose();
            base.Dispose(disposing);
        }


        private readonly DateTime[] SpecialDays = new DateTime[] { new DateTime(2008, 6, 26), new DateTime(2008, 6, 27) };
    }
}
