using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services.MissionService
{
    public interface IMissionSection
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public string SmallTitle { get; set; }
        public string Paragraph { get; set; }
        public IFormFile IFormImage { get; set; }

    }
}
