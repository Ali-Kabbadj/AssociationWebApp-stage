using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Data.AdminUserConfig;

namespace WebApplication1.Controllers.Admin
{
    public class AdminController : Controller
    {


        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AdminController> _logger;
        private readonly IWebHostEnvironment _environment;
        private readonly ApplicationDbContext _db;

        public AdminController(
                                UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                ILogger<AdminController> logger,
                                IWebHostEnvironment environment,
                                ApplicationDbContext context
                                    )
        {
            _db = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _environment = environment;
        }




        [Authorize(Roles = "Administrator")]
        public IActionResult pages()
        {
            return View();
        }

        
        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Pages");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(ApplicationUser login)
        {
            
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByEmailAsync(login.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.Result.UserName, login.Password,isPersistent:false ,lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Pages");
                    }
                }
            }

            return View(login);

        }


        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
