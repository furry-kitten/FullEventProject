using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models
{
    public class GroupOfOrganiziers : DBClass
    {
        public GroupOfOrganiziers() { }

        public Event Event { get; set; }
        public List<Dancer> Dancers { get; set; }
        public Club Club { get; set; }
        public Guid IdClub { get; set; }

        public override string ToString()
        {
            var allDancers = "";

            foreach (var dancer in Dancers)
            {
                allDancers += $"{dancer}";

                if (Dancers.Count > 1)
                    allDancers += "\n";
            }

            return $"Название:\t{Name}\n" +
                $"{allDancers}";
        }
    }
}
