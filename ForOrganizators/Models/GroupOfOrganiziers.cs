using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сампо.Models
{
    [Serializable]
    public class GroupOfOrganiziers
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IEnumerable <Partner> Dancers { get; set; }
    }
}
