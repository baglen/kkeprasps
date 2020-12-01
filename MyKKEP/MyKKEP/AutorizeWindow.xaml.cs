using Newtonsoft.Json.Linq;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MyKKEP
{
    public partial class AutorizeWindow : Page
    {
        private static string Token=null;
        public AutorizeWindow()
        {
            InitializeComponent();
            if (Token != null)
            {
                Manager.MainFrame.Navigate(new Menu());
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
                string login = TxtLogin.Text;
                string password = TxtPassword.Password;
                try
                {
                    string response = Request.PostLogin("https://my.kkep.ru/api.php?", login, password);
                    JObject jObject = JObject.Parse(response);
                    Token = jObject["ses_token"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка в отправке данных на сервер " + ex.ToString());
                }
                if (string.IsNullOrWhiteSpace(Token))
                {
                    MessageBox.Show("Введены неверные данные");
                }
                else
                {
                    MessageBox.Show("Вы успешно авторизованы");
                    Manager.MainFrame.Navigate(new Menu());
                }
        }
    }
}
