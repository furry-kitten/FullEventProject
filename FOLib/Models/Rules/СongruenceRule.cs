using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models.Rules
{
    public class СongruenceRule : Accepted<Classes>
    {
        public СongruenceRule() : base()
        {
        }
        public СongruenceRule(string name, string decription) : base(name, decription)
        {
        }
        public СongruenceRule(string name, string decription, Classes classes) : base(name, decription)
        {
            SetClass(classes);
        }
        public СongruenceRule(BaseRule baseRule, Classes classes) : base(baseRule.Name, baseRule.Decription)
        {
            SetClass(classes);
        }

        public Classes Class
        {
            get => MainParametr;
            set { MainParametr = value; OnPropertyChanged(); }
        }

        internal static СongruenceRule CreateСongruenceRule(string name, string decription, Classes classes, byte minPoints)
        {
            var rule = new СongruenceRule(name, decription);

            rule.Class = new Classes()
            {
                Name = classes.Name,
                Comment = classes.Comment,
                Points = minPoints,
                SHAClasses = classes.SHAClasses
            };

            return rule;
        }

        public override string ToString()
        {
            return $"Можно участвовать, если ваш класс не ниже {MainParametr.Name}{MainParametr.Points}";
        }
        public override bool Accept(Classes item)
        {
            return item.Name == MainParametr.Name &&
                item.Points >= MainParametr.Points;
        }

        private void SetClass(Classes classes)
        {
            MainParametr = classes;
        }
    }
}
