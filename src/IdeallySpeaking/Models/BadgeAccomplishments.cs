using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models
{
    public class BadgeAccomplishments
    {            
        public Badge Badge { get; set; }

        public class AccomplishmentTriggers
        { // Base Class for Sender Object Classes

            public class CalendarBadge
            { // Sender Object Class

                public string SetBadgeLocale(string locale)
                {
                    this.BadgeLocale = locale;
                    return BadgeLocale;
                }

                public string BadgeLocale { get; set; }
                

                public event EventHandler PeriodOfTimeReached; // Event (message)

                protected virtual void OnPeriodOfTimeReached(EventArgs e)
                {// SENDER METHOD
                    PeriodOfTimeReached?.Invoke(this, e);
                    // Note: Delegate.Target { get; } Gets Target Class                    
                }
                // This Applies To All of These Event Sub-Classes:
                // RECEIVER METHODS (location: probably Controller) will be composed of:
                // An Object of the SENDER METHOD'S CLASS -and-
                // The RECEIVER METHOD ITSELF -and-
                // The Statement wherein the RECEIVER METHOD attaches '+=' to the newly created SENDER Class Object
                // Example:
                // class SomeClass ( -or- BadgeController.cs)
                // CalendarBadge calendarBadge = new CalendarBadge();
                // calendarBadge.PeriodOfTimeReached += RECEIVER METHOD;
                // Example RECEIVER METHOD:
                // static void c_PeriodOfTimeReached(object sender, EventArgs e)
                // {
                //   // Do Something:  
                // }
                
                // Note: Re-Read Events and Event-Handling Section in Spec!  

            }

            public class CommentBadge
            { // Sender Object Class
                public event EventHandler NumCommentsReached; // Event (message)

                protected virtual void OnNumOfCommentsReached(EventArgs e)
                {// SENDER METHOD
                    NumCommentsReached?.Invoke(this, e);
                }

            }

            public class Star10Badge // Temp Name
            { // Sender Object Class
                public event EventHandler TenStarsReached; // Event (message)

                protected virtual void OnTenStarsReached(EventArgs e)
                {// SENDER METHOD
                    TenStarsReached?.Invoke(this, e);
                }

            }

        }
    }
}
