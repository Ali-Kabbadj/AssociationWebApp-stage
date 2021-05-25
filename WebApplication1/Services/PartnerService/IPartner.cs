using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services.PartnerService
{
    public interface IPartner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Byte[] Image { get; set; }
        public IFormFile IFormImage { get; set; }

    }
}
