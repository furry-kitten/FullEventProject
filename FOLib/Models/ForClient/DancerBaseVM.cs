using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models.ForClient
{
    public class DancerBaseVM : BaseModelVM
    {
        private Person person;
        private Dancer dancer;
        private AllData data;

        public DancerBaseVM()
        {
            GeneralSettings();
        }
        public DancerBaseVM(UserSettings settings) : base(settings)
        {
            this.data = settings.Data;
        }

        public Person Person
        {
            get => person;
            set { person = value; OnPropertyChanged(); }
        }

        protected override void GeneralSettings()
        {
            base.GeneralSettings();

            person = new Person();
            dancer = new Dancer(person, 0);
        }
    }
}
