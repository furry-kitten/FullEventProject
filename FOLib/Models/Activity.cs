using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models
{
    public class Activity : BaseVM
    {
        private Event @event;
        private Rule rules;

        public Activity()
        {
            @event = new Event();
        }

        public Event Event
        {
            get => @event;
            set { @event = value; OnPropertyChanged(); }
        }
        public Rule Rules
        {
            get => rules;
            set { rules = value; OnPropertyChanged(); }
        }

        public void ChangeRules()
        {
            rules.ChangeToNextDate(@event.Periodicity);
        }
    }
}
