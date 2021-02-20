using System.Collections.Generic;

namespace FO.Models
{
    public class Teacher : DBClass
    {
        private Dancer dancer;
        private List<GroupOfOrganiziers> groups = new List<GroupOfOrganiziers>();
        private List<Club> clubs = new List<Club>();

        public List<Club> Clubs
        {
            get => clubs;
            set { clubs = value; OnPropertyChanged(); }
        }
        public List<GroupOfOrganiziers> Groups
        {
            get => groups;
            set { groups = value; OnPropertyChanged(); }
        }
        public Dancer Dancer
        {
            get => dancer;
            set { dancer = value; OnPropertyChanged(); }
        }
    }
}
