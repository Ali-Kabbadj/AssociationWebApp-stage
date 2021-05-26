using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models.TimeRelated;

namespace WebApplication1.Services.CalendarService
{
    public class CalendarEventTaskService : ISchedulerEventService<CalendarEvent>
    {

        private readonly ApplicationDbContext db;
        public CalendarEventTaskService(ApplicationDbContext context)
        {
            db = context;
        }






        public virtual IQueryable<CalendarEvent> GetAll()
        {
            IQueryable<CalendarEvent> result = db.Events.Select(task => new CalendarEvent
            {
                TaskId = task.TaskId,
                Title = task.Title,
                Start = DateTime.SpecifyKind(task.Start, DateTimeKind.Utc),
                End = DateTime.SpecifyKind(task.End, DateTimeKind.Utc),
                StartTimezone = task.StartTimezone,
                EndTimezone = task.EndTimezone,
                Description = task.Description,
                IsAllDay = task.IsAllDay,
                RecurrenceRule = task.RecurrenceRule,
                RecurrenceException = task.RecurrenceException,
                Color = task.Color,
                RecurrenceID =task.RecurrenceID

            });

            return result;
        }



        public virtual void Insert(CalendarEvent task, ModelStateDictionary modelState)
        {
            if (ValidateModel(task, modelState))
            {

                if (string.IsNullOrEmpty(task.Title))
                {
                    task.Title = "";
                }
                db.Events.Add(task);
                db.SaveChanges();

            }
        }

        public virtual void Update(CalendarEvent task, ModelStateDictionary modelState)
        {
            if (ValidateModel(task, modelState))
            {

                if (string.IsNullOrEmpty(task.Title))
                {
                    task.Title = "";
                }

                db.Events.Attach(task);
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public virtual void Delete(CalendarEvent task, ModelStateDictionary modelState)
        {

            db.Events.Attach(task);



            db.Events.Remove(task);
            db.SaveChanges();
        }



































        public virtual IQueryable<CalendarEvent> GetAllEvents()
        {
            IQueryable<CalendarEvent> result = db.Events.Select(task => new CalendarEvent
            {
                TaskId = task.TaskId,
                Title = task.Title,
                Start = DateTime.SpecifyKind(task.Start, DateTimeKind.Utc),
                End = DateTime.SpecifyKind(task.End, DateTimeKind.Utc),
                StartTimezone = task.StartTimezone,
                EndTimezone = task.EndTimezone,
                Description = task.Description,
                IsAllDay = task.IsAllDay,
                RecurrenceRule = task.RecurrenceRule,
                RecurrenceException = task.RecurrenceException,
                Color = task.Color,
                RecurrenceID = task.RecurrenceID

            });

            return result;
        }

       

  

        public CalendarEvent One(Func<CalendarEvent, bool> predicate)
        {
            return GetAllEvents().FirstOrDefault(predicate);
        }

        public void Dispose()
        {
            db.Dispose();
        }


        public virtual void Insert(CalendarEvent task)
        {
            if (task!=null)
            {

                if (string.IsNullOrEmpty(task.Title))
                {
                    task.Title = "";
                }
                db.Events.Add(task);
                db.SaveChanges();

            }
        }

        public virtual void Update(CalendarEvent task)
        {
            if (task!=null)
            {

                if (string.IsNullOrEmpty(task.Title))
                {
                    task.Title = "Pas-De-Titre";
                }
                
                db.Events.Attach(task);
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public virtual void Delete(CalendarEvent task)
        {

            db.Events.Attach(task);
            db.Events.Remove(task);
            db.SaveChanges();
        }

        private bool ValidateModel(CalendarEvent appointment, ModelStateDictionary modelState)
        {
            if (appointment.Start > appointment.End)
            {
                modelState.AddModelError("errors", "End date must be greater or equal to Start date.");
                return false;
            }

            return true;
        }


  



    }
}
