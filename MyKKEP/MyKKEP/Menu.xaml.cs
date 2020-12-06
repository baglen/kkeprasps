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
        private static string NameUser;
        private static string SurnameUser;
        private static string GroupName;
        private static int GroupNum;
        public Menu(string token, string name, string surname, int groupNum, string groupName)
        {
            Token = token;
            NameUser = name;
            SurnameUser = surname;
            GroupName = groupName;
            GroupNum = groupNum;
            InitializeComponent();
            MenuFrame.Navigate(new Rasp(Token, GroupName));
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
    }
}
