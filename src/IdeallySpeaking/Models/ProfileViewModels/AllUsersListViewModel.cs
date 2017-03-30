using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models.ProfileViewModels
{
    public class AllUsersListViewModel
    {
        [Display(Name = "Ideally Speaking Users")]
        public List<ApplicationUser> UserList { get; set; }

        public int UserTotal { get; set; }
    }
}
