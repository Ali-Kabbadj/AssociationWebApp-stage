using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services.MemberService
{
    public interface IMember
    {
        public string Id { get; set; }
        public byte[] Image { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string ProfitionOrOrganization { get; set; }
        public string Description { get; set; }
        public  IFormFile IFormImage { get; set; }

    }
}
