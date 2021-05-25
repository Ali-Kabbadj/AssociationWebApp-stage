using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VirtualClinic.Classes.UploadFiles;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services.PartnerService
{
    public class PartnerTaskService : IPartnerTaskService<Partner>
    {

        private readonly ApplicationDbContext db;
        public PartnerTaskService(ApplicationDbContext context)
        {
            db = context;
        }

        public virtual IQueryable<Partner> GetAll()
        {
            IQueryable<Partner> partners = db.Partners.Select(Partner => new Partner
            {
                Id=Partner.Id,
                Name= Partner.Name,
                Image=Partner.Image
            });
            return partners;
        }


        public virtual void Insert(Partner partner)
        {
            db.Partners.Add(partner);
                db.SaveChanges();
        }

        public virtual void Update(Partner partner)
        {
                db.Partners.Attach(partner);
                db.Entry(partner).State = EntityState.Modified;
                db.SaveChanges();
        }


        public virtual void Delete(Partner partner)
        {
            db.Partners.Attach(partner);
            db.Partners.Remove(partner);
            db.SaveChanges();
        }

    }
}
