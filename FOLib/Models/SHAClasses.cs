using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models
{
    public class SHAClasses : DBClass
    {
        private string
            comment = string.Empty;
        private Direction direction;
        private byte totalPoints = 0,
            currentPoints;

        public SHAClasses()
        {

        }

        public Direction Direction
        {
            get => direction;
            set { direction = value; OnPropertyChanged(); }
        }
        public byte TotalPoints
        {
            get => totalPoints;
            set { totalPoints = value; OnPropertyChanged(); }
        }
    }
}
