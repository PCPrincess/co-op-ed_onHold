using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models.ISUserViewModels
{
    public class ProfileViewModel
    {
        [Display(Name = "First name")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "First name must be alpha characters only.")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Last name must be alpha characters only.")]
        public string LastName { get; set; }

        public DateTime JoinDate { get; private set; }

        public string Url { get; set; }

        public IFormFile Avatar { get; set; }        

        [InverseProperty("Author")]
        public List<Article> AuthoredArticles { get; }

        public List<Comment> AuthoredComments { get; }

        public List<Badge> Badges { get; }
    }
}
/*
        IMPORTANT - Possible For Avatar Upload [in: ISUserController.cs]
        
        // GET: /ISUser/Avatar
        [AllowAnonymous]
        public ActionResult PhotoUpload()
        {
            return View();
        }

        // POST: /ISUser/Avatar
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PhotoUpload(ICollection<IFormFile> files)
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
