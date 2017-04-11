using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models
{
    public class Status
    {
        private string _statusName;

        public Status(string statusName)
        {
            _statusName = statusName;
        }

        public DateTime DateSet { get; set; }
        public string Description { get; set; }               

        public class UserStatus
        {
            // create objects for IsOnTimeOut and IsEightySixed to use in DetermineStatus
            

            public UserStatus()
            {
                this.DetermineStatus();
            }

            public bool IsOnTimeOut { get; private set; }
            public bool IsEightySixed { get; private set; }

            public string DetermineStatus()
            {
                if (IsOnTimeOut)
                {
                    return "OnTimeOut";                       
                }
                else if (IsEightySixed)
                {
                    return "EightySixed";
                }
                else
                {
                    return "Default";
                }

            }   
            
        } 
           
    }
}
