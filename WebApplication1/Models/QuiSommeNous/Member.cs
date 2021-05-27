using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Services.HomeService;
using WebApplication1.Services.MemberService;

namespace WebApplication1.Models.QuiSommeNous
{
    public class Member : IMember
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string ProfitionOrOrganization { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public virtual IFormFile IFormImage { get; set; }
    }
}
