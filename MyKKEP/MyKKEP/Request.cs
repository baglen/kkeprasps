using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;

namespace MyKKEP
{
    class Request
    {
        public static string PostLogin()
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create("https://my.kkep.ru/api.php?");
            req.Method = "POST";//тип запроса
           // req.Timeout = 100000;
            req.ContentType = "application/x-www-form-urlencoded";
            string sName = "method=login&login=" + Manager.Login + "&password=" + Manager.Password; //формирование параметров
            byte[] sentData = Encoding.GetEncoding(1251).GetBytes(sName); // перевод в байтовый массив
            req.ContentLength = sentData.Length;
            System.IO.Stream sendStream = req.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();
            System.Net.WebResponse res = req.GetResponse(); //получение ответа
            System.IO.Stream ReceiveStream = res.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(ReceiveStream, Encoding.UTF8);
            Char[] read = new Char[256];
            int count = sr.Read(read, 0, 256);
            string Out = String.Empty;
            while (count > 0)
            {
                String str = new String(read, 0, count);
                Out += str;
                count = sr.Read(read, 0, 256);
            }
            return Out;
        }
        //artem
        public static string GroupShedule()
        {
            System.Net.WebRequest reqShedule = System.Net.WebRequest.Create("https://my.kkep.ru/api.php?");
            reqShedule.Method = "POST";//тип запроса
            reqShedule.ContentType = "application/x-www-form-urlencoded";
            string sName = "method=get_stud_rasp&token=" + Manager.Token + "&group=" + Manager.GroupName + "&week=" + Manager.WeekSetting; //формирование параметров
            byte[] sentData = Encoding.GetEncoding(1251).GetBytes(sName); // перевод в байтовый массив
            reqShedule.ContentLength = sentData.Length;
            System.IO.Stream sendStream = reqShedule.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();
            System.Net.WebResponse res = reqShedule.GetResponse(); //получение ответа
            System.IO.Stream ReceiveStream = res.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(ReceiveStream, Encoding.UTF8);
            Char[] read = new Char[256];
            int count = sr.Read(read, 0, 256);
            string Out = String.Empty;
            while (count > 0)
            {
                String str = new String(read, 0, count);
                Out += str;
                count = sr.Read(read, 0, 256);
            }
            return Out;
        }
        public static string GetTeacherList()
        {
            System.Net.WebRequest reqTeacherList = System.Net.WebRequest.Create("https://my.kkep.ru/api.php?");
            reqTeacherList.Method = "POST";//тип запроса
            reqTeacherList.ContentType = "application/x-www-form-urlencoded";
            string sName = "method=get_prep_list&token=" + Manager.Token; //формирование параметров
            byte[] sentData = Encoding.GetEncoding(1251).GetBytes(sName); // перевод в байтовый массив
            reqTeacherList.ContentLength = sentData.Length;
            System.IO.Stream sendStream = reqTeacherList.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();
            System.Net.WebResponse res = reqTeacherList.GetResponse(); //получение ответа
            System.IO.Stream ReceiveStream = res.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(ReceiveStream, Encoding.UTF8);
            Char[] read = new Char[256];
            int count = sr.Read(read, 0, 256);
            string Out = String.Empty;
            while (count > 0)
            {
                String str = new String(read, 0, count);
                Out += str;
                count = sr.Read(read, 0, 256);
            }
            return Out;
        }
        public static string GetGroupList()
        {
            System.Net.WebRequest reqGroupList = System.Net.WebRequest.Create("https://my.kkep.ru/api.php?");
            reqGroupList.Method = "POST";//тип запроса
            reqGroupList.ContentType = "application/x-www-form-urlencoded";
            string sName = "method=get_group_list&token=" + Manager.Token; //формирование параметров
            byte[] sentData = Encoding.GetEncoding(1251).GetBytes(sName); // перевод в байтовый массив
            reqGroupList.ContentLength = sentData.Length;
            System.IO.Stream sendStream = reqGroupList.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();
            System.Net.WebResponse res = reqGroupList.GetResponse(); //получение ответа
            System.IO.Stream ReceiveStream = res.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(ReceiveStream, Encoding.UTF8);
            Char[] read = new Char[256];
            int count = sr.Read(read, 0, 256);
            string Out = String.Empty;
            while (count > 0)
            {
                String str = new String(read, 0, count);
                Out += str;
                count = sr.Read(read, 0, 256);
            }
            return Out;
        }
        public static string TeacherShedule(int id, int week)
        {
            System.Net.WebRequest reqShedule = System.Net.WebRequest.Create("https://my.kkep.ru/api.php?");
            reqShedule.Method = "POST";//тип запроса
            reqShedule.ContentType = "application/x-www-form-urlencoded";
            string sName = "method=get_prep_rasp&token=" + Manager.Token + "&teacher=" + id + "&week=" + week; //формирование параметров
            byte[] sentData = Encoding.GetEncoding(1251).GetBytes(sName); // перевод в байтовый массив
            reqShedule.ContentLength = sentData.Length;
            System.IO.Stream sendStream = reqShedule.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();
            System.Net.WebResponse res = reqShedule.GetResponse(); //получение ответа
            System.IO.Stream ReceiveStream = res.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(ReceiveStream, Encoding.UTF8);
            Char[] read = new Char[256];
            int count = sr.Read(read, 0, 256);
            string Out = String.Empty;
            while (count > 0)
            {
                String str = new String(read, 0, count);
                Out += str;
                count = sr.Read(read, 0, 256);
            }
            return Out;
        }
    }
}
