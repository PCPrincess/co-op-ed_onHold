using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IdeallySpeaking.Models;
using Microsoft.AspNetCore.Identity;
using IdeallySpeaking.Data;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdeallySpeaking.Controllers
{    
    public class ApplicationUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ApplicationUserController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: /ApplicationUser/Profile
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Profile()
        {
            var user = await GetCurrentUserAsync();
            if (user == null) 
            {
                return View("Error");
            }
            
            return View();
        }

        // POST: /Applicationuser/Profile
        // Next: Add Binds from ApplicationUser.cs
        [HttpPost]
        public async Task<IActionResult> Profile([Bind()] ApplicationUser user)
        {
            var currUser = await GetCurrentUserAsync();           

            return View();
        }
        

        // GET: /ApplicationUser/Edit
        public IActionResult Edit()
        {
            return View();
        }

        // POST: /ApplicationUser/Edit



        /*
        IMPORTANT - Possible For Avatar Upload [in: ProfileController.cs]
        
        // GET: /Account/Profile/Avatar
        [AllowAnonymous]
        public ActionResult Avatar()
        {
            return View();
        }

        // POST: /Account/Profile/Avatar
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Avatar(ICollection<IFormFile> files)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            return View();
        }
    */

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}
