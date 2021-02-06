using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models
{
    public class Person : DBClass
    {
        private string
            sername = string.Empty,
            patronym = string.Empty,
            modile = string.Empty,
            mail = string.Empty;


        public string Sername
        {
            get => sername;
            set { sername = value; OnPropertyChanged(); }
        }
        public string Patronym
        {
            get => patronym;
            set { patronym = value; OnPropertyChanged(); }
        }
        public string Modile
        {
            get => modile;
            set { modile = value; OnPropertyChanged(); }
        }
        public string Main
        {
            get => mail;
            set { mail = value; OnPropertyChanged(); }
        }
    }
}
