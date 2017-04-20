using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models
{
    public class Badge
    {
        public int BadgeId { get; set; }

        [MinLength(3)]
        [MaxLength(150)]
        public string Caption { get; set; }
        
        public byte[] BadgeImage { get; set; }        

        [StringLength(50, ErrorMessage = "Name may have a maximum of 40 characters.")]
        public string Name { get; set; }

        [NotMapped]
        public Dictionary<Badge, string> BadgeAndImage { get; set; }
        
        public void AddBadgeAndImage(Badge badge, string imgPath)
        {
            BadgeAndImage.Add(badge, imgPath);
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
