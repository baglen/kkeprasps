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
        public Support(string name, string surname)
        {
            InitializeComponent();
            if (name != null && surname != null)
            {
                NameUser = name;
                SurnameUser = surname;
                string to = "my.kkep.app@gmail.com";
                string from = "my.kkep.app@gmail.com";
                MailMessage message = new MailMessage(from, to);
                message.Subject = NameUser+" "+SurnameUser;
                message.Body = @"111";
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential("my.kkep.app", "putin5551");
                client.EnableSsl = true;
                client.Send(message);
            } 
        }
        
    }
}
