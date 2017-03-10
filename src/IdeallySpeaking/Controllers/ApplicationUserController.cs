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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using IdeallySpeaking.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdeallySpeaking.Controllers
{    
    public class ApplicationUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _environment;
        private ProfileService _profile;

        public ApplicationUserController(
            UserManager<ApplicationUser> userManager, 
            ApplicationDbContext context,
            IHostingEnvironment environment,
            ProfileService profile)
        {
            _userManager = userManager;
            _context = context;
            _environment = environment;
            _profile = profile;
        }

        // GET: /ApplicationUser/Profile
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Profile(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var user = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.ApplicationUserId == id);
            if (user == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: /Applicationuser/Profile
        // Next: Add Binds from ApplicationUser.cs
        [HttpPost]
        public async Task<IActionResult> Profile([Bind("ApplicationUserId,UserName,Url,BadgeList,Avatar")] ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);

                await _context.SaveChangesAsync();
            }            

            return View(user);
        }   

        // GET: /ApplicationUser/Edit
        public IActionResult Edit()
        {
            return View();
        }

        // POST: /ApplicationUser/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationUserId,UserName,Url,BadgeList,Avatar")] ApplicationUser user)
        {
            if (id != user.ApplicationUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var currUser = await _userManager.FindByNameAsync(user.UserName);
                    if (!UserExists(currUser))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Profile");
            }
            return View(user);
        }


        /* Possible For Avatar Upload [in: ApplicationUserController.cs] */

        // GET: /Account/Profile/Avatar
        [AllowAnonymous]
        public ActionResult Avatar()
        {
            return View("Profile");
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
                await _context.SaveChangesAsync();
            }
            return View("Profile");
        }
    

        private bool UserExists(ApplicationUser currUser)
        {
            return _context.ApplicationUser.Any(u => u.ApplicationUser.Equals(currUser));
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}
