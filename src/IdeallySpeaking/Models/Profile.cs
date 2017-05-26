using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models
{    
    public class Profile
    {
        public int ProfileId { get; set; }

        [RegularExpression(@"^[a-zA-Z]+[_]?\s*$", ErrorMessage = "Username can contain alphabetical characters and may contain an underscore.")]
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

        [StringLength(50, ErrorMessage = "Location may have a maximum of 50 characters.")]
        public string Location { get; set; }

        [NotMapped]
        public byte[] Avatar { get; set; }

        [Display(Name = "Facebook")]
        [Url]
        public string Facebook { get; set; }

        [Display(Name = "Twitter")]
        [Url]
        public string Twitter { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public List<Badge> BadgeList { get; set; }

        public List<Comment> UserCommentList { get; private set; }
        
        public List<Article> AuthoredArticles { get; private set; }  


    }
}


