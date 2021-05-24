using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models.QuiSommeNous;

namespace WebApplication1.Services.MemberService
{
    public class MemberTaskService : IMemberTaskService<Member>
    {

        private readonly ApplicationDbContext db;
        public MemberTaskService(ApplicationDbContext context)
        {
            db = context;
        }

        public virtual IQueryable<Member> GetAll()
        {
            IQueryable<Member> members = db.members.Select(member => new Member
            {
                Id = member.Id,
                Image = member.Image,
                FirsName = member.FirsName,
                LastName = member.LastName,
                ProfitionOrOrganization = member.ProfitionOrOrganization,
                Description =member.Description
            });
            return members;
        }


        public virtual void Insert(Member member)
        {


            member.Id = Guid.NewGuid().ToString();
            db.members.Add(member);
            db.SaveChanges();
        }

        public virtual void Update(Member member)
        {
            db.members.Attach(member);
            db.Entry(member).State = EntityState.Modified;
            db.SaveChanges();
        }


        public virtual void Delete(Member member)
        {
            db.members.Attach(member);
            db.members.Remove(member);
            db.SaveChanges();
        }

 
    }
}
