using FO.Models.Перечисления;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models
{
    public class NominationCompetitors : DBClass
    {
        private List<Dancer> dancers = new List<Dancer>();
        private Nomination nomination;
        private DanserType danserType;
        private Event @event;
        private Dictionary<Dancer, int> dancerPlacemant = new Dictionary<Dancer, int>();

        public Event Event
        {
            get => @event;
            set { @event = value; OnPropertyChanged(); }
        }
        public DanserType DanserType
        {
            get => danserType;
            set { danserType = value; OnPropertyChanged(); }
        }
        public List<Dancer> Dancers
        {
            get => dancers;
            set { dancers = value; OnPropertyChanged(); }
        }
        public Nomination Nomination
        {
            get => nomination;
            set { nomination = value; OnPropertyChanged(); }
        }
        public Dictionary<Dancer, int> DancerPlacemant
        {
            get => dancerPlacemant;
            set { dancerPlacemant = value; OnPropertyChanged(); }
        }

        public void AddDancerPlacemant(Dancer dancer)
        {
            if (dancerPlacemant.ContainsKey(dancer) || dancerPlacemant.Count == dancers.Count || !dancers.Contains(dancer))
                return;

            var placemant = dancers.Count - dancerPlacemant.Keys.Count;

            dancerPlacemant.Add(dancer, placemant);
        }
    }
}
