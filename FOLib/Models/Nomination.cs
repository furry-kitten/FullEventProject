using EDirection = FO.Models.Перечисления.Direction;

namespace FO.Models
{
    public class Nomination : DBClass
    {
        private decimal? price;
        private EDirection direction;

        public Nomination() : base() { }
        public Nomination(string name, decimal price, string comment) : base(name, comment)
        {
            this.price = price;
        }

        public decimal? Price
        {
            get => price;
            set { price = value; OnPropertyChanged(); }
        }
        public EDirection Direction
        {
            get => direction;
            set { direction = value; OnPropertyChanged(); }
        }
    }
}
