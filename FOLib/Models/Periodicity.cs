using System;

namespace FO.Models
{
    public class Periodicity : DBClass
    {
        private int value;
        private PeriodicityTypes periodicityType;

        public int Value
        {
            get => value;
            set { this.value = value; OnPropertyChanged(); }
        }
        public PeriodicityTypes PeriodicityType
        {
            get => periodicityType;
            set { periodicityType = value; OnPropertyChanged(); }
        }
        public Event Event { get; set; }

        public DateTime ChangeEventDate(DateTime date)
        {
            switch (periodicityType)
            {
                case Periodicity.PeriodicityTypes.Day:
                    return date.AddDays(value);
                case Periodicity.PeriodicityTypes.Week:
                    return date.AddDays(value * 7);
                case Periodicity.PeriodicityTypes.Month:
                    return date.AddMonths(value);
                case Periodicity.PeriodicityTypes.Year:
                    return date.AddYears(value);
                default:
                    return date;
            }
        }

        public enum PeriodicityTypes
        {
            Day,
            Week,
            Month,
            Year
        }
    }
}
