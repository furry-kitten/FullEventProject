using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models.Rules
{
    internal class TimerRule : BaseRule
    {
        private DateTime eventDate = DateTime.Now;
        private DateTime criticalEventDate = DateTime.Now;

        public TimerRule() : base() { }
        public TimerRule(string name, string decription) : base(name, decription) { }
        public TimerRule(string name, string decription, DateTime eventDate, DateTime criticalEventDate) : base(name, decription)
        {
            SetDateTime(eventDate, criticalEventDate);
        }
        public TimerRule(BaseRule baseRule, DateTime eventDate, DateTime criticalEventDate) : base(baseRule.Name, baseRule.Decription)
        {
            SetDateTime(eventDate, criticalEventDate);
        }

        public DateTime EventDate
        {
            get => eventDate;
            set { eventDate = value; OnPropertyChanged(); }
        }
        public DateTime CriticalEventDate
        {
            get => criticalEventDate;
            set { criticalEventDate = value; OnPropertyChanged(); }
        }

        private void SetDateTime(DateTime eventDate, DateTime criticalEventDate)
        {
            this.eventDate = eventDate;
            this.criticalEventDate = criticalEventDate;
        }
    }
}
