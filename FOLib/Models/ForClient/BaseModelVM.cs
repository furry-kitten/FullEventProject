using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models.ForClient
{
    public class BaseModelVM : BaseVM
    {
        private UserSettings userSettings;

        public BaseModelVM()
        {
            GeneralSettings();
        }
        public BaseModelVM(UserSettings settings)
        {
            userSettings = settings;
        }

        public UserSettings Settings
        {
            get => userSettings;
            set { userSettings = value; OnPropertyChanged(); }
        }

        protected virtual void GeneralSettings()
        {
            userSettings = UserSettings.DeserializeSettings();
        }
    }
}
