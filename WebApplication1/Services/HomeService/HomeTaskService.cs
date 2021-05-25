using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VirtualClinic.Classes.UploadFiles;
using WebApplication1.Data;
using WebApplication1.Models.Home;

namespace WebApplication1.Services.HomeService
{
    public class HomeTaskService : IHomeTaskService<HomeModel>
    {

        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment _environment;
        public HomeTaskService(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            db = context;
            _environment = environment;
        }

        public virtual IQueryable<HomeModel> GetAll()
        {
            IQueryable<HomeModel> Slides = db.HomeSlides.Select(Slide => new HomeModel
            {
                Id=Slide.Id,
                Image =Slide.Image,
                Title =Slide.Title,
                Description =Slide.Description
            });
            return Slides;
        }


        public virtual void Insert(HomeModel Slide)
        {


            Slide.Id = Guid.NewGuid().ToString();
            db.HomeSlides.Add(Slide);
                db.SaveChanges();
        }

        public virtual void Update(HomeModel Slide)
        {
                db.HomeSlides.Attach(Slide);
                db.Entry(Slide).State = EntityState.Modified;
                db.SaveChanges();
        }


        public virtual void Delete(HomeModel Slide)
        {
            db.HomeSlides.Attach(Slide);
            db.HomeSlides.Remove(Slide);
            db.SaveChanges();
        }

        private bool ValidateModel(HomeModel Slide)
        {
            //Test Doctor model state here
            return true;
        }
    }
}
