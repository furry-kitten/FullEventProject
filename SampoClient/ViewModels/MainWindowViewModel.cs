using DevExpress.Mvvm;

using FO.Models;

using SampoClient.Models;
using SampoClient.Views.Pages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SampoClient.ViewModels
{
    public class MainWindowViewModel : BaseVM
    {
        /*
         * Задания:
         *  Для Вовы:
         *      -   Создать список созданных сампо (те, что были созданы авторизованным пользователем и в тех, где он язвется организатором)
         *      -   Добавить возможность из этого списка переходить в сампо для просмотра
         */
        private Page currentPage;

        public MainWindowViewModel()
        {
            currentPage = new SampoPage();
        }

        public Page CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                OnPropertyChanged();
            }
        }

        public ICommand CloseApp => new DelegateCommand(() =>
        {
            App.Current.Shutdown();
        });
    }
}
