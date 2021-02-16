using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models
{
    public class SHAClasses : DBClass
    {
        private Direction direction;
        private byte totalPoints = 0;

        public SHAClasses()
        {

        }
        public SHAClasses(Direction direction, string name, byte points, string comment = "") : base(name, comment)
        {
            this.direction = direction;
            totalPoints = points;
        }
        public SHAClasses(SHAClasses classes, byte criticalPoints)
        {
            Name = classes.Name;
            Comment = classes.Comment;
            direction = classes.Direction;
            totalPoints = criticalPoints;
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
