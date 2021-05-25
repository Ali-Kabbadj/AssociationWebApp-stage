using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Services.PartnerService;

namespace WebApplication1.Models
{
    public class Partner: IPartner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Byte[] Image { get; set; }
        [NotMapped]
        public IFormFile IFormImage { get; set; }
    }
}
