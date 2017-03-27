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

        public bool IsOnTimeOut { get; set; }
        public bool IsEightySixed { get; set; }               

        public struct UserStatus
        {
            string Default;
            string OnTimeOut;
            string EightySixed;

            public UserStatus(string _default, string _onTimeOut, string _eightySixed) :this()
            {
                this.Default = _default;
                this.OnTimeOut = _onTimeOut;
                this.EightySixed = _eightySixed;
            }

            
        } 
           
    }
}
