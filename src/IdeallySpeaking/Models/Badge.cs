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
        
        public Dictionary<Badge, string> BadgeAndImage { get; set; }

        public void AddBadgeAndImage(Badge badge, string imgUrl)
        {
            BadgeAndImage.Add(badge, imgUrl);
        }

        public void RemoveBadgeAndImage(Badge badge)
        {
            BadgeAndImage.Remove(badge);
        }

        public ApplicationUser ApplicationUser { get; set; }

        public class UserBadgeList
        {
            public UserBadgeList(ApplicationUser applicationUser)
            {
                applicationUser.BadgeList = new List<Badge>();                 
            }

            public void AddBadge(ApplicationUser applicationUser, Badge badge)
            {
                applicationUser.BadgeList.Add(badge);
            }

            public void RemoveBadge(ApplicationUser applicationUser, Badge badge)
            {
                applicationUser.BadgeList.Remove(badge);
            }
            
        }
    }
}
