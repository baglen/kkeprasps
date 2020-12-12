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
using Microsoft.Win32;

namespace MyKKEP
{
    /// <summary>
    /// Логика взаимодействия для Letter.xaml
    ///  /// <summary>
    /// login my.kkep.app@gmail.com
    /// pass putin5551
    /// </summary>
    /// </summary>
    public partial class Letter : Page
    {
        private string NameUser;
        private string SurnameUser;
        private OpenFileDialog Attachment1;
        
        public Letter(string name, string surname)
        {
            InitializeComponent();
            NameUser = name;
            SurnameUser = surname;
        }


        private void Send_Click(object sender, RoutedEventArgs e)
        {
            
            if (NameUser != null && SurnameUser != null)
            {
                string to = "rapira7779@gmail.com";
                string from = "my.kkep.app@gmail.com";
                MailMessage UserMessage = new MailMessage(from, to);
                UserMessage.Subject = NameUser + " " + SurnameUser + " " + Caption.Text;
                UserMessage.Body = Text.Text;
                //message.Attachments.Add(new Attachment("D://temlog.txt"));
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential("my.kkep.app", "putin5551");
                client.EnableSsl = true;
                client.Send(UserMessage);
            }
        }

        private void Attachment_Click(object sender, RoutedEventArgs e,OpenFileDialog Attachment1)
        {
            OpenFileDialog attachment = Attachment1;
            attachment.Multiselect = true;
            attachment.Filter = "Pictures|(*.png;*.jpg;*.gif)|All files|*.*";
           // m.Attachments.Add(new Attachment(Attachment));
        }
    }
}
