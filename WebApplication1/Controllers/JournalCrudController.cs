using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models.TimeRelated;
using WebApplication1.Services.JournalService;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class JournalCrudController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly JournalTaskService JournalService;
        public JournalCrudController(ApplicationDbContext context)
        {
            _context = context;
            JournalService = new JournalTaskService(_context);

        }

        [HttpGet]
        public IActionResult Index()
        {

            var locations = JournalService.GetAll();

            return View(locations);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Journal journal)
        {
            if (journal != null)
            {
                using (var target = new MemoryStream())
                {
                    journal.IFormImage.CopyTo(target);
                    journal.Image = target.ToArray();
                }

                JournalService.Insert(journal);

            }
            return RedirectToAction("Index");
        }

      



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var journal = _context.Journals.Find(id);
            if (journal.Image!=null)
            {
            var stream = new MemoryStream(journal.Image);
            IFormFile file = new FormFile(stream, 0, journal.Image.Length, "name", "fileName");
            journal.IFormImage = file;
            }
            
            return View(journal);
        }


        [HttpPost]
        public IActionResult Edit(Journal journal)
        {
            var journalback = JournalService.GetAll().Where(i => i.Id == journal.Id).First();
            if (journal.IFormImage == null)
            {
                journal.Image = journalback.Image;
            }
            else
            {
                //Getting FileName
                var fileName = Path.GetFileName(journal.IFormImage.FileName);
                //Getting file Extension
                var fileExtension = Path.GetExtension(fileName);
                // concatenating  FileName + FileExtension
                var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);



                using var target = new MemoryStream();
                journal.IFormImage.CopyTo(target);
                journal.Image = target.ToArray();
            }
            journal.CreationDate = journalback.CreationDate;
            JournalService.Update(journal);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var journal = _context.Journals.Find(id);
            return View(journal);
        }

        [HttpPost]
        public IActionResult Delete(Journal journal)
        {
            JournalService.Delete(journal);
            return RedirectToAction("Index");
        }
    }
}
