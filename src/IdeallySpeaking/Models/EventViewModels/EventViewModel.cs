using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models.EventViewModels
{
    public class EventViewModel
    {
        public int EventId { get; set; }

        public string EventName { get; set; }

        public string EventDescription { get; set; }

        public DateTime EventDate { get; set; }

        public ApplicationUser EventOrganizer { get; set; }

        public IEnumerable<ApplicationUser> Participants { get; set; }
    }
}
