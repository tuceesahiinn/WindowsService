using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsServiceDeneme
{
    public class InnerOperation
    {
        Timer timer = new Timer();
        public void Start()
        {
            WriteToFile("Service başladı." + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 300000;
            timer.Enabled = true;
        }
        public void Stop()
        {
            WriteToFile("Service Durduruldu"+DateTime.Now);
        }

        public void WriteToFile(string message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt"; ;
            if (!File.Exists(filepath))
            {
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(message);
                }
            }
        }
        private void OnElapsedTime(object source,ElapsedEventArgs e)
        {
            WriteToFile("Service Guncellendi " + DateTime.Now);
        }
    }
}
