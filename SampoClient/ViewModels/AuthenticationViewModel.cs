using DevExpress.Mvvm;
using SampoClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SampoClient.ViewModels
{
    internal class AuthenticationViewModel : BaseVM
    {
        private UserSettings settings;

        public AuthenticationViewModel()
        {
            settings = UserSettings.DeserializeSettings();
        }

        public ICommand<object> SignIn => new DelegateCommand<object>((obj) => Auth(obj));
        public ICommand CloseApp => new DelegateCommand(() =>
        {
            App.Current.Shutdown();
        });

        public UserSettings Settings
        {
            get => settings;
            set { settings = value; OnPropertyChanged(); }
        }
        public object LoginOrIDsha
        {
            get => settings.Authentication.IDsha > 0 ? Convert.ToString(settings.Authentication.IDsha) : settings.Authentication.Login;
            set
            {
                int var;

                if (int.TryParse(value as string, out var))
                    settings.Authentication.IDsha = var;
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
        public void Auth(object obj)
        {
            var PasswordBox = obj as PasswordBox;
            var pass = PasswordBox.Password.Trim();

#if DEBUG 
            if (string.IsNullOrWhiteSpace(pass))
                return;

            if (string.IsNullOrWhiteSpace(settings.Authentication.Login) && settings.Authentication.IDsha == 0)
                return;

            settings.Authentication.Password = pass;
            MessageBox.Show($"Login {settings.Authentication.Login}\n" +
                $"IDsha {settings.Authentication.IDsha}\n" +
                $"Password {settings.Authentication.Password}");
#else
            if (string.IsNullOrWhiteSpace(pass))
                return;

            if (string.IsNullOrWhiteSpace(settings.Authentication.Login) && settings.Authentication.IDsha == 0)
                return;

            settings.Authentication.Password = pass;
            if (string.IsNullOrEmpty(settings.Authentication.Login))
                settings.Authentication.Authenticate(settings.Authentication.IDsha, settings.Authentication.Password);
            else
                settings.Authentication.Authenticate(settings.Authentication.Login, settings.Authentication.Password);
#endif
        }
    }
}
