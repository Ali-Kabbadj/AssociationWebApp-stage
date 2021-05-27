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
using WebApplication1.Services.MemberService;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class MembersCrudController : Controller
    {


        private MemberTaskService membereService;
        private ApplicationDbContext _context;
        public MembersCrudController(ApplicationDbContext context)
        {
            _context = context;
            membereService = new MemberTaskService(_context);

        }


        public IActionResult Index()
        {
            var Members = membereService.GetAll();
            return View(Members);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Member member)
        {
            if (member != null)
            {



                using (var target = new MemoryStream())
                {
                    member.IFormImage.CopyTo(target);
                    member.Image = target.ToArray();
                }

                membereService.Insert(member);

            }
            return RedirectToAction("Index");
        }

  



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var EditMember = _context.members.Find(id);
            var stream = new MemoryStream(EditMember.Image);
            IFormFile file = new FormFile(stream, 0, EditMember.Image.Length, "name", "fileName");
            EditMember.IFormImage = file;
            return View(EditMember);
        }


        [HttpPost]
        public IActionResult Edit(Member member)
        {
            if (member.IFormImage == null)
            {
                member.Image = membereService.GetAll().Where(i => i.Id == member.Id).First().Image;
            }
            else
            {
                //Getting FileName
                var fileName = Path.GetFileName(member.IFormImage.FileName);
                //Getting file Extension
                var fileExtension = Path.GetExtension(fileName);
                // concatenating  FileName + FileExtension
                var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);



                using var target = new MemoryStream();
                member.IFormImage.CopyTo(target);
                member.Image = target.ToArray();
            }
            membereService.Update(member);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Deletemember = _context.members.Find(id);
            return View(Deletemember);
        }

        [HttpPost]
        public IActionResult Delete(Member member)
        {
            membereService.Delete(member);
            return RedirectToAction("Index");
        }
    }
}
