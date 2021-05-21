using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers.QuiSommeNous
{
    public class PresentationController : Controller
    {
        public IActionResult Presentation()
        {
            return View();
        }
    }
}
