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
    /// <summary>
    /// login my.kkep.app@gmail.com
    /// pass putin5551
    /// Логика взаимодействия для Support.xaml
    /// </summary>
    public partial class Support : Page
    {
        private string NameUser;
        private string SurnameUser;
        private static string GroupName;
        public Support(string name, string surname, string groupName)
        {
            InitializeComponent();
            if (name != null && surname != null)
            {
                NameUser = name;
                SurnameUser = surname;
                GroupName = groupName;
            }
            TEST.Text = NameUser + " " + SurnameUser;

        }
    }
}
