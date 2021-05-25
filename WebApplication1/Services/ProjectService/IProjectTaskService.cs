using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services.ProjectService
{
    public interface IProjectnTaskService<T> where T : class, IProject
    {
        IQueryable<T> GetAll();

        void Insert(T Project);

        void Update(T Project);

        void Delete(T Project);
    }
}
