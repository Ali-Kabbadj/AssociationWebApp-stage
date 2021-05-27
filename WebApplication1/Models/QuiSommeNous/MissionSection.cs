using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Services.MissionService;

namespace WebApplication1.Models.QuiSommeNous
{
    public class MissionSection : IMissionSection
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public string SmallTitle { get; set; }
        public string Paragraph { get; set; }
        [NotMapped]
        public IFormFile IFormImage { get; set; }
    }
}
