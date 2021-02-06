using FO.Models.Перечисления;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models
{
    public class Rule : BaseVM
    {
        private ControlsForTracking control = ControlsForTracking.None;
        private string descriprion = string.Empty;
        private string work = string.Empty;

        public Rule()
        {

        }

        public ControlsForTracking ControlForTracking
        {
            get => control;
            set { control = value; OnPropertyChanged(); }
        }
        public string Description => GetDescription(control);
        public string Work
        {
            get => work;
            set { work = value; OnPropertyChanged(); }
        }

        private string GetDescription(Enum enumElement)
        {
            Type type = enumElement.GetType();

            MemberInfo[] memInfo = type.GetMember(enumElement.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return enumElement.ToString();
        }
    }
}
