using FO.Models;

using SampoClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampoClient.ViewModels
{
    class CreateRulesViewModel : BaseVM
    {
        private ObservableCollection<Rule> rules;

        public CreateRulesViewModel()
        {
            rules = new ObservableCollection<Rule>();
        }

        public ObservableCollection<Rule> Rules
        {
            get => rules;
            set { rules = value; OnPropertyChanged(); }
        }
    }
}
