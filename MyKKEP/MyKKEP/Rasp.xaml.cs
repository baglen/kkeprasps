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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace MyKKEP
{
    /// <summary>
    /// Логика взаимодействия для Rasp.xaml
    /// </summary>
    public partial class Rasp : Page
    {
        private static string Token;
        private static string GroupName;
        private ObservableCollection<Days> Сollection { get; set; }
        public static void BindingDays()
        {
            //string responseShedule = Request.GroupShedule(Token, GroupName, 1);
            //JArray jArray = JArray.Parse(responseShedule);
            
        }
        
        public Rasp(string token, string groupName)
        {
            InitializeComponent();
            
            Token = token;
            GroupName = groupName;
            if (GroupName != null)
            {
                ComboBoxGroups.SelectedItem = GroupName;
            }
            string responseGroup = Request.GetGroupList(Token);
            JArray jArray = JArray.Parse(responseGroup);
            for (int i = 0; i < jArray.Count; i++)
            {
                JObject jObject = JObject.Parse(jArray[i].ToString());
                ComboBoxGroups.Items.Add(jObject["group_name"].ToString());
            }

            ComboBoxTeachers.SelectedIndex = 0;
            string responseTeacher = Request.GetTeacherList(Token);
            JArray jTeachers = JArray.Parse(responseTeacher);
            for (int i = 0; i < jTeachers.Count; i++)
            {
                ComboBoxTeachers.Items.Add(jTeachers[i].ToString());
            }
            //List<Array> Collection = new List<Array>();
            //string[] Array1 = new string[4] { "1", "2", "3", "4" };
            
            //Collection.Add(new Array[2] {[1, 1] });
            //sheduleGrid.ItemsSource = Array1;
        }
    

        private void BtnTeacherShedule_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxGroups.Visibility = Visibility.Hidden;
            ComboBoxTeachers.Visibility = Visibility.Visible;
        }

        private void BtnGroupShedule_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxTeachers.Visibility = Visibility.Hidden;
            ComboBoxGroups.Visibility = Visibility.Visible;
        }
    }
}
