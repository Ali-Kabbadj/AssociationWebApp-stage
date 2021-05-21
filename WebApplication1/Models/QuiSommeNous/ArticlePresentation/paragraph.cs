﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.QuiSommeNous.ArticlePresentation
{
    public class Paragraph
    {
        [Key]
        public string Id { get; set; }
        public string ParagraphContent { get; set; }
    }
}
