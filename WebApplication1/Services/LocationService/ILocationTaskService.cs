using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services.LocationService
{
    public interface ILocationTaskService<T> where T : class, ILocation
    {
        IQueryable<T> GetAll();

        void Insert(T Location);

        void Update(T Location);

        void Delete(T Location);
    }
}
