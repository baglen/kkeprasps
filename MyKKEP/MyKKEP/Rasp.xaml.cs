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
using System.Web.UI.WebControls;

namespace MyKKEP
{
    /// <summary>
    /// Логика взаимодействия для Rasp.xaml
    /// </summary>
    public partial class Rasp : Page
    {
        private static string Token;
        private static string GroupName;
        private int WeekSetting;
        List<Days> listSheduleMonday = new List<Days>();
        List<Days> listSheduleTuesday = new List<Days>();
        List<Days> listSheduleWednesday = new List<Days>();
        List<Days> listSheduleThursday = new List<Days>();
        List<Days> listSheduleFriday = new List<Days>();
        List<Days> listSheduleSaturday = new List<Days>();

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

            GroupSheduleSetChange();
            
        }
        private void GroupSheduleSetChange()
        {
            listSheduleMonday.Clear();
            listSheduleTuesday.Clear();
            listSheduleWednesday.Clear();
            listSheduleThursday.Clear();
            listSheduleFriday.Clear();
            listSheduleSaturday.Clear();
            sheduleGridMonday.ItemsSource = new List<string>();
            sheduleGridTuesday.ItemsSource = new List<string>();
            sheduleGridWednesday.ItemsSource = new List<string>();
            sheduleGridThursday.ItemsSource = new List<string>();
            sheduleGridFriday.ItemsSource = new List<string>();
            sheduleGridSaturday.ItemsSource = new List<string>();

            string responseGroupShedule = Request.GroupShedule(Token, GroupName, WeekSetting);
            JArray jAnswer = JArray.Parse(responseGroupShedule);
            
            try
            {
                for (int i = 0; i < jAnswer.Count; i++)
                {
                    JObject j123 = JObject.Parse(jAnswer[i].ToString());
                    if (j123["day_of_week"].ToString() == "1")
                    {
                        JArray jPairs = JArray.Parse(j123["pairs"].ToString());
                        for (int j = 0; j < jPairs.Count; j++)
                        {
                            Days monday = new Days();
                            JObject jobj = JObject.Parse(jPairs[j].ToString());

                            if (jobj["isnull"].ToString() != "1")
                            {

                                monday.pairNum = jobj["p_num"].ToString();
                                monday.pairSubject = jobj["p_subj"].ToString();
                                monday.pairAud = jobj["p_aud"].ToString();
                                monday.pairTeacher = jobj["p_prep"].ToString();
                                monday.ischange = jobj["ischange"].ToString();
                                
                            }
                            else
                            {
                                monday.pairNum = jobj["p_num"].ToString();
                                monday.pairSubject = ("Нет");
                                monday.pairAud = ("-/-");
                                monday.pairTeacher = ("Нет");
                            }
                            listSheduleMonday.Add(monday);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            try
            {
                for (int i = 0; i < jAnswer.Count; i++)
                {
                    JObject j123 = JObject.Parse(jAnswer[i].ToString());
                    if (j123["day_of_week"].ToString() == "2")
                    {
                        JArray jPairs = JArray.Parse(j123["pairs"].ToString());
                        for (int j = 0; j < jPairs.Count; j++)
                        {
                            Days tuesday = new Days();
                            JObject jobj = JObject.Parse(jPairs[j].ToString());
                            if (jobj["isnull"].ToString() != "1")
                            {

                                tuesday.pairNum = jobj["p_num"].ToString();
                                tuesday.pairSubject = jobj["p_subj"].ToString();
                                tuesday.pairAud = jobj["p_aud"].ToString();
                                tuesday.pairTeacher = jobj["p_prep"].ToString();
                                tuesday.ischange = jobj["ischange"].ToString();
                            }
                            else
                            {
                                tuesday.pairNum = jobj["p_num"].ToString();
                                tuesday.pairSubject = ("Нет");
                                tuesday.pairAud = ("-/-");
                                tuesday.pairTeacher = ("Нет");
                            }
                            listSheduleTuesday.Add(tuesday);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            try
            {
                for (int i = 0; i < jAnswer.Count; i++)
                {
                    JObject j123 = JObject.Parse(jAnswer[i].ToString());
                    if (j123["day_of_week"].ToString() == "3")
                    {
                        JArray jPairs = JArray.Parse(j123["pairs"].ToString());
                        for (int j = 0; j < jPairs.Count; j++)
                        {
                            Days wednesday = new Days();
                            JObject jobj = JObject.Parse(jPairs[j].ToString());
                            if (jobj["isnull"].ToString() != "1")
                            {

                                wednesday.pairNum = jobj["p_num"].ToString();
                                wednesday.pairSubject = jobj["p_subj"].ToString();
                                wednesday.pairAud = jobj["p_aud"].ToString();
                                wednesday.pairTeacher = jobj["p_prep"].ToString();
                            }
                            else
                            {
                                wednesday.pairNum = jobj["p_num"].ToString();
                                wednesday.pairSubject = ("Нет");
                                wednesday.pairAud = ("-/-");
                                wednesday.pairTeacher = ("Нет");
                            }
                            listSheduleWednesday.Add(wednesday);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            try
            {
                for (int i = 0; i < jAnswer.Count; i++)
                {
                    JObject j123 = JObject.Parse(jAnswer[i].ToString());
                    if (j123["day_of_week"].ToString() == "4")
                    {
                        JArray jPairs = JArray.Parse(j123["pairs"].ToString());
                        for (int j = 0; j < jPairs.Count; j++)
                        {
                            Days thursday = new Days();
                            JObject jobj = JObject.Parse(jPairs[j].ToString());
                            if (jobj["isnull"].ToString() != "1")
                            {

                                thursday.pairNum = jobj["p_num"].ToString();
                                thursday.pairSubject = jobj["p_subj"].ToString();
                                thursday.pairAud = jobj["p_aud"].ToString();
                                thursday.pairTeacher = jobj["p_prep"].ToString();
                            }
                            else
                            {
                                thursday.pairNum = jobj["p_num"].ToString();
                                thursday.pairSubject = ("Нет");
                                thursday.pairAud = ("-/-");
                                thursday.pairTeacher = ("Нет");
                            }
                            listSheduleThursday.Add(thursday);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            try
            {
                for (int i = 0; i < jAnswer.Count; i++)
                {
                    JObject j123 = JObject.Parse(jAnswer[i].ToString());
                    if (j123["day_of_week"].ToString() == "5")
                    {
                        JArray jPairs = JArray.Parse(j123["pairs"].ToString());
                        for (int j = 0; j < jPairs.Count; j++)
                        {
                            Days friday = new Days();
                            JObject jobj = JObject.Parse(jPairs[j].ToString());
                            if (jobj["isnull"].ToString() != "1")
                            {

                                friday.pairNum = jobj["p_num"].ToString();
                                friday.pairSubject = jobj["p_subj"].ToString();
                                friday.pairAud = jobj["p_aud"].ToString();
                                friday.pairTeacher = jobj["p_prep"].ToString();
                            }
                            else
                            {
                                friday.pairNum = jobj["p_num"].ToString();
                                friday.pairSubject = ("Нет");
                                friday.pairAud = ("-/-");
                                friday.pairTeacher = ("Нет");
                            }
                            listSheduleFriday.Add(friday);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            try
            {
                for (int i = 0; i < jAnswer.Count; i++)
                {
                    JObject j123 = JObject.Parse(jAnswer[i].ToString());
                    if (j123["day_of_week"].ToString() == "6")
                    {
                        JArray jPairs = JArray.Parse(j123["pairs"].ToString());
                        for (int j = 0; j < jPairs.Count; j++)
                        {
                            Days saturday = new Days();
                            JObject jobj = JObject.Parse(jPairs[j].ToString());
                            if (jobj["isnull"].ToString() != "1")
                            {

                                saturday.pairNum = jobj["p_num"].ToString();
                                saturday.pairSubject = jobj["p_subj"].ToString();
                                saturday.pairAud = jobj["p_aud"].ToString();
                                saturday.pairTeacher = jobj["p_prep"].ToString();
                            }
                            else
                            {
                                saturday.pairNum = jobj["p_num"].ToString();
                                saturday.pairSubject = ("Нет");
                                saturday.pairAud = ("-/-");
                                saturday.pairTeacher = ("Нет");
                            }
                            listSheduleSaturday.Add(saturday);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            sheduleGridMonday.ItemsSource = listSheduleMonday;
            sheduleGridTuesday.ItemsSource = listSheduleTuesday;
            sheduleGridWednesday.ItemsSource = listSheduleWednesday;
            sheduleGridThursday.ItemsSource = listSheduleThursday;
            sheduleGridFriday.ItemsSource = listSheduleFriday;
            sheduleGridSaturday.ItemsSource = listSheduleSaturday;
        }
        private void GroupSheduleNotChange()
        {
            
            listSheduleMonday.Clear();
            listSheduleTuesday.Clear();
            listSheduleWednesday.Clear();
            listSheduleThursday.Clear();
            listSheduleFriday.Clear();
            listSheduleSaturday.Clear();
            sheduleGridMonday.ItemsSource = new List<string>();
            sheduleGridTuesday.ItemsSource = new List<string>();
            sheduleGridWednesday.ItemsSource = new List<string>();
            sheduleGridThursday.ItemsSource = new List<string>();
            sheduleGridFriday.ItemsSource = new List<string>();
            sheduleGridSaturday.ItemsSource = new List<string>();

            string responseGroupShedule = Request.GroupShedule(Token, GroupName, WeekSetting);
            JArray jAnswer = JArray.Parse(responseGroupShedule);

            try
            {
                for (int i = 0; i < jAnswer.Count; i++)
                {
                    JObject j123 = JObject.Parse(jAnswer[i].ToString());
                    if (j123["day_of_week"].ToString() == "1")
                    {
                        JArray jPairs = JArray.Parse(j123["pairs"].ToString());
                        for (int j = 0; j < jPairs.Count; j++)
                        {
                            Days monday = new Days();
                            JObject jobj = JObject.Parse(jPairs[j].ToString());
                            if (jobj["ischange"].ToString() == "0")
                            {
                                if (jobj["isnull"].ToString() != "1")
                                {

                                    monday.pairNum = jobj["p_num"].ToString();
                                    monday.pairSubject = jobj["p_subj"].ToString();
                                    monday.pairAud = jobj["p_aud"].ToString();
                                    monday.pairTeacher = jobj["p_prep"].ToString();
                                    monday.ischange = jobj["ischange"].ToString();

                                }
                                else
                                {
                                    monday.pairNum = jobj["p_num"].ToString();
                                    monday.pairSubject = ("Нет");
                                    monday.pairAud = ("-/-");
                                    monday.pairTeacher = ("Нет");
                                }
                                listSheduleMonday.Add(monday);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            try
            {
                for (int i = 0; i < jAnswer.Count; i++)
                {
                    JObject j123 = JObject.Parse(jAnswer[i].ToString());
                    if (j123["day_of_week"].ToString() == "2")
                    {
                        JArray jPairs = JArray.Parse(j123["pairs"].ToString());
                        for (int j = 0; j < jPairs.Count; j++)
                        {
                            Days tuesday = new Days();
                            JObject jobj = JObject.Parse(jPairs[j].ToString());
                            if (jobj["ischange"].ToString() == "0")
                            {
                                if (jobj["isnull"].ToString() != "1")
                                {

                                    tuesday.pairNum = jobj["p_num"].ToString();
                                    tuesday.pairSubject = jobj["p_subj"].ToString();
                                    tuesday.pairAud = jobj["p_aud"].ToString();
                                    tuesday.pairTeacher = jobj["p_prep"].ToString();
                                    tuesday.ischange = jobj["ischange"].ToString();
                                }
                                else
                                {
                                    tuesday.pairNum = jobj["p_num"].ToString();
                                    tuesday.pairSubject = ("Нет");
                                    tuesday.pairAud = ("-/-");
                                    tuesday.pairTeacher = ("Нет");
                                }
                                listSheduleTuesday.Add(tuesday);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            try
            {
                for (int i = 0; i < jAnswer.Count; i++)
                {
                    JObject j123 = JObject.Parse(jAnswer[i].ToString());
                    if (j123["day_of_week"].ToString() == "3")
                    {
                        JArray jPairs = JArray.Parse(j123["pairs"].ToString());
                        for (int j = 0; j < jPairs.Count; j++)
                        {
                            Days wednesday = new Days();
                            JObject jobj = JObject.Parse(jPairs[j].ToString());
                            if (jobj["ischange"].ToString() == "0")
                            {
                                if (jobj["isnull"].ToString() != "1")
                                {

                                    wednesday.pairNum = jobj["p_num"].ToString();
                                    wednesday.pairSubject = jobj["p_subj"].ToString();
                                    wednesday.pairAud = jobj["p_aud"].ToString();
                                    wednesday.pairTeacher = jobj["p_prep"].ToString();
                                }
                                else
                                {
                                    wednesday.pairNum = jobj["p_num"].ToString();
                                    wednesday.pairSubject = ("Нет");
                                    wednesday.pairAud = ("-/-");
                                    wednesday.pairTeacher = ("Нет");
                                }
                                listSheduleWednesday.Add(wednesday);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            try
            {
                for (int i = 0; i < jAnswer.Count; i++)
                {
                    JObject j123 = JObject.Parse(jAnswer[i].ToString());
                    if (j123["day_of_week"].ToString() == "4")
                    {
                        JArray jPairs = JArray.Parse(j123["pairs"].ToString());
                        for (int j = 0; j < jPairs.Count; j++)
                        {
                            Days thursday = new Days();
                            JObject jobj = JObject.Parse(jPairs[j].ToString());
                            if (jobj["ischange"].ToString() == "0")
                            {
                                if (jobj["isnull"].ToString() != "1")
                                {

                                    thursday.pairNum = jobj["p_num"].ToString();
                                    thursday.pairSubject = jobj["p_subj"].ToString();
                                    thursday.pairAud = jobj["p_aud"].ToString();
                                    thursday.pairTeacher = jobj["p_prep"].ToString();
                                }
                                else
                                {
                                    thursday.pairNum = jobj["p_num"].ToString();
                                    thursday.pairSubject = ("Нет");
                                    thursday.pairAud = ("-/-");
                                    thursday.pairTeacher = ("Нет");
                                }
                                listSheduleThursday.Add(thursday);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            try
            {
                for (int i = 0; i < jAnswer.Count; i++)
                {
                    JObject j123 = JObject.Parse(jAnswer[i].ToString());
                    if (j123["day_of_week"].ToString() == "5")
                    {
                        JArray jPairs = JArray.Parse(j123["pairs"].ToString());
                        for (int j = 0; j < jPairs.Count; j++)
                        {
                            Days friday = new Days();
                            JObject jobj = JObject.Parse(jPairs[j].ToString());
                            if (jobj["ischange"].ToString() == "1")
                            {
                                if (jobj["isnull"].ToString() != "1")
                                {

                                    friday.pairNum = jobj["p_num"].ToString();
                                    friday.pairSubject = jobj["p_subj"].ToString();
                                    friday.pairAud = jobj["p_aud"].ToString();
                                    friday.pairTeacher = jobj["p_prep"].ToString();
                                }
                                else
                                {
                                    friday.pairNum = jobj["p_num"].ToString();
                                    friday.pairSubject = ("Нет");
                                    friday.pairAud = ("-/-");
                                    friday.pairTeacher = ("Нет");
                                }
                                listSheduleFriday.Add(friday);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            try
            {
                for (int i = 0; i < jAnswer.Count; i++)
                {
                    JObject j123 = JObject.Parse(jAnswer[i].ToString());
                    if (j123["day_of_week"].ToString() == "6")
                    {
                        JArray jPairs = JArray.Parse(j123["pairs"].ToString());
                        for (int j = 0; j < jPairs.Count; j++)
                        {
                            Days saturday = new Days();
                            JObject jobj = JObject.Parse(jPairs[j].ToString());
                            if (jobj["ischange"].ToString() == "1")
                            {
                                if (jobj["isnull"].ToString() != "1")
                                {

                                    saturday.pairNum = jobj["p_num"].ToString();
                                    saturday.pairSubject = jobj["p_subj"].ToString();
                                    saturday.pairAud = jobj["p_aud"].ToString();
                                    saturday.pairTeacher = jobj["p_prep"].ToString();
                                }
                                else
                                {
                                    saturday.pairNum = jobj["p_num"].ToString();
                                    saturday.pairSubject = ("Нет");
                                    saturday.pairAud = ("-/-");
                                    saturday.pairTeacher = ("Нет");
                                }
                                listSheduleSaturday.Add(saturday);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            sheduleGridMonday.ItemsSource = listSheduleMonday;
            sheduleGridTuesday.ItemsSource = listSheduleTuesday;
            sheduleGridWednesday.ItemsSource = listSheduleWednesday;
            sheduleGridThursday.ItemsSource = listSheduleThursday;
            sheduleGridFriday.ItemsSource = listSheduleFriday;
            sheduleGridSaturday.ItemsSource = listSheduleSaturday;
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
            GroupSheduleSetChange();
        }

        private void FirstWeek_Click(object sender, RoutedEventArgs e)
        {
            WeekSetting = 1;
            GroupSheduleSetChange();
        }

        private void SecondWeek_Click(object sender, RoutedEventArgs e)
        {
            WeekSetting = 2;
            GroupSheduleSetChange();
        }

        private void ComboBoxGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GroupName = ComboBoxGroups.SelectedItem.ToString();
            GroupSheduleSetChange();
        }

        private void addChange_Click(object sender, RoutedEventArgs e)
        {
            GroupSheduleSetChange();
            MessageBox.Show("Change");
        }

        private void removeChange_Click(object sender, RoutedEventArgs e)
        {
            GroupSheduleNotChange();
            MessageBox.Show("NotChange");
        }
    }
}
