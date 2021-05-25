using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using Project = WebApplication1.Models.Project;

namespace WebApplication1.Services.ProjectService
{
    public class ProjectTaskService : IProjectnTaskService<Project>
    {
        private readonly ApplicationDbContext db;

        public ProjectTaskService(ApplicationDbContext context)
        {
            db = context;
        }

        public virtual IQueryable<Project> GetAll()
        {
            IQueryable<Project> Projects = db.Projects.Select(Project => new Project
            {
                Id = Project.Id,
                Image = Project.Image,
                Title = Project.Title,
                SubTitle= Project.SubTitle,
                Description = Project.Description,
                FilePath = Project.FilePath
            }); 
            return Projects;
        }


        public virtual void Insert(Project Project)
        {
            db.Projects.Add(Project);
            db.SaveChanges();
        }

        public virtual void Update(Project Project)
        {
            db.Projects.Attach(Project);
            db.Entry(Project).State = EntityState.Modified;
            db.SaveChanges();
        }


        public virtual void Delete(Project Project)
        {
            db.Projects.Attach(Project);
            db.Projects.Remove(Project);
            db.SaveChanges();
        }

    }
}
