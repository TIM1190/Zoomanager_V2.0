using Microsoft.Win32;
using System.Windows;
using ZooManager.Services.Imp;

namespace ZooManager.Views
{
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            DataContext = this;
        }
       
        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
