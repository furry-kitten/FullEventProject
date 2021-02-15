using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models.Rules
{
    internal class СongruenceRule : Accepted<SHAClasses>
    {
        private SHAClasses classes;

        public СongruenceRule(string name, string decription) : base(name, decription)
        {
        }
        public СongruenceRule(string name, string decription, SHAClasses classes) : base(name, decription)
        {
            SetClass(classes);
        }
        public СongruenceRule(BaseRule baseRule, SHAClasses classes) : base(baseRule.Name, baseRule.Decription)
        {
            SetClass(classes);
        }

        public SHAClasses Class
        {
            get => classes;
            set { classes = value; OnPropertyChanged(); }
        }

        public static СongruenceRule CreateСongruenceRule(string name, string decription, SHAClasses classes, byte minPoints)
        {
            var rule = new СongruenceRule(name, decription);

            rule.Class = new SHAClasses()
            {
                Name = classes.Name,
                Direction = classes.Direction,
                Comment = classes.Comment,
                TotalPoints = minPoints
            };

            return rule;
        }

        public override string ToString()
        {
            return $"Можно участвовать, если ваш класс не ниже {classes.Name}{classes.TotalPoints}";
        }
        public override bool Accept(SHAClasses item)
        {
            return item.Name == classes.Name &&
                item.TotalPoints >= classes.TotalPoints;
        }

        private void SetClass(SHAClasses classes)
        {
            this.classes = classes;
        }
    }
}
