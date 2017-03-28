using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models
{
    public class Badge
    {
        public int BadgeId { get; set; }        

        public string Caption { get; set; }

        public string Path { get; set; }

        public string Name { get; set; }        

        public ApplicationUser ApplicationUser { get; set; }

        public class UserBadgeList
        {
            public UserBadgeList(ApplicationUser applicationUser, Badge badge)
            {
                applicationUser.BadgeList.Add(badge);                
            }
            
        }
    }
}
