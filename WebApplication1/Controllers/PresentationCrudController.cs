using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models.QuiSommeNous.ArticlePresentation;
using WebApplication1.Services.HomeService;
using WebApplication1.Services.PresentationService;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class PresentationCrudController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly PresentationTaskService PresentationService;
        private readonly IWebHostEnvironment _environment;

        public PresentationCrudController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
            PresentationService = new PresentationTaskService(_context);

        }


        public IActionResult Index()
        {
            var Sections = PresentationService.GetAll();

            return View(Sections);
        }




        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Section section)
        {



            using (var target = new MemoryStream())
            {
                section.ImageIForm.CopyTo(target);
                section.Image = target.ToArray();
            }
            PresentationService.Insert(section);
            return RedirectToAction("Index");
        }




        [HttpGet]
        public IActionResult Edit(string id)
        {
            var Presentation = PresentationService.GetAll().Where(i => i.Id == id).First();
            var stream = new MemoryStream(Presentation.Image);
            IFormFile file = new FormFile(stream, 0, Presentation.Image.Length, "name", "fileName");
            Presentation.ImageIForm = file;
            return View(Presentation);
        }


        [HttpPost]
        public IActionResult Edit(Section section,string id)
        {

            if (section.ImageIForm == null)
            {
                section.Image = PresentationService.GetAll().Where(i => i.Id == id).First().Image;
            }
            else
            {
                //Getting FileName
                var fileName = Path.GetFileName(section.ImageIForm.FileName);
                //Getting file Extension
                var fileExtension = Path.GetExtension(fileName);
                // concatenating  FileName + FileExtension
                var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);



                using var target = new MemoryStream();
                section.ImageIForm.CopyTo(target);
                section.Image = target.ToArray();
            }
            PresentationService.Update(section);
            return RedirectToAction("Index");
        }




        [HttpGet]
        public IActionResult Delete(string id)
        {
            var DeleteSection = PresentationService.GetAll().Where(i => i.Id == id).First();
            return View(DeleteSection);
        }

        [HttpPost]
        public IActionResult Delete(Section section)
        {
            PresentationService.Delete(section);
            return RedirectToAction("Index");
        }









        [HttpGet]
        public IActionResult IndexParagraph(string id)
        {
            var Paragraphs = PresentationService.GetAllParagraphsBySectionId(id);
            ViewBag.SectionId = id;
            return View(Paragraphs);
        }





        [HttpGet]
        public IActionResult CreateParagraph(string id)
        {
            ViewBag.SectionId = id;
            return View();
        }

        [HttpPost]
        public IActionResult CreateParagraph(Paragraph paragraph ,string ID )
        {
            paragraph.SectionId = ID;
            PresentationService.InsertParagraph(paragraph, ID);
            return RedirectToAction("IndexParagraph", "PresentationCrud", new { id = ID });
        }



        [HttpGet]
        public IActionResult EditParagraph(string id)
        {
            var Deleteparagraph = PresentationService.GetAllParagraphs().Where(p => p.Id == id).First();
            ViewBag.SectionId = Deleteparagraph.SectionId;
            return View(Deleteparagraph);
        }

        [HttpPost]
        public IActionResult EditParagraph(Paragraph P)
        {
            var Editparagraph = PresentationService.GetAllParagraphs().Where(p => p.Id == P.Id).First();
            P.SectionId = Editparagraph.SectionId;
            PresentationService.UpdateParagraph(P);
            return RedirectToAction("IndexParagraph", "PresentationCrud", new { id = P.SectionId });
        }





        [HttpGet]
        public IActionResult DeleteParagraph(string id)
        {
            var Deleteparagraph = PresentationService.GetAllParagraphs().Where(p => p.Id == id).First();
            ViewBag.SectionId = Deleteparagraph.SectionId;
            return View(Deleteparagraph);
        }

        [HttpPost]
        public IActionResult DeleteParagraph(string ID,string somethingelse)
        {
            var Deleteparagraph = PresentationService.GetAllParagraphs().Where(p => p.Id == ID).First();
            ViewBag.SectionId = Deleteparagraph.SectionId;
            PresentationService.DeleteParagraph(Deleteparagraph);
            return RedirectToAction("IndexParagraph", "PresentationCrud", new { id = ViewBag.SectionId });
        }
    }
}
