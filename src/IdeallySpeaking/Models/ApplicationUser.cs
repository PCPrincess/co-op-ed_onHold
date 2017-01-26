using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IdeallySpeaking.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int ApplicationUserId { get; internal set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get { return (FirstName + " " + LastName); } }

        public new string UserName { get; set; }

        public DateTime JoinDate { get; private set; }

        public string Url { get; set; }
        
    }
}
