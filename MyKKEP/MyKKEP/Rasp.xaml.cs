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
            string responseGroupShedule = Request.GroupShedule(Token, "632", 2);
            JArray jAnswer = JArray.Parse(responseGroupShedule);
            List<Days> list1 = new List<Days>();
            try
            {
                for (int i = 0; i < jAnswer.Count; i++)
                {
                    JObject j123 = JObject.Parse(jAnswer[i].ToString());
                    JArray jPairs = JArray.Parse(j123["pairs"].ToString());
                    for (int j = 0; j < jPairs.Count; j++)
                    {
                        JObject jobj = JObject.Parse(jPairs[j].ToString());
                        Days monday = new Days();
                        if(jobj["isnull"].ToString() != "1") 
                        {
                            monday.pairNum = jobj["p_num"].ToString();
                            monday.pairSubject = jobj["p_subj"].ToString();
                            monday.pairAud = jobj["p_aud"].ToString();
                            monday.pairTeacher = jobj["p_prep"].ToString();
                        }
                        list1.Add(monday);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            sheduleGrid.ItemsSource = list1;
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
