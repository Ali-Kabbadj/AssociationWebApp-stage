using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Services.ProjectService;

namespace WebApplication1.Models
{
    public class Project : IProject
    {
        [Key]
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        [NotMapped]
        public IFormFile IFormImage { get; set; }
        [NotMapped]
        public IFormFile IFormFile { get; set; }
    }
}
