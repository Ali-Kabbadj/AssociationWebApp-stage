using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.QuiSommeNous.ArticlePresentation;

namespace WebApplication1.Services.PresentationService
{
    public interface IPresentation
    {
        public string Id { get; set; }
        public List<Paragraph> ListOfParagraphs { get; set; }

        public byte[] Image { get; set; }
        public string Text { get; set; }

        public  IFormFile ImageIForm { get; set; }

    }
}
