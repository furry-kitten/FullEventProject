using FO.Models.Перечисления;

using System.Collections.Generic;

using EDirection = FO.Models.Перечисления.Direction;

namespace FO.Models
{
    public class Nomination : DBClass
    {
        private decimal? price;
        private EDirection direction;
        private NominationType type;

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
        public NominationType Type
        {
            get => type;
            set { type = value; OnPropertyChanged(); }
        }
    }
}
