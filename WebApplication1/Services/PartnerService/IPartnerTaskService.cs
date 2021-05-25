using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services.PartnerService
{
    public interface IPartnerTaskService<T> where T : class, IPartner
    {
        IQueryable<T> GetAll();

        void Insert(T partner);

        void Update(T partner);

        void Delete(T partner);
    }
}
