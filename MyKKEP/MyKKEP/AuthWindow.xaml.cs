using Newtonsoft.Json.Linq;
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
using System.Windows.Shapes;

namespace MyKKEP
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private static string Token;
        private static string SurnameUser;
        private static string NameUser;
        private static int GroupNum = 0;
        private static string GroupName;
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            TxtLogin.Text = "zhuravko";
            TxtPassword.Password = "999035";
            Manager.Login = TxtLogin.Text;
            Manager.Password = TxtPassword.Password;
            try
            {
                string response = Request.PostLogin();
                JObject jObject = JObject.Parse(response);
                Token = jObject["ses_token"].ToString();
                JObject jObjectUser = JObject.Parse(jObject["user"].ToString());
                NameUser = jObjectUser["first_name"].ToString();
                SurnameUser = jObjectUser["last_name"].ToString();
                string accessName = jObjectUser["access_name"].ToString(); // имя роли
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
                //MessageBox.Show($"Вы успешно авторизованы");
                MainWindow.SurnameUser = SurnameUser;
                MainWindow.NameUser = NameUser;
                Manager.GroupName = GroupName;
                Manager.GroupDefault = GroupName;
                Manager.GroupNum = GroupNum;
                Manager.Token = Token;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }

        }
    }
}

