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
using WebApplication1.Services.ProjectService;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ProjectsCrudController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnv;
        private readonly ApplicationDbContext _context;
        private readonly ProjectTaskService ProjectService;
        public ProjectsCrudController(IWebHostEnvironment hostingEnv,ApplicationDbContext context)
        {
            _hostingEnv = hostingEnv;
            _context = context;
            ProjectService = new ProjectTaskService(_context);

        }


        [HttpGet]
        public IActionResult Index()
        {

            var Projects = ProjectService.GetAll();

            return View(Projects);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Project Project)
        {

           
                
            if (Project.IFormFile != null && Project.IFormImage!=null)
            {

                //upload files to wwwroot
               

                var fileName1 = System.IO.Path.GetFileName(Project.IFormFile.FileName);
                var filePath1 = System.IO.Path.Combine( _hostingEnv.WebRootPath, "Projects", fileName1);
                using (var fileStream = new FileStream(filePath1, FileMode.Create))
                {
                    await Project.IFormFile.CopyToAsync(fileStream);
                }
                Project.FilePath = fileName1;

                using (var target = new MemoryStream())
                {
                    Project.IFormImage.CopyTo(target);
                    Project.Image = target.ToArray();
                }
                ProjectService.Insert(Project);
            }
            return RedirectToAction("Index");
        }

     



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Project = _context.Projects.Find(id);
            var stream = new MemoryStream(Project.Image);
            IFormFile file = new FormFile(stream, 0, Project.Image.Length, "name", "fileName");
            Project.IFormImage = file;
            return View(Project);
        }


        [HttpPost]
        public IActionResult Edit(Project Project)
        {
            if (Project.IFormImage == null)
            {
                Project.Image = ProjectService.GetAll().Where(i => i.Id == Project.Id).First().Image;
            }
            else
            {
                //Getting FileName
                var fileName = Path.GetFileName(Project.IFormImage.FileName);
                //Getting file Extension
                var fileExtension = Path.GetExtension(fileName);
                // concatenating  FileName + FileExtension
                var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);



                using var target = new MemoryStream();
                Project.IFormImage.CopyTo(target);
                Project.Image = target.ToArray();
            }


            if (Project.IFormFile!=null)
            {
                var fileName = Path.GetFileName(Project.IFormFile.FileName);
                //judge if it is pdf file
                string ext = Path.GetExtension(Project.IFormFile.FileName);
                var filePath = Path.Combine(_hostingEnv.WebRootPath, "Projects", fileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    Project.IFormFile.CopyToAsync(fileSteam);
                }
                Project.FilePath = filePath;
            }
            else
            {
                Project.FilePath= ProjectService.GetAll().Where(i => i.Id == Project.Id).First().FilePath;
            }
            ProjectService.Update(Project);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {

            var Project = _context.Projects.Find(id);
            return View(Project);
        }

        [HttpPost]
        public IActionResult Delete(Project Project)
        {
            string fullPath = Path.Combine(_hostingEnv.WebRootPath, "Projects", ProjectService.GetAll().Where(i => i.Id == Project.Id).First().FilePath);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            ProjectService.Delete(Project);
            return RedirectToAction("Index");
        }

    }
}
