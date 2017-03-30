using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace IdeallySpeaking.Models.ApplicationUserViewModels
{
    public class ProfileEditViewModel
    {
        public int ProfileId { get; private set; }

        [Display(Name = "Edit UserName")]
        [RegularExpression(@"^[a-zA-Z]+[_]?\s*$", ErrorMessage = "Username can contain alphabetical characters and may contain an underscore.")]
        [MinLength(3)]
        [MaxLength(16)]
        public string UserName { get; set; }

        [Display(Name = "Edit Location")]
        [StringLength(50, ErrorMessage = "Location may have a maximum of 50 characters.")]
        public string Location { get; set; }

        [Display(Name = "Edit Signature")]
        [MaxLength(180, ErrorMessage = "Signatures may have a maximum of 180 characters.")]
        public string Signature { get; set; }

        [Url]
        [Display(Name = "Personal Link")]
        public string Link { get; set; }

        [Display(Name = "Upload New Avatar")]
        public IFormFile Avatar { get; set; }

        [Display(Name = "Facebook")]
        [Url]
        public string Facebook { get; set; }

        [Display(Name = "Twitter")]
        [Url]
        public string Twitter { get; set; }
    }
}
