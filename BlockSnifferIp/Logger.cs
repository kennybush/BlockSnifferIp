using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlockSnifferIp
{
    public enum LogType
    {
        Info,
        Warning,
        Error,
        Critical,
    }

    public class Logger
    {
        public static void Log(string sInfo, LogType eventtype)
        {
            DateTime dt = DateTime.Now;
            string content = string.Format("{0,-20} {1,-10} {2}", dt.ToLocalTime().ToString(), eventtype.ToString(), sInfo);
            WriteToFile(content);
        }

        static void WriteToFile(string content) {
            FileStream fs = new FileStream(System.AppDomain.CurrentDomain.BaseDirectory + "\\Event.log", FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(content);
            sw.Close();
            fs.Close();
        }
    }
}
