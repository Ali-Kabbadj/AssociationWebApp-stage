using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Services.HomeService;

namespace WebApplication1.Models.Home
{
    public class HomeModel : IHome
    {
        [Key]
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual IFormFile ImageIForm { get; set; }
    }
}
