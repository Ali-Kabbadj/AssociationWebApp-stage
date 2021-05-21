using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models.Home;
using WebApplication1.Models.QuiSommeNous.ArticlePresentation;

namespace WebApplication1.Services.PresentationService
{
    public class PresentationTaskService : IPresentationTaskService<Section>
    {

        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment _environment;
        public PresentationTaskService(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            db = context;
            _environment = environment;
        }

        public virtual IQueryable<Section> GetAll()
        {
            IQueryable<Section> Presentation = db.PresnetationPage.Select(Section => new Section
            {
                Id= Section.Id,
                Image =Section.Image,
                Text =Section.Text,
                ListOfParagraphs = Section.ListOfParagraphs
            });
            return Presentation;
        }


        public virtual void Insert(Section section)
        {
            section.Id = Guid.NewGuid().ToString();
            db.PresnetationPage.Add(section);
            db.SaveChanges();
        }

        public virtual void Update(Section section)
        {
                db.PresnetationPage.Attach(section);
                db.Entry(section).State = EntityState.Modified;
                db.SaveChanges();
        }


        public virtual void Delete(Section section)
        {
            db.PresnetationPage.Attach(section);
            db.PresnetationPage.Remove(section);
            db.SaveChanges();
        }

        private bool ValidateModel(HomeModel Slide)
        {
            return true;
        }
    }
}
