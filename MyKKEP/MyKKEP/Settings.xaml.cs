using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        private static bool ButtonSwitch = true;
        public Settings()
        {
            InitializeComponent();
            Notice.Navigate(new Switch(ButtonSwitch));
        }

        private void BtnNotice_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonSwitch == true)
                ButtonSwitch = false;
            else
                ButtonSwitch = true;
            Notice.Navigate(new Switch(ButtonSwitch));
        }
    }
}
