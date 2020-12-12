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
        private static string Token=null;
        private static string SurnameUser;
        private static string NameUser;
        private static string GroupName;
        private static int GroupNum=0;
        public AutorizeWindow()
        {
            InitializeComponent();
            if (Token != null)
            {
               // Manager.MainFrame.Navigate(new MainWindow(Token, NameUser, SurnameUser, GroupNum, GroupName));
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
                TxtLogin.Text = "zhuravko"; 
                TxtPassword.Password = "999035";
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
                    string accessName= jObjectUser["access_name"].ToString(); // имя роли
                    if (accessName == "Студенты")
                    {
                    JObject jObjectGroup = JObject.Parse(jObjectUser["group"].ToString());
                    GroupNum = Convert.ToInt32(jObjectGroup["group_num"].ToString());
                    GroupName = jObjectGroup["name"].ToString();
                    }
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
                    Manager.MainFrame.Navigate(new Rasp(Token, GroupName));
                    MainWindow.Token = Token;
                    MainWindow.SurnameUser = SurnameUser;
                    MainWindow.NameUser = NameUser;
                    MainWindow.GroupName = GroupName;
                    MainWindow.GroupNum = GroupNum;
                }
            
        }
    }
}
