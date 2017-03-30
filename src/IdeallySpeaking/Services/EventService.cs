using IdeallySpeaking.Models.EventViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Services
{
    public class EventService : IEventSchedule
    {
        private readonly EventViewModel _model;
        public int idForEvent = 0;
        public EventService(EventViewModel model)
        {
            _model = model;
        }

        public int DaysToGo()
        {
            var startDate = DateTime.Now.Day;
            var endDate = _model.EventDate.Day;

            return (startDate - endDate);
        }

        public Task ScheduleEvent()
        {
            // Add a Task to 'Bind' input from a Form(?) to a
            // _model for all EventViewModel Properties
            {
                _model.EventId = ++idForEvent;
                // (Cont. Here)
            }
            return Task.FromResult(0);
        }
    }
}
