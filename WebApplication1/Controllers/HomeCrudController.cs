using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.Home;
using WebApplication1.Services.HomeService;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class HomeCrudController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly HomeTaskService HomeService;
        private readonly IWebHostEnvironment _environment;
        public HomeCrudController(ApplicationDbContext context, IWebHostEnvironment environment)
        { 
            _context = context;
            _environment = environment;
            HomeService = new HomeTaskService(_context, _environment);
           
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HomeModel Slide)
        {
            if (Slide != null )
            {

 

                    using (var target = new MemoryStream())
                    {
                        Slide.ImageIForm.CopyTo(target);
                        Slide.Image = target.ToArray();
                    }

                HomeService.Insert(Slide);

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            var Slides = HomeService.GetAll();
          
            return View(Slides);
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var EditSlide = _context.HomeSlides.Find(id);
            var stream = new MemoryStream(EditSlide.Image);
            IFormFile file = new FormFile(stream, 0, EditSlide.Image.Length, "name", "fileName");
            EditSlide.ImageIForm = file;
            return View(EditSlide);
        }


        [HttpPost]
        public IActionResult Edit(HomeModel Slide)
        {
            if (Slide.ImageIForm == null)
            {
                Slide.Image = HomeService.GetAll().Where(i => i.Id == Slide.Id).First().Image;
            }
            else
            {
                //Getting FileName
                var fileName = Path.GetFileName(Slide.ImageIForm.FileName);
                //Getting file Extension
                var fileExtension = Path.GetExtension(fileName);
                // concatenating  FileName + FileExtension
                var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);



                using var target = new MemoryStream();
                Slide.ImageIForm.CopyTo(target);
                Slide.Image = target.ToArray();
            }
            HomeService.Update(Slide);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var DeleteSlide = _context.HomeSlides.Find(id);
            return View(DeleteSlide);
        }

        [HttpPost]
        public  IActionResult Delete( HomeModel Slide)
        {
            HomeService.Delete(Slide);
            return RedirectToAction("Index");
        }

    }
}
