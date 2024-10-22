using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace SchedulerExeAutoRestart
{
    static class Program
    {
        static string Exe = "DENSOScheduler";
        static bool _bl = true;       
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
          
            if (Process.GetProcessesByName("DENSOScheduler").Length > 1)
            {                
                return;
            }
            
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(5);

            var timer = new System.Threading.Timer((e) =>
            {
                foreach (Process p in System.Diagnostics.Process.GetProcessesByName(Exe))
                {
                    p.Kill();
                    p.WaitForExit();
                    break;
                }
                Thread.Sleep(1000);
                Process.Start(Application.StartupPath + "\\" + Exe);
                writeToLogFile("Restart DENSOScheduler Exe");
                Thread.Sleep(100000);
            }, null, startTimeSpan, periodTimeSpan);
            
            while (_bl == true)
            {
                try
                {
                    Application.DoEvents();
                    if (Process.GetProcessesByName(Exe).Length == 0)
                    {
                        Process.Start(Application.StartupPath + "\\" + Exe);
                        writeToLogFile("File DENSOScheduler Exe Start");                        
                    }

                    //string _sCurrentTime = GetRebootDateTime();
                    //if (_sCurrentTime == "06:30:00")
                    //{
                    //    foreach (Process p in System.Diagnostics.Process.GetProcessesByName(Exe))
                    //    {
                    //        p.Kill();
                    //        p.WaitForExit();
                    //        break;
                    //    }
                    //    Thread.Sleep(1000);
                    //    Process.Start(Application.StartupPath + "\\" + Exe);
                    //    writeToLogFile("Restart File Movement Sever Scheduler Exe");
                    //    Thread.Sleep(100000);
                    //}
                }
                catch (Exception ex)
                {
                    writeToLogFile(ex.Message);
                }
                Thread.Sleep(500);
            }     
        }
        static string GetRebootDateTime()
        {
            string _sReturn = "";
            _sReturn = DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Second.ToString().PadLeft(2, '0');
            return _sReturn;
        }
       
        static void writeToLogFile(string logMessage)
        {
            try
            {
                string strLogMessage = string.Empty;
                string LogFile = Application.StartupPath + "\\Log\\" + DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString() + "Log.txt";
                StreamWriter swLog;
                strLogMessage = string.Format("{0}: {1}", DateTime.Now, logMessage);
                if (!File.Exists(LogFile))
                {
                    swLog = new StreamWriter(LogFile);
                }
                else
                {
                    swLog = File.AppendText(LogFile);
                }
                swLog.WriteLine(strLogMessage);
                swLog.WriteLine();
                swLog.Close();
                swLog.Dispose();
            }
            catch (Exception ex)
            {
            }
        } 

    }
}
