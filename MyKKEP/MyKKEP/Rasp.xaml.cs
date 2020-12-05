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

namespace MyKKEP
{
    /// <summary>
    /// Логика взаимодействия для Rasp.xaml
    /// </summary>
    public partial class Rasp : Page
    {
        private static string Token;
        private static string GroupName;
        public Rasp(string token, string groupName)
        {
            InitializeComponent();
            Token = token;
            GroupName = groupName;
            if (GroupName != null)
            {
                ComboBoxGroups.SelectedItem = GroupName;
            }
            string response = Request.GetGroupList(Token);
            JArray jArray = JArray.Parse(response);
            for (int i = 0; i < jArray.Count; i++)
            {
                JObject jObject = JObject.Parse(jArray[i].ToString());
                ComboBoxGroups.Items.Add(jObject["group_name"].ToString());
            }
        }
    }
}
