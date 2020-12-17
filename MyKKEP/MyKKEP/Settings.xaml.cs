using System.Windows;
using System.Windows.Controls;
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

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
            System.Windows.Forms.Application.Exit();
        }

        private void BtnDeleteCash_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Кэш очищен","MyKKEP",MessageBoxButton.OK,MessageBoxImage.Information);
        }
    }
}
