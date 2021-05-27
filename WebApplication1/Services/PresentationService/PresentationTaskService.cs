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


        public PresentationTaskService(ApplicationDbContext context)
        {
            db = context;
        }



        // Presentation
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
            db.Paragraphs.RemoveRange(GetAllParagraphsBySectionId(section.Id));
            db.PresnetationPage.Remove(section);
            db.SaveChanges();
        }

  





        // Paragraphs

        public virtual IQueryable<Paragraph> GetAllParagraphs()
        {
            IQueryable<Paragraph> Paragraphs = db.Paragraphs.Select(paragraph => new Paragraph
            {
                Id = paragraph.Id,
                ParagraphContent = paragraph.ParagraphContent,
                SectionId = paragraph.SectionId
                
            });
            return Paragraphs;
        }

        public virtual IQueryable<Paragraph> GetAllParagraphsBySectionId(int idSection)
        {
            var Paragraphs = GetAllParagraphs().Where(i => i.SectionId == idSection);
            return Paragraphs;
        }


        public virtual void InsertParagraph(Paragraph paragraph)
        {
            db.Paragraphs.Add(paragraph);
            db.SaveChanges();
        }

        public virtual void UpdateParagraph(Paragraph paragraph)
        {
            db.Paragraphs.Attach(paragraph);
            db.Entry(paragraph).State = EntityState.Modified;
            db.SaveChanges();
        }


        public virtual void DeleteParagraph(Paragraph paragraph)
        {
            db.Paragraphs.Attach(paragraph);
            db.Paragraphs.Remove(paragraph);
            db.SaveChanges();
        }
    }
}
