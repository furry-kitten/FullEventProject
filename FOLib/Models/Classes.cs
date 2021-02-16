using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models
{
    public class Classes : DBClass
    {
        private Dancer dancer;
        private SHAClasses shaClasses;
        private byte points;

        public Classes()
        {
            //Name = $"{shaClasses.Name}{points}";
        }

        public Dancer Dancer
        {
            get => dancer;
            set { dancer = value; OnPropertyChanged(); }
        }
        public SHAClasses SHAClasses
        {
            get => shaClasses;
            set { shaClasses = value; OnPropertyChanged(); }
        }
        public byte Points
        {
            get => points;
            set { points = value; OnPropertyChanged(); }
        }
        public override string ToString() => Name;
    }
}
