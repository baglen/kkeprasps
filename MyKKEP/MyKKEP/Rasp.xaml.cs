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
//using System.Web.UI.WebControls;

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
        private int WeekChecker;
        private string Teacher;
        private int TeacherUid = 0;
        Collection<Days> listSheduleMonday = new Collection<Days>();
        Collection<Days> listSheduleTuesday = new Collection<Days>();
        Collection<Days> listSheduleWednesday = new Collection<Days>();
        Collection<Days> listSheduleThursday = new Collection<Days>();
        Collection<Days> listSheduleFriday = new Collection<Days>();
        Collection<Days> listSheduleSaturday = new Collection<Days>();
        Collection<string> groupsList = new Collection<string>();
        Collection<string> teachersList = new Collection<string>();

        private Dictionary<string, int> TeacherId = new Dictionary<string, int>();
            
        public Rasp(string token, string groupName)
        {
            InitializeComponent();
            #region TeachersIds
            TeacherId.Add("Аборнев Е.В.", 816);
            TeacherId.Add("Акользина А.Н.", 10);
            TeacherId.Add("Алиппа Д.В.", 188);
            TeacherId.Add("Блимготова Л.В.", 11);
            TeacherId.Add("Бондаренко О.П.", 13);
            TeacherId.Add("Борисова Е.В.", 15);
            TeacherId.Add("Борисова Н.И.", 16);
            TeacherId.Add("Боус О.А.", 233);
            TeacherId.Add("Бочарова М.В.", 17);
            TeacherId.Add("Гаврилов А.Л.", 1614);
            TeacherId.Add("Гимп К.Г.", 1313);
            TeacherId.Add("Глущенко Е.П.", 21);
            TeacherId.Add("Глущенко Ю.В.", 20);
            TeacherId.Add("Головко А.А.", 22);
            TeacherId.Add("Головко Р.А.", 23);
            TeacherId.Add("Гончарова С.П.", 270);
            TeacherId.Add("Горбуленко С.П.", 24);
            TeacherId.Add("Григорова Э.В.", 25);
            TeacherId.Add("Гринь И.В.", 26);
            TeacherId.Add("Дегтерева О.Н.", 28);
            TeacherId.Add("Евтушенко Е.Д.", 181);
            TeacherId.Add("Егоров Н.", 1421);
            TeacherId.Add("Емельянова Г.Ф.", 1823);
            TeacherId.Add("Ермолов И.А.", 30);
            TeacherId.Add("Ерофеева О.Г.", 31);
            TeacherId.Add("Задорожний В.Н.", 1834);
            TeacherId.Add("Закотнова Д.В.", 32);
            TeacherId.Add("Зарицкий О.А.", 2107);
            TeacherId.Add("Зиманина Т.Н.", 33);
            TeacherId.Add("Зябухина А.В.", 34);
            TeacherId.Add("Иншакова Е.А.", 35);
            TeacherId.Add("Исмаилов Э.Р.", 36);
            TeacherId.Add("Исмаилова З.Б.", 1356);
            TeacherId.Add("Казека С.В.", 38);
            TeacherId.Add("Карасев И.Н.", 39);
            TeacherId.Add("Карпенко Е.А.", 312);
            TeacherId.Add("Квашина Л.Н.", 40);
            TeacherId.Add("Клименкова В.Н.", 42);
            TeacherId.Add("Коваленко А.С.", 43);
            TeacherId.Add("Козак Н.М.", 44);
            TeacherId.Add("Козлова Е.М.", 45);
            TeacherId.Add("Комарова А.А.", 46);
            TeacherId.Add("Кондратьева АВ", 1728);
            TeacherId.Add("Кондратюк Л.А.", 47);
            TeacherId.Add("Конопкина Е.Б.", 48);
            TeacherId.Add("Копайгора М.А.", 237);
            TeacherId.Add("Копылов Р.Д.", 1946);
            TeacherId.Add("Копыльцова", 1432);
            TeacherId.Add("Коршунов М.В.", 49);
            TeacherId.Add("Костюшко Е.Ю.", 50);
            TeacherId.Add("Кофанова В.И.", 51);
            TeacherId.Add("Круглова А.С.", 129);
            TeacherId.Add("Куликова И.Е.", 1973);
            TeacherId.Add("Куц И.Н.", 232);
            TeacherId.Add("Лакоба В.А.", 52);
            TeacherId.Add("Лебедь Е.В.", 53);
            TeacherId.Add("Лосева Л.А.", 56);
            TeacherId.Add("Лукки Н.М.", 1784);
            TeacherId.Add("Малышевская М.В.", 59);
            TeacherId.Add("Мацарский А.А.", 248);
            TeacherId.Add("Медельцев В.В.", 1975);
            TeacherId.Add("Милюкова А.В.", 1952);
            TeacherId.Add("Новикова Н.В.", 64);
            TeacherId.Add("Павленко Н.Н.", 66);
            TeacherId.Add("Панасюк А.Г.", 67);
            TeacherId.Add("Пахомова Е.А.", 68);
            TeacherId.Add("Петрова Л.Л.", 70);
            TeacherId.Add("Пиховкина Е.А.", 71);
            TeacherId.Add("Плотникова И.Ю.", 72);
            TeacherId.Add("Полякова Н.В.", 1087);
            TeacherId.Add("Понкратова А.Н.", 74);
            TeacherId.Add("Пономаренко К.И.", 1358);
            TeacherId.Add("Потапова В.Н.", 75);
            TeacherId.Add("Рагульская Е.А.", 76);
            TeacherId.Add("Рузова В.И.", 79);
            TeacherId.Add("Русман А.Л.", 80);
            TeacherId.Add("Рябчиков П.А.", 82);
            TeacherId.Add("Савченко П.П.", 84);
            TeacherId.Add("Сосновская Т.Г.", 86);
            TeacherId.Add("Сторчак Е.Е.", 87);
            TeacherId.Add("Сторчевой А.Е.", 88);
            TeacherId.Add("Субботина Е.А.", 89);
            TeacherId.Add("Суркова С.А.", 90);
            TeacherId.Add("Тесленко Н.Ф.", 443);
            TeacherId.Add("Тупчиева Е.А.", 91);
            TeacherId.Add("Филиппов В.О.", 1312);
            TeacherId.Add("Халезина О.А.", 92);
            TeacherId.Add("Худякова А.А.", 949);
            TeacherId.Add("Чернобай Л.Ю.", 94);
            TeacherId.Add("Чернышев И.Л.", 95);
            TeacherId.Add("Чижова О.П.", 1850);
            TeacherId.Add("Чиняев Г.В.", 78);
            TeacherId.Add("Шанайда С.В.", 97);
            TeacherId.Add("Шапошник М.В.", 98);
            TeacherId.Add("Шинкарева И.В.", 100);
            TeacherId.Add("Шмалько А.Ф.", 101);
            TeacherId.Add("Шостак", 1540);
            TeacherId.Add("Шульга Н.Н.", 102);
            TeacherId.Add("Щелкунов В.", 1706);
            TeacherId.Add("Щербакова О.А.", 103);
            TeacherId.Add("Янцен В.О.", 111);
            TeacherId.Add("Ярош С.И.", 104);
            #endregion
            Token = token;
            GroupName = groupName;
            
            if (GroupName != null)
            {
                //ComboBoxGroups.SelectedItem = GroupName;
            }
            if (Teacher != null)
            {
                ComboBoxTeachers.SelectedItem = Teacher;
            }    
            string responseGroup = Request.GetGroupList(Token);
            JArray jArray = JArray.Parse(responseGroup);
            for (int i = 0; i < jArray.Count; i++)
            {
                JObject jObject = JObject.Parse(jArray[i].ToString());
                groupsList.Add(jObject["group_name"].ToString());
            }

            string responseTeacher = Request.GetTeacherList(Token);
            JArray jTeachers = JArray.Parse(responseTeacher);
            for (int i = 0; i < jTeachers.Count; i++)
            {
                teachersList.Add(jTeachers[i].ToString());
            }
            Teacher = teachersList[0];
            ComboBoxGroups.ItemsSource = groupsList;
            ComboBoxTeachers.ItemsSource = teachersList;
            GetGroupShedule();
            
        }
        private void GetGroupShedule()
        {
            listSheduleMonday.Clear();
            listSheduleTuesday.Clear();
            listSheduleWednesday.Clear();
            listSheduleThursday.Clear();
            listSheduleFriday.Clear();
            listSheduleSaturday.Clear();
            sheduleGridMonday.ItemsSource = new Collection<string>();
            sheduleGridTuesday.ItemsSource = new Collection<string>();
            sheduleGridWednesday.ItemsSource = new Collection<string>();
            sheduleGridThursday.ItemsSource = new Collection<string>();
            sheduleGridFriday.ItemsSource = new Collection<string>();
            sheduleGridSaturday.ItemsSource = new Collection<string>();

            string responseGroupShedule = Request.GroupShedule(Token, GroupName, WeekSetting);
            JArray jAnswer = JArray.Parse(responseGroupShedule);
            #region GroupShedule
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
                                tuesday.pairNum = jobj["p_num"].ToString();
                                tuesday.pairSubject = jobj["p_subj"].ToString();
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
            #endregion

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
            GroupTeachTxt.Text = "Преподаватель";
            GetTeacherShedule();
            WeekChecker = 2;
        }

        private void BtnGroupShedule_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxTeachers.Visibility = Visibility.Hidden;
            ComboBoxGroups.Visibility = Visibility.Visible;
            GroupTeachTxt.Text = "Группа";
            GetGroupShedule();
            WeekChecker = 1;
        }

        private void FirstWeek_Click(object sender, RoutedEventArgs e)
        {
            WeekSetting = 1;
            if(WeekChecker == 1)
            {
                GetGroupShedule();
            }
            else
            {
                GetTeacherShedule();
            }
        }

        private void SecondWeek_Click(object sender, RoutedEventArgs e)
        {
            WeekSetting = 2;
            if (WeekChecker == 1)
            {
                GetGroupShedule();
            }
            else
            {
                GetTeacherShedule();
            }
        }

        private void ComboBoxGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           GroupName = ComboBoxGroups.SelectedItem.ToString();
            GetGroupShedule();
        }

        private void GetTeacherShedule()
        {
            
            listSheduleMonday.Clear();
            listSheduleTuesday.Clear();
            listSheduleWednesday.Clear();
            listSheduleThursday.Clear();
            listSheduleFriday.Clear();
            listSheduleSaturday.Clear();
            sheduleGridMonday.ItemsSource = new Collection<string>();
            sheduleGridTuesday.ItemsSource = new Collection<string>();
            sheduleGridWednesday.ItemsSource = new Collection<string>();
            sheduleGridThursday.ItemsSource = new Collection<string>();
            sheduleGridFriday.ItemsSource = new Collection<string>();
            sheduleGridSaturday.ItemsSource = new Collection<string>();

            foreach(KeyValuePair<string, int> keyValue in TeacherId)
            {
                if (keyValue.Key == Teacher)
                {
                    TeacherUid = keyValue.Value;
                }
            }
            string responseTeachShedule = Request.TeacherShedule(Token, TeacherUid, WeekSetting);
            JArray jAnswer = JArray.Parse(responseTeachShedule);
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
                                monday.pairTeacher  = jobj["p_group"].ToString();
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
                                tuesday.pairTeacher = jobj["p_group"].ToString();
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
                                wednesday.pairTeacher = jobj["p_group"].ToString();
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
                                thursday.pairTeacher = jobj["p_group"].ToString();
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
                                friday.pairTeacher = jobj["p_group"].ToString();
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
                                saturday.pairTeacher = jobj["p_group"].ToString();
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
        private void ComboBoxTeachers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Teacher = ComboBoxTeachers.SelectedItem.ToString();
            GetTeacherShedule();
            
            sheduleGridMonday.Columns[2].Header = "Группа";
            sheduleGridTuesday.Columns[2].Header = "Группа";
            sheduleGridWednesday.Columns[2].Header = "Группа";
            sheduleGridThursday.Columns[2].Header = "Группа";
            sheduleGridFriday.Columns[2].Header = "Группа";
            sheduleGridSaturday.Columns[2].Header = "Группа";
            
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void ComboBoxGroups_TextChanged(object sender, TextChangedEventArgs e)
        {

            ComboBoxGroups.IsDropDownOpen = true;
            var tb = (TextBox)e.OriginalSource;
            tb.Select(tb.SelectionStart + tb.SelectionLength, 0);
            CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(ComboBoxGroups.ItemsSource);
            if (cv != null)
            {
                cv.Filter = s => ((string)s).IndexOf(ComboBoxGroups.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
            }
        }

        private void ComboBoxTeachers_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComboBoxTeachers.IsDropDownOpen = true;
            var tb = (TextBox)e.OriginalSource;
            tb.Select(tb.SelectionStart + tb.SelectionLength, 0);
            CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(ComboBoxTeachers.ItemsSource);
            if (cv != null)
            {
                cv.Filter = s => ((string)s).IndexOf(ComboBoxTeachers.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
            }

        }
    }
}
