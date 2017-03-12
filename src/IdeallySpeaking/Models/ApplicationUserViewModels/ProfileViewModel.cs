using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models.ApplicationUserViewModels
{
    
    public class ProfileViewModel
    {
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Last name must be alpha characters only.")]
        [MinLength(3)]
        [MaxLength(16)]        
        public string UserName { get; set; }

        [Display(Name = "Joined")]
        public DateTime JoinDate { get; private set; }

        [Url]
        [Display(Name = "Personal Link")]
        public string Link { get; set; }

        [MaxLength(180, ErrorMessage = "Signatures may have a maximum of 180 characters.")]
        public string Signature { get; set; }

        public IFormFile Avatar { get; set; }

        public List<Badge> BadgeList { get; set; }

        

        

        

    }
}


