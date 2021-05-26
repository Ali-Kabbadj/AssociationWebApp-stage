using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models.TimeRelated;

namespace WebApplication1.Services.JournalService
{
    public class JournalTaskService : IJournalTaskService<Journal>
    {

        private readonly ApplicationDbContext db;
        public JournalTaskService(ApplicationDbContext context)
        {
            db = context;
        }

        public virtual IQueryable<Journal> GetAll()
        {
            IQueryable<Journal> journals = db.Journals.Select(Journal => new Journal
            {
                Id = Journal.Id,
                Title = Journal.Title,
                CreationDate = Journal.CreationDate,
                Image = Journal.Image,
                Paragraph=Journal.Paragraph
            }).OrderByDescending(x=>  x.CreationDate.Year).ThenByDescending(x => x.CreationDate.Month).ThenByDescending(x => x.CreationDate.Day).ThenByDescending(x => x.CreationDate.Hour).ThenByDescending(x => x.CreationDate.Minute);
            return journals;
        }


        public virtual void Insert(Journal Journal)
        {
            Journal.CreationDate = DateTime.Now;
            db.Journals.Add(Journal);
            db.SaveChanges();
        }

        public virtual void Update(Journal Journal)
        {
            db.Journals.Attach(Journal);
            db.Entry(Journal).State = EntityState.Modified;
            db.SaveChanges();
        }


        public virtual void Delete(Journal Journal)
        {
            db.Journals.Attach(Journal);
            db.Journals.Remove(Journal);
            db.SaveChanges();
        }

        private bool ValidateModel(Journal Journal)
        {
            //Test Doctor model state here
            return true;
        }
    }
}
