using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models.QuiSommeNous;
using WebApplication1.Services.MissionService;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class NotreMissionCrudController : Controller
    {
       
        private readonly ApplicationDbContext _context;
        private readonly MissionTaskService MissionService;
        public NotreMissionCrudController(ApplicationDbContext context)
        {
            _context = context;
            MissionService = new MissionTaskService(_context);

        }




        [HttpGet]
        public IActionResult Index()
        {

            var MissionSections = MissionService.GetAll();

            return View(MissionSections);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MissionSection MissionSection)
        {
            if (MissionSection != null)
            {

                using (var target = new MemoryStream())
                {
                    MissionSection.IFormImage.CopyTo(target);
                    MissionSection.Image = target.ToArray();
                }
                MissionService.Insert(MissionSection);
            }
            return RedirectToAction("Index");
        }

     



        [HttpGet]
        public IActionResult Edit(string id)
        {
            var MissionSection = _context.ListSectionMission.Find(id);
            var stream = new MemoryStream(MissionSection.Image);
            IFormFile file = new FormFile(stream, 0, MissionSection.Image.Length, "name", "fileName");
            MissionSection.IFormImage = file;
            return View(MissionSection);
        }


        [HttpPost]
        public IActionResult Edit(MissionSection MissionSection)
        {
            if (MissionSection.IFormImage == null)
            {
                MissionSection.Image = MissionService.GetAll().Where(i => i.Id == MissionSection.Id).First().Image;
            }
            else
            {
                //Getting FileName
                var fileName = Path.GetFileName(MissionSection.IFormImage.FileName);
                //Getting file Extension
                var fileExtension = Path.GetExtension(fileName);
                // concatenating  FileName + FileExtension
                var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);



                using var target = new MemoryStream();
                MissionSection.IFormImage.CopyTo(target);
                MissionSection.Image = target.ToArray();
            }
            MissionService.Update(MissionSection);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Delete(string id)
        {
            var MissionSection = _context.ListSectionMission.Find(id);
            return View(MissionSection);
        }

        [HttpPost]
        public IActionResult Delete(MissionSection MissionSection)
        {
            MissionService.Delete(MissionSection);
            return RedirectToAction("Index");
        }




    }
}
