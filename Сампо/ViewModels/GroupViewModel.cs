using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Сампо.HostingSampo;

namespace Сампо.ViewModels
{
    public class GroupViewModel : Models.BaseVM
    {
        /*
         * Создать список танцоров
         */
        private Sampo selectedSampo;

        public GroupViewModel()
        {
            var client = new ForOrganizatorsClient();
            selectedSampo = client.GetSampoList("")[0];
        }

        public Sampo SelectedSampo
        {
            get => selectedSampo;
            set
            {
                selectedSampo = value;
                OnPropertyChanged();
            }
        }
    }
}
