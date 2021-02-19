using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models
{
    public class LastEventsChanges : DBClass
    {
        private List<Event> events = new List<Event>();
        private List<Dancer> dancers = new List<Dancer>();
        private byte
            jnjPointAdded = 0,
            classicPointAdded = 0;
        private bool
            nextJnJClass = false,
            nextClassicClass = false;

        public List<Event> Events
        {
            get => events;
            set { events = value; OnPropertyChanged(); }
        }
        public List<Dancer> Dancers
        {
            get => dancers;
            set { dancers = value; OnPropertyChanged(); }
        }
        public byte JnJPointAdded
        {
            get => jnjPointAdded;
            set { jnjPointAdded = value; OnPropertyChanged(); }
        }
        public byte ClassicPointAdded
        {
            get => classicPointAdded;
            set { classicPointAdded = value; OnPropertyChanged(); }
        }
        public bool NextJnJClass
        {
            get => nextJnJClass;
            set { nextJnJClass = value; OnPropertyChanged(); }
        }
        public bool NextClassicClass
        {
            get => nextClassicClass;
            set { nextClassicClass = value; OnPropertyChanged(); }
        }

    }
}
