namespace FO.Models
{
    public class LastEventsChanges : DBClass
    {
        private Event @event;
        private Dancer dancer;
        private byte
            jnjPointAdded = 0,
            classicPointAdded = 0;
        private bool
            nextJnJClass = false,
            nextClassicClass = false;

        public LastEventsChanges() { }

        public Event Event
        {
            get => @event;
            set { @event = value; OnPropertyChanged(); }
        }
        public Dancer Dancer
        {
            get => dancer;
            set { dancer = value; OnPropertyChanged(); }
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
