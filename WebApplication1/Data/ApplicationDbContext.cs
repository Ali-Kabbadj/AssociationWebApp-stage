using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.QuiSommeNous;
using WebApplication1.Models.QuiSommeNous.ArticlePresentation;
using WebApplication1.Data.AdminUserConfig;

namespace WebApplication1.Data
{
    public class ApplicationDbContext :  IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<HomeModel> HomeSlides { get; set; }
        public DbSet<Section> PresnetationPage { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }

        public DbSet<ApplicationUser> UserList { get; set; }
        public DbSet<Member> members { get; set; }

        public DbSet<MissionSection> ListSectionMission  { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Admin");



            builder.Entity<HomeModel>(entity =>
            {
                entity.ToTable("Slide").HasKey(i => i.Id);
                entity.ToTable("Slide").Ignore(i => i.ImageIForm);
            });




            builder.Entity<Section>(entity =>
            {
                entity.ToTable("Section").HasKey(i => i.Id);
            });




            builder.Entity<Paragraph>(entity =>
            {
                entity.ToTable("Paragraph").HasKey(i => i.Id);
            });

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new AdminConfiguration());
            builder.ApplyConfiguration(new UsersWithRolesConfig());
            
            builder.Entity<Paragraph>(entity =>
            {
                entity.HasKey(i => i.Id);
            });

            builder.Entity<Member>(entity =>
            {
                entity.HasKey(i => i.Id);
            });

            builder.Entity<MissionSection>(entity =>
            {
                entity.HasKey(i => i.Id);
            });
        }
    }
}
