﻿using System;
using Newtonsoft.Json.Linq;
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
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
                string login = TxtLogin.Text;
                string password = TxtPassword.Password;
                string response = Request.PostLogin("https://my.kkep.ru/api.php?", login, password);
                JObject jObject = JObject.Parse(response);
                Token = jObject["ses_token"].ToString();
                MessageBox.Show("Вы успешно авторизованы");

                //artem
                string group = TxtGroup.Text;
                string week = TxtWeek.Text;
                string responseShedule = Request.PostLogin(Token, group, week);
                JObject jSheduleObj = JObject.Parse(responseShedule);
                MessageBox.Show(Convert.ToString(jSheduleObj));

                Manager.MainFrame.Navigate(new Menu());
        }
    }
}
