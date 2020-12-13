using System;
using System.Windows;
using System.Windows.Controls;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

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
        private System.Windows.Forms.OpenFileDialog Attachment1 = new System.Windows.Forms.OpenFileDialog();
        private string hueta;
        
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
                if(UserMessage.Body==null &&)
                {
                    if (hueta != null)
                    {
                        UserMessage.Attachments.Add(new Attachment(hueta));
                    }
                    else
                    {
                           
                    }
                }
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential("my.kkep.app", "putin5551");
                client.EnableSsl = true;
                client.Send(UserMessage);
                System.Windows.MessageBox.Show("Обращение отправлено!", "Уведомление");
            }
        }
        private void Attachment_Click(object sender, RoutedEventArgs e)
        {
            Attachment1.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
            if (Attachment1.ShowDialog() == DialogResult.OK)
            {
                hueta = Attachment1.FileName;
            }
        }
    }
}
