using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Сампо.Models;

namespace Сампо.ViewModels
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
