using System.Collections.Generic;
using System.Linq;

namespace FO.Models
{
    public class Club : DBClass
    {
        private List<Dancer> membership = new List<Dancer>();
        private GroupOfOrganiziers group;
        private List<Teacher> teachers = new List<Teacher>();

        public Club() : base()
        {

        }
        public Club(string name, string comment) : base(name, comment)
        {
            group = new GroupOfOrganiziers(name, string.Empty);
        }

        public List<Dancer> Membership
        {
            get => membership;
            set { membership = value; OnPropertyChanged(); }
        }
        public List<Teacher> Teachers
        {
            get => teachers;
            set { teachers = value; OnPropertyChanged(); }
        }
        public GroupOfOrganiziers Group
        {
            get => group;
            set { group = value; OnPropertyChanged(); }
        }

        public List<Dancer> GetAllDancers()
        {
            var dancers = new List<Dancer>(membership);
            var teachers = NewListDancer(this.teachers);

            foreach (var dancer in teachers)
                if (dancers.Contains(dancer))
                    dancers.Add(dancer);

            dancers.OrderBy(d => d.Person.Name);

            return dancers;
        }

        private List<Dancer> NewListDancer(List<Teacher> teachers)
        {
            var dancers = new List<Dancer>();

            foreach (var teacher in teachers)
                    dancers.Add(teacher.Dancer);

            return dancers;
        }
    }
}
