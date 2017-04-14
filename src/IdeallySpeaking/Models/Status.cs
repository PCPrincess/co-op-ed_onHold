using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models
{
    public class Status
    {
        private UserStatus _userStatus;

        public Status(UserStatus userStatus)
        {
            _userStatus = userStatus;
        }                    

        public class UserStatus
        {
            public DateTime statusDate;

            public UserStatus(ApplicationUser appUser)
            {
                this.ApplicationUserStatus(appUser);
                statusDate = appUser.StatusChangeDate;
            }

            public DateTime CurrentDate
            {
                get { return DateTime.Now; }
            }

            public ApplicationUser ApplicationUser { get; set; }

            public bool ApplicationUserStatus(ApplicationUser applicationUser)
            {
                if (applicationUser.IsOnTimeOut)
                {
                    return true;
                }
                else if (applicationUser.IsEightySixed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public int PostStatus()
            {
                return (CurrentDate.Day - statusDate.Day);
            }

        } 
           
    }
}
