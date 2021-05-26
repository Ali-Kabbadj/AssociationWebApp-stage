using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Services.CalendarService;

namespace WebApplication1.Models.TimeRelated
{
    public class CalendarEvent: ISchedulerEvent
    {
        
        [Key]
        public int TaskId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsAllDay { get; set; }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
        public int Color { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public string RecurrenceID { get; set; }
    }
}
