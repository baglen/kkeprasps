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
    public partial class MainWindow : Window
    {
        public static string Token;
        public static string NameUser;
        public static string SurnameUser;
        public static string GroupName;
        public static int GroupNum;
        public MainWindow()
        {

            InitializeComponent();
            if (MenuFrame.CanGoBack == false)
            {
                BtnSupport.Visibility = Visibility.Hidden;
                BtnSettings.Visibility = Visibility.Hidden;
                BtnMessage.Visibility = Visibility.Hidden;
                BtnStudRasp.Visibility = Visibility.Hidden;
            }
            MenuFrame.Navigate(new AutorizeWindow());
            Manager.MainFrame = MenuFrame;
        }

        private void BtnSupport_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Support(NameUser, SurnameUser));
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
            Manager.MainFrame.Navigate(new Rasp(Token, GroupName));
        }

        private void MenuFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MenuFrame.CanGoBack)
            {
                BtnSupport.Visibility = Visibility.Visible;
                BtnSettings.Visibility = Visibility.Visible;
                BtnMessage.Visibility = Visibility.Visible;
                BtnStudRasp.Visibility = Visibility.Visible;
            }
        }
    }
}
