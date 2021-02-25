using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models
{
    public class SkatingSystem : BaseVM
    {
        private Event @event;

        public SkatingSystem(Event @event) => this.@event = @event;

        public Event Event
        {
            get => @event;
            set { @event = value; OnPropertyChanged(); }
        }

        public void SetResult(List<Nomination> nominations)
        {
            var nominationCompetitors = @event.NominationCompetitors.FindAll(nc => nominations.Contains(nc.Nomination));

            foreach(var competitors in nominationCompetitors)
            {
                var isHarder = competitors.Nomination.Name == "Main" || competitors.Nomination.Name == "Star";

                foreach (var dancerPlacement in competitors.DancerPlacemant)
                    GetPointByPlacement(dancerPlacement.Value, competitors.Dancers.Count, isHarder);
            }
        }
        public int GetPointByPlacement(int placement, int count, bool isHarder)
        {
            var points = -1;
            var coefficient = isHarder ? (double)1 / 3 : (double)1 / 2;

            if (placement > 0 && count > 2)
            {
                points = GetPoints(placement, count, coefficient);
            }

            return points;
        }

        internal int GetPoints(int placement, int count, double coefficient)
        {
            var points = 0;
            var newCoefficient = 0.55;

            if ((double)placement / count < coefficient)
            {
                points = 1;

                points += GetPoints(placement, count, coefficient * newCoefficient);
            }

            return points;
        }
    }
}
