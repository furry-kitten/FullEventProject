using FO.Models.Перечисления;

using Newtonsoft.Json;

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
        private string content;

        public BaseModelVM()
        {
            GeneralSettings();
            //content = new APIReader().GetSHAClassesString();
        }
        public BaseModelVM(UserSettings settings)
        {
            userSettings = settings;
            //content = new APIReader().GetSHAClassesString();
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

        public List<SHAClasses> GetSHAClasses()=> JsonConvert.DeserializeObject<List<SHAClasses>>(content);
    }
}
