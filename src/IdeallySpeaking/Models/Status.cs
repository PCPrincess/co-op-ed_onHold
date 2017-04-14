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
            }
            
            public DateTime CurrentDate
            {
                get { return DateTime.Now; }
            }

            public int GetNumDays(int numDays)
            {
                PostStatus(ref numDays);
                return numDays;
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

            // May Want To Put in Controller
            public void PostStatus(ref int numDays)
            {
                try
                {                    
                    numDays = CurrentDate.Day - statusDate.Day;                    
                }
                catch(Exception e)
                {
                    if (numDays < 0)
                    {
                        e = new Exception("The number of days passed should always be positive.");
                    }
                }                
                
            }

        } 
           
    }
}
