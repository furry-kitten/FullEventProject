using System;
using System.Collections.Generic;
using System.Linq;

namespace FO.Models
{
    public class GroupOfOrganiziers : DBClass
    {
        private List<Dancer> dancers;
        private List<Teacher> teachers;
        private Club club;

        public GroupOfOrganiziers() { }

        public GroupOfOrganiziers(string name, string comment) : base(name, comment)
        {
        }

        public Event Event { get; set; }
        public List<Dancer> Dancers
        {
            get => dancers;
            set { dancers = value; OnPropertyChanged(); }
        }
        public List<Teacher> Teachers
        {
            get => teachers;
            set { teachers = value; OnPropertyChanged(); }
        }
        public Club Club
        {
            get => club;
            set { club = value; OnPropertyChanged(); }
        }
        public Guid ClubId { get; set; }

        public List<Dancer> GetAllDancers()
        {
            var allDancers = new List<Dancer>(Dancers);
            var teachers = Teachers.Where(t => !allDancers.Contains(t.Dancer));

            foreach (var teacher in teachers)
                allDancers.Add(teacher.Dancer);

            return allDancers;
        }

        public override string ToString()
        {
            var allDancers = "";

            foreach (var dancer in Dancers)
            {
                allDancers += $"{dancer}";

                if (Dancers.Count > 1)
                    allDancers += "\n";
            }

            return $"Название:\t{Name}\n" +
                $"{allDancers}";
        }
    }
}
