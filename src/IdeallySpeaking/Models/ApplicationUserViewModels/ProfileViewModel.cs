using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models.ApplicationUserViewModels
{
    public class ProfileViewModel
    {
        public string UserName { get; set; }

        public string Url { get; set; }

        public IFormFile Avatar { get; set; }
    }
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
