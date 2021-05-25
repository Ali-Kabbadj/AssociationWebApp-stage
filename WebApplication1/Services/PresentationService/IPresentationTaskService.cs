using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services.PresentationService
{
    public interface IPresentationTaskService<T> where T : class, IPresentation
    {
        IQueryable<T> GetAll();

        void Insert(T Presentation);

        void Update(T Presentation);

        void Delete(T presentation);
    }
}
