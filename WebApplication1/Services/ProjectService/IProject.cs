using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services.ProjectService
{
    public interface IProject
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public IFormFile IFormImage { get; set; }
        public IFormFile IFormFile { get; set; }
    }
}
