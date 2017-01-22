﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models
{
    public class Badge
    {
        public int BadgeId { get; set; }

        public byte[] BadgeImage { get; set; }

        public string Caption { get; set; }

        public string Path { get; set; }

        public string Name { get; set; }

        public int ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public class UserBadgeList
        {
            public UserBadgeList(ApplicationUser applicationUser, Badge badge)
            {
                badge.ApplicationUserId = applicationUser.ApplicationUserId;
                BadgeList.Add(badge);
            }

            public IList<Badge> BadgeList { get; set; }
        }
    }
}