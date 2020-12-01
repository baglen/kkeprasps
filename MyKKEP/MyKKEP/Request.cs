using System;
using System.IO;
using System.Net;
using System.Text;

namespace MyKKEP
{
    class Request
    {
        public static string PostLogin(string login, string password)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create("https://my.kkep.ru/api.php?");
            req.Method = "POST";//тип запроса
           // req.Timeout = 100000;
            req.ContentType = "application/x-www-form-urlencoded";
            string sName = "method=login&login=" + login + "&password=" + password; //формирование параметров
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
    }
}
