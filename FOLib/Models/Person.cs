using FO.Models.Перечисления;

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

        private Gender gender;

        public Person() : base() { }
        public Person(string name, string sername, string patronym) : base(name, "")
        {
            this.sername = sername;
            this.patronym = patronym;
        }

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
        public string Mail
        {
            get => mail;
            set { mail = value; OnPropertyChanged(); }
        }
        public Gender Gender
        {
            get => gender;
            set { gender = value; OnPropertyChanged(); }
        }
        public Dancer Dancer { get; set; }

        public override string ToString()
        {
            return $"ФИО:\t\t{Name} {sername} {patronym}\n" +
                $"Пол:\t\t{gender}\n" +
                $"Почта:\t\t{mail}\n" +
                $"Телефон:\t\t{modile}";
        }
    }
}
