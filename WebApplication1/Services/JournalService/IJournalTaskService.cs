using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.TimeRelated;

namespace WebApplication1.Services.JournalService
{
    public interface IJournalTaskService<T> where T: class, IJournal
    {
        IQueryable<T> GetAll();

        void Insert(T Slide);

        void Update(T Slide);

        void Delete(T Slide);

    }
}
