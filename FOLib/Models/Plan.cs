using System;

namespace FO.Models
{
    public class Plan : DBClass
    {
        private Event @event;
        private DateTime
            startDate,
            endDate;

        public Event Event
        {
            get => @event;
            set { @event = value; OnPropertyChanged(); }
        }
        public DateTime StartDate
        {
            get => startDate;
            set { startDate = value; OnPropertyChanged(); }
        }
        public DateTime EndDate
        {
            get => endDate;
            set { endDate = value; OnPropertyChanged(); }
        }
    }
}
