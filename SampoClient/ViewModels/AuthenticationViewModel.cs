using DevExpress.Mvvm;
using SampoClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampoClient.ViewModels
{
    internal class AuthenticationViewModel : BaseVM
    {
        private UserSettings settings;

        public AuthenticationViewModel()
        {
            settings = UserSettings.DeserializeSettings();
        }

        public ICommand<object> SignIn => (new DelegateCommand<object>((obj) => Auth(obj as string)));

        public UserSettings Settings
        {
            get => settings;
            set { settings = value; OnPropertyChanged(); }
        }
        public object LoginOrIDsha
        {
            get => settings.Authentication.IDsha == -1 ? Convert.ToString(settings.Authentication.IDsha) : settings.Authentication.Login;
            set
            {
                if (value is int)
                    settings.Authentication.IDsha = Convert.ToInt32(value);
                else
                    settings.Authentication.Login = value as string;
                /*
                try
                {
                    settings.Authentication.IDsha = int.Parse(value);
                }
                catch
                {
                    settings.Authentication.Login = value;
                }
                */

                OnPropertyChanged("Settings");
            }
        }
        public void Auth(string pas)
        {
            settings.Authentication.Password = pas;
        }
    }
}
