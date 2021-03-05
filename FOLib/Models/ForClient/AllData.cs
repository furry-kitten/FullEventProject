using FO.Models.Перечисления;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models.ForClient
{
    /// <summary>
    /// Для обмена данными
    /// </summary>
    public sealed class AllData : BaseVM
    {
        private List<Person> people = new List<Person>();
        private List<Dancer> dancers = new List<Dancer>();
        private List<Activity> activities = new List<Activity>();
        private List<GroupOfOrganiziers> groups = new List<GroupOfOrganiziers>();
        private List<SHAClasses> shaClasses = new List<SHAClasses>();
        //private List<Classes> classes { get; set; }
        private List<Plan> plans = new List<Plan>();
        private List<LastEventsChanges> changes = new List<LastEventsChanges>();
        private List<Club> clubs = new List<Club>();
        private List<Classes> classes = new List<Classes>();
        private List<NominationCompetitors> nominationCompetitors = new List<NominationCompetitors>();
        private List<Periodicity> periodicities = new List<Periodicity>();
        private List<Teacher> teachers = new List<Teacher>();


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
        public List<Activity> Activities
        {
            get => activities;
            set { activities = value; OnPropertyChanged(); }
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
        public List<Club> Clubs
        {
            get => clubs;
            set { clubs = value; OnPropertyChanged(); }
        }
        public List<Classes> Classes
        {
            get => classes;
            set { classes = value; OnPropertyChanged(); }
        }
        public List<NominationCompetitors> NominationCompetitors
        {
            get => nominationCompetitors;
            set { nominationCompetitors = value; OnPropertyChanged(); }
        }
        public List<Periodicity> Periodicities
        {
            get => periodicities;
            set { periodicities = value; OnPropertyChanged(); }
        }
        public List<Teacher> Teachers
        {
            get => teachers;
            set { teachers = value; OnPropertyChanged(); }
        }

        public void AddAllEventChanges(Event @event, Dictionary<Dancer, Dictionary<Direction, byte>> changes)
        {
            foreach (var dancerCganges in changes)
                AddEventChanges(@event, dancerCganges.Key, dancerCganges.Value);
        }
        public void AddEventChanges(Event @event, Dancer dancer, Dictionary<Direction, byte> changes)
        {
            var isClassesUpToNext = IsNewClass(dancer.Classes, changes);
            var classicPointAdded = changes.First(c => c.Key == Direction.Classic).Value;
            var jnjPointAdded = changes.First(c => c.Key == Direction.JnJ).Value;
            var isNextClassic = isClassesUpToNext.First(c => c.Key == Direction.Classic).Value;
            var isNextJnJ = isClassesUpToNext.First(c => c.Key == Direction.JnJ).Value;
            var newChanges = new LastEventsChanges
            {
                Event = @event,
                Dancer = dancer,
                ClassicPointAdded = classicPointAdded,
                JnJPointAdded = jnjPointAdded,
                NextClassicClass = isNextClassic,
                NextJnJClass = isNextJnJ
            };

            @event.LastEventsChanges.Add(newChanges);
            dancer.LastEventsChanges.Add(newChanges);

            var currentClassic = dancer.Classes.Find(c => c.SHAClasses.Direction == Direction.Classic);
            var currentJnJ = dancer.Classes.Find(c => c.SHAClasses.Direction == Direction.JnJ);

            if (isNextClassic)
                ChangeClass(currentClassic);
            if (isNextJnJ)
                ChangeClass(currentJnJ);

            CheckToChange(dancer);
        }

        private Dictionary<Direction, bool> IsNewClass(List<Classes> classes, Dictionary<Direction, byte> changes)
        {
            var nextClasses = new Dictionary<Direction, bool>();
            var currentClassic = classes.Find(c => c.SHAClasses.Direction == Direction.Classic);
            var currentJnJ = classes.Find(c => c.SHAClasses.Direction == Direction.JnJ);

            AddPoints(currentClassic, changes.First(c => c.Key == Direction.Classic).Value);
            AddPoints(currentJnJ, changes.First(c => c.Key == Direction.JnJ).Value);

            var nextClassic = IsUpped(currentClassic);
            var nextJnJ = IsUpped(currentJnJ);

            nextClasses.Add(Direction.JnJ, nextJnJ);
            nextClasses.Add(Direction.Classic, nextClassic);

            return nextClasses;
        }
        private void AddPoints(Classes currentClass, byte points) => currentClass.Points += points;
        private bool IsUpped(Classes currentClass) => currentClass.Points >= currentClass.SHAClasses.TotalPoints;
        private void ChangeClass(Classes currentClass)
        {
            var newSignificance = currentClass.SHAClasses.Significance + 1;
            var newCurrentClass = currentClass.SHAClasses;
            if (newSignificance <= 5)
                newCurrentClass = shaClasses
                    .Where(c => c.Significance == newSignificance)
                    .First(c => c.Direction == currentClass.SHAClasses.Direction);

            currentClass.SHAClasses = newCurrentClass;
            currentClass.Points = 0;
        }
        private void ChangeClass(Classes currentClass, int significance)
        {
            var newCurrentClass = shaClasses
                .Where(c => c.Significance == significance)
                .First(c => c.Direction == currentClass.SHAClasses.Direction);

            currentClass.SHAClasses = newCurrentClass;
        }
        private bool CheckToChange(Dancer dancer)
        {
            if(Math.Abs(dancer.Classes[0].SHAClasses.Significance - dancer.Classes[1].SHAClasses.Significance) > 1)
            {
                if (dancer.Classes[0].SHAClasses.Significance > dancer.Classes[1].SHAClasses.Significance)
                    ChangeClass(dancer.Classes[1], dancer.Classes[0].SHAClasses.Significance - 1);
                else
                    ChangeClass(dancer.Classes[0], dancer.Classes[1].SHAClasses.Significance - 1);

                return true;
            }

            return false;
        }
    }
}
