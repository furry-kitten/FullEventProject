using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models.Rules
{
    public class BaseRule : BaseVM
    {
        private string decription = string.Empty;
        private string name = string.Empty;

        public BaseRule()
        {

        }
        public BaseRule(string name, string decription)
        {
            this.name = name;
            this.decription= decription;
        }

        public string Name
        {
            get => name;
            set
            {
                name = value; OnPropertyChanged();
            }
        }
        public string Decription
        {
            get => decription;
            set
            {
                decription = value; OnPropertyChanged();
            }
        }

        public enum RuleType
        {
            All,
            Timer,
            Сongruence
        }
    }
}
