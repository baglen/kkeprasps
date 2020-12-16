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
using System.Net;
using System.IO;
using System.Net.Mail;


namespace MyKKEP
{
   
    public partial class Support : Page
    {
        private string NameUser;
        private string SurnameUser;

        public Support(string name, string surname)
        {
            InitializeComponent();
            NameUser = name;
            SurnameUser = surname;
        }

        private void Option3_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Letter(NameUser,SurnameUser));
        }

        private void Option1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
