using Newtonsoft.Json.Linq;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Threading;

namespace MyKKEP
{

    public partial class AutorizeWindow : Page
    {
        static EventWaitHandle handle = new AutoResetEvent(false);
        private static string Token=null;
        private static string SurnameUser;
        private static string NameUser;
        public AutorizeWindow()
        {
            InitializeComponent();
            if (Token != null)
            {
                Manager.MainFrame.Navigate(new Menu(Token, NameUser, SurnameUser));
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
                string login = TxtLogin.Text;
                string password = TxtPassword.Password;
                try
                {
                    string response = Request.PostLogin(login, password);
                    JObject jObject = JObject.Parse(response);
                    Token = jObject["ses_token"].ToString();
                    JObject jObjectUser = JObject.Parse(jObject["user"].ToString());
                    NameUser = jObjectUser["first_name"].ToString();
                    SurnameUser= jObjectUser["last_name"].ToString();
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
                    Manager.MainFrame.Navigate(new Menu(Token, NameUser, SurnameUser));
                }
        }
    }
}
