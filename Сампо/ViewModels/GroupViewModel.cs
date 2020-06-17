using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Сампо.Models;

namespace Сампо.ViewModels
{
    public class GroupViewModel : BaseVM
    {
        /*
         * Создать список танцоров
         */
        private Sampo selectedSampo;

        public GroupViewModel()
        {

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
