using IdeallySpeaking.Models.EventViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Services
{
    public class EventService
    {
        private readonly EventViewModel _model;
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
    }
}
