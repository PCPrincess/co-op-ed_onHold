using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models.AccountViewModels
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

        public byte[] Avatar { get; set; }

        [InverseProperty("Author")]
        public List<Article> AuthoredArticles { get; }

        public List<Comment> AuthoredComments { get; }

        public List<Badge> Badges { get; }
    }
}
