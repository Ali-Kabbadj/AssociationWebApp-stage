using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models.Home;
using WebApplication1.Models.QuiSommeNous;

namespace WebApplication1.Services.MissionService
{
    public class MissionTaskService : IMissionSectionTaskService<MissionSection>
    {

        private readonly ApplicationDbContext db;
        public MissionTaskService(ApplicationDbContext context)
        {
            db = context;
        }

        public virtual IQueryable<MissionSection> GetAll()
        {
            IQueryable<MissionSection> MissionSection = db.ListSectionMission.Select(MissionSection => new MissionSection
            {
                Id= MissionSection.Id,
                Image = MissionSection.Image,
                Title = MissionSection.Title,
                SmallTitle = MissionSection.SmallTitle,
                Paragraph= MissionSection.Paragraph
            });
            return MissionSection;
        }


        public virtual void Insert(MissionSection MissionSection)
        {


            MissionSection.Id = Guid.NewGuid().ToString();
            db.ListSectionMission.Add(MissionSection);
                db.SaveChanges();
        }

        public virtual void Update(MissionSection MissionSection)
        {
                db.ListSectionMission.Attach(MissionSection);
                db.Entry(MissionSection).State = EntityState.Modified;
                db.SaveChanges();
        }


        public virtual void Delete(MissionSection MissionSection)
        {
            db.ListSectionMission.Attach(MissionSection);
            db.ListSectionMission.Remove(MissionSection);
            db.SaveChanges();
        }

    }
}
