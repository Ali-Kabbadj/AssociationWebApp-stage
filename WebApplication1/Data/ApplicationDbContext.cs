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

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<HomeModel> HomeSlides { get; set; }
        public DbSet<Section> PresnetationPage { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Admin");



            builder.Entity<HomeModel>(entity =>
            {
                entity.ToTable("Slides").HasKey(i => i.Id);
                entity.ToTable("Slides").Ignore(i => i.ImageIForm);
            });




            builder.Entity<Section>(entity =>
            {
                entity.ToTable("PresnetationSections").HasKey(i => i.Id);
            });




            builder.Entity<Paragraph>(entity =>
            {
                entity.ToTable("Paragraphs").HasKey(i => i.Id);
            });




           
        }
    }
}
