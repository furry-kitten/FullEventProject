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
    /// Логика взаимодействия для AuthanenticationWindow.xaml
    /// </summary>
    public partial class AuthanenticationWindow : Window
    {
        public AuthanenticationWindow()
        {
            InitializeComponent();
        }

        public void DragWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
