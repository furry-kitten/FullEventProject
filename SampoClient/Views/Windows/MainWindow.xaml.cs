using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SampoClient.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void DragWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GroupButton(object sender, RoutedEventArgs e)
        {
            //  открыть станицу группы
            MessageBox.Show($"Открыта группа {(sender as Button).Content}");
            //  где и как хранить информацию?
            /*
             * 1 - ссылки на файлы в бд
             * 2 - в бд
             */
        }

        private void Sampo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("!");
        }
    }
}
