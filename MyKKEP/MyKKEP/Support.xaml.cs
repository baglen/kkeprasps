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
    /// Логика взаимодействия для Support.xaml
    /// </summary>
    public partial class Support : Page
    {
        private string NameUser;
        private string SurnameUser;
        public Support(string name, string surname)
        {
            InitializeComponent();
            if (name != null && surname != null)
            {
                NameUser = name;
                SurnameUser = surname;
            }
            TEST.Text = NameUser + " " + SurnameUser;
        }
    }
}
