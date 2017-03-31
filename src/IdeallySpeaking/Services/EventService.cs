using IdeallySpeaking.Models.EventViewModels;
using Microsoft.AspNetCore.Mvc;
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

        public DateTime StartDate()
        {
            return DateTime.Now;
        }

        public Task ScheduleEvent()
        {            
            _model.EventId = ++idForEvent;
            _model.EventDate = StartDate();
            return Task.FromResult(0);
        }
    }
}
