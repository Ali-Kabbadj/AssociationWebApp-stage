using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services.CalendarService
{
    public interface ICalendarEventTaskService<T> where T : class, ICalendarEvent
    {
        IQueryable<T> GetAll();

        void Insert(T Event);

        void Update(T Event);

        void Delete(T Event);
    }
}
