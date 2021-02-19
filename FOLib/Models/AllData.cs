using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models
{
    /// <summary>
    /// Для обмена данными
    /// </summary>
    public sealed class AllData : BaseVM
    {
        private List<Person> people;
        private List<Dancer> dancers;
        private List<Activity> events;
        private List<GroupOfOrganiziers> groups;
        private List<SHAClasses> shaClasses;
        //private List<Classes> classes { get; set; }
        private List<Plan> plans;
        private List<LastEventsChanges> changes;


        public List<Person> People
        {
            get => people;
            set { people = value; OnPropertyChanged(); }
        }
        public List<Dancer> Dancers
        {
            get => dancers;
            set { dancers = value; OnPropertyChanged(); }
        }
        public List<Activity> Events
        {
            get => events;
            set { events = value; OnPropertyChanged(); }
        }
        public List<GroupOfOrganiziers> Groups
        {
            get => groups;
            set { groups = value; OnPropertyChanged(); }
        }
        public List<SHAClasses> SHAClasses
        {
            get => shaClasses;
            set { shaClasses = value; OnPropertyChanged(); }
        }
        //public List<Classes> Classes { get; set; }
        public List<Plan> Plans
        {
            get => plans;
            set { plans = value; OnPropertyChanged(); }
        }
        public List<LastEventsChanges> Changes
        {
            get => changes;
            set { changes = value; OnPropertyChanged(); }
        }
    }
}
