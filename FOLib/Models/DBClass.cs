using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models
{
    public class DBClass : BaseVM
    {
        private Guid id = Guid.NewGuid();
        private string name = string.Empty;
        private string comment = string.Empty;

        public Guid Id
        {
            get => id;
            set { id = value; OnPropertyChanged(); }
        }
        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(); }
        }
        public string Comment
        {
            get => comment;
            set { comment = value; OnPropertyChanged(); }
        }
    }
}
