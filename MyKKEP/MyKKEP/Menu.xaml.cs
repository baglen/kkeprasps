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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyKKEP
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        private static string Token;
        public Menu(string token)
        {
            Token = token;
            InitializeComponent();
            MenuFrame.Navigate(new Rasp());
            Manager.MainFrame = MenuFrame;
        }

        private void BtnSupport_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Support());
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Settings());
        }

        private void BtnMessage_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Message());
        }

        private void BtnStudRasp_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Rasp());
        }
    }
}
