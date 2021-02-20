using EDirection = FO.Models.Перечисления.Direction;

namespace FO.Models
{
    public class SHAClasses : DBClass
    {
        private EDirection direction;
        private byte totalPoints = 0;
        private int significance;

        public SHAClasses()
        {

        }
        public SHAClasses(EDirection direction, string name, byte points, string comment = "") : base(name, comment)
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

        public EDirection Direction
        {
            get => direction;
            set { direction = value; OnPropertyChanged(); }
        }
        public byte TotalPoints
        {
            get => totalPoints;
            set { totalPoints = value; OnPropertyChanged(); }
        }
        public int Significance
        {
            get => significance;
            set { significance = value; OnPropertyChanged(); }
        }

        public override string ToString()
        {
            var comment = string.Empty;

            if (!string.IsNullOrWhiteSpace(Comment))
                comment = $"\n{Comment}";

            return $"Название:\t\t{Name}\n" +
                $"Направление:\t\t{direction}\n" +
                $"Количество баллов:\t{totalPoints}" +
                $"{comment}";
        }
    }
}
