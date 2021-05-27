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
using WebApplication1.Models;
using WebApplication1.Services.PartnerService;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class PartnersCrudController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly PartnerTaskService PartnerService;
        private readonly IWebHostEnvironment _environment;

        public PartnersCrudController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
            PartnerService = new PartnerTaskService(_context);

        }


        [HttpGet]
        public IActionResult Index()
        {

            var Partners = PartnerService.GetAll();

            return View(Partners);
        }




        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Partner partner)
        {
            if (partner != null)
            {



                using (var target = new MemoryStream())
                {
                    partner.IFormImage.CopyTo(target);
                    partner.Image = target.ToArray();
                }

                PartnerService.Insert(partner);

            }
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var partner = _context.Partners.Find(id);
            var stream = new MemoryStream(partner.Image);
            IFormFile file = new FormFile(stream, 0, partner.Image.Length, "name", "fileName");
            partner.IFormImage = file;
            return View(partner);
        }


        [HttpPost]
        public IActionResult Edit(Partner partner)
        {
            if (partner.IFormImage == null)
            {
                partner.Image = PartnerService.GetAll().Where(i => i.Id == partner.Id).First().Image;
            }
            else
            {
                //Getting FileName
                var fileName = Path.GetFileName(partner.IFormImage.FileName);
                //Getting file Extension
                var fileExtension = Path.GetExtension(fileName);
                // concatenating  FileName + FileExtension
                var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);



                using var target = new MemoryStream();
                partner.IFormImage.CopyTo(target);
                partner.Image = target.ToArray();
            }
            PartnerService.Update(partner);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var partner = _context.Partners.Find(id);
            return View(partner);
        }

        [HttpPost]
        public IActionResult Delete(Partner partner)
        {
            PartnerService.Delete(partner);
            return RedirectToAction("Index");
        }
    }
}
