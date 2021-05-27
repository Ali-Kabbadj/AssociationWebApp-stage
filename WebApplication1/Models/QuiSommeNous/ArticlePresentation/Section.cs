using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Services.PresentationService;

namespace WebApplication1.Models.QuiSommeNous.ArticlePresentation
{
    public class Section : IPresentation
    {
        [Key]
        public int Id { get; set; }
        public List<Paragraph> ListOfParagraphs { get; set; }


        public byte[] Image { get; set; }
        public string Text { get; set; }

        [NotMapped]
        public virtual IFormFile ImageIForm { get; set; }
    }
}
