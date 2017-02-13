using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IdeallySpeaking.Models;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdeallySpeaking.Controllers
{
    public class ISUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ISUserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }



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
    }
}
