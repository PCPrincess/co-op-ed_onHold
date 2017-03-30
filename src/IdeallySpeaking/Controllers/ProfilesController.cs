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
    public class ProfilesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _environment;

        public ProfilesController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
            IHostingEnvironment environment)
        {
            _userManager = userManager;
            _context = context;
            _environment = environment;
        }

        // GET: /Profiles/Profile
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Profile(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var user = await _context.Profiles
                .SingleOrDefaultAsync(p => p.ApplicationUser.ApplicationUserId == id);
            if (user == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: /Profile/Profile
        // Next: Add Binds from Profile.cs
        [HttpPost]
        public async Task<IActionResult> Profile([Bind("UserName,Url,BadgeList,Avatar")] Profile userProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userProfile);

                await _context.SaveChangesAsync();
            }

            return View(userProfile);
        }

        // GET: /ApplicationUser/Edit
        public IActionResult Edit()
        {
            return View();
        }

        // POST: /Profile/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        /*  public async Task<IActionResult> Edit(int id, [Bind("UserName,Url,BadgeList,Avatar")] Profile userProfile)
          {
              if (id != userProfile.ApplicationUser.ApplicationUserId)
              {
                  return NotFound();
              }

              if (ModelState.IsValid)
              {
                  try
                  {
                      _context.Update(userProfile);
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
                  return RedirectToAction(nameof(Profile), "Profile");
              }
              return View(user);
          } */


        /* Possible For Avatar Upload [in: Profile.cs] */

        // GET: Profile/Avatar
        [AllowAnonymous]
        public IActionResult Avatar()
        {
            return View("Profile");
        }

        // POST: Profile/Avatar
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        /* public async Task<IActionResult> Avatar(ICollection<IFormFile> files)
         {
             var currUser = await GetCurrentUserAsync();
             if (!UserExists(currUser))
             {
                 return View("Profile");
             }
             else
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
             }            
             return View("Profile");
         } */


        /*public async Task<IActionResult> ListOfUsers()
          {
              List<ApplicationUser> users = await AllUsersList.UserList.ToListAsync();
              AllUsersList.UserTotal = users.Count();
              return View(users);
          }*/
        private bool UserExists(ApplicationUser currUser)
         {
             return _context.ApplicationUsers.Any(u => u.ApplicationUserId.Equals(currUser));
         } 

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

    }
}
