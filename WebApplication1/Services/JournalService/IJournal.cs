using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services.JournalService
{
    public interface IJournal
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string Paragraph { get; set; }
        public byte[] Image { get; set; }
        public IFormFile IFormImage { get; set; }
    }
}
