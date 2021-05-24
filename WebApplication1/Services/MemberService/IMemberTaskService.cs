using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services.MemberService
{
    public interface IMemberTaskService<T> where T : class, IMember
    {
        IQueryable<T> GetAll();

        void Insert(T Member);

        void Update(T Member);

        void Delete(T Member);
    }
}
