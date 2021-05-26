using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Services.JournalService;

namespace WebApplication1.Models.TimeRelated
{
    public class Journal :IJournal
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string Paragraph { get; set; }
        public byte[] Image { get; set; }
        [NotMapped]
        public IFormFile IFormImage { get; set; }
    }
}
