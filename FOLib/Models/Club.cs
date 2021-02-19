using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models
{
    public class Club : DBClass
    {
        private List<Dancer> teachers;
        private GroupOfOrganiziers group;

        public Club() : base()
        {

        }

        public List<Dancer> Teachers
        {
            get => teachers;
            set { teachers = value; OnPropertyChanged(); }
        }
        public GroupOfOrganiziers Group
        {
            get => group;
            set { group = value; OnPropertyChanged(); }
        }

        public void AddTeachersIntoGroup()
        {
            group.Dancers.AddRange(teachers.Where((d) => !group.Dancers.Contains(d)));
        }
    }
}
