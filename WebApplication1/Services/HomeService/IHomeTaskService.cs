using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services.HomeService
{
    public interface IHomeTaskService<T> where T : class, IHome
    {
        IQueryable<T> GetAll();

        void Insert(T Slide);

        void Update(T Slide);

        void Delete(T Slide);
    }
}
