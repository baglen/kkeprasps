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
    /// Логика взаимодействия для Switch.xaml
    /// </summary>
    public partial class Switch : Page
    {
        public Switch(bool button)
        {
            InitializeComponent();
            if (button == true)
            {
                BtnFalse.Visibility = Visibility.Hidden;
                BtnTrue.Visibility = Visibility.Visible;
                BtnSwitch.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3D3D3D"));
            }
            else
            {
                BtnTrue.Visibility = Visibility.Hidden;
                BtnFalse.Visibility = Visibility.Visible;
                BtnSwitch.Background = new SolidColorBrush(Colors.Transparent);
            }
        }
    }
}
