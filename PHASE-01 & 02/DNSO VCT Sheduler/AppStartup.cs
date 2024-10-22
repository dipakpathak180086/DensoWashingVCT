using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Collections;
using System.Diagnostics;

namespace DENSOScheduler
{
    static class AppStartup
    {
        static string Exe = "SchedulerExeAutoRestart";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        /// 
        [STAThread]
        static void Main()
        {
             
            if (Process.GetProcessesByName("DENSOScheduler").Length > 1)
            {
                return;
            }
            try
            {
                if (Process.GetProcessesByName(Exe).Length == 0)
                {
                    Process.Start(Application.StartupPath + "\\" + Exe);                    
                }
            }
            catch (Exception)
            {               
            }          
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bussiness _Bussiness = new Bussiness();
            try
            {
                DirectoryInfo _dir = new DirectoryInfo(Application.StartupPath + "\\" + "SatoAppResource");
                if (_dir.Exists == false)
                {
                    _dir.Create();
                }
                

                _dir = null;
                _dir = new DirectoryInfo(Application.StartupPath + @"\" + "SatoOutPut");
                if (_dir.Exists == false)
                {
                    _dir.Create();
                }
                _dir = null;
                _dir = new DirectoryInfo(Application.StartupPath + @"\" + "FtpSatoOut");
                if (_dir.Exists == false)
                {
                    _dir.Create();
                }
                
                
                SatoLib.SatoLogger _obj = new SatoLib.SatoLogger();                
                _obj.ChangeInterval = SatoLib.SatoLogger.ChangeIntervals.ciDaily;
                _obj.EnableLogFiles = true;
                _obj.LogDays = 30;
                _obj.LogFilesExt = "log";
                _obj.LogFilesPath = Application.StartupPath;
                _obj.LogFilesPrefix = "SatoApps";
                _obj.StartLogging();
                _obj.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "SatoAppsScheduler :: Initialize" + "  ::  Main", "Initializing Application.......");
                GlobalVariable.AppLog  = _obj;
                _Bussiness.PopulateSettingFile();
                if (_Bussiness.ConnectToDatabase() == false)
                {
                    MessageBox.Show("Error in connecting to Database-Server" + "\n" + "Contact To Barcode Support Engineer/Restart Application/Network Problem", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // GlobalVariable.AppLog.StopLogging();
                   // Application.Run(new SchedulerSetting());
                }
                else
                {                                        
                    Application.Run(new frmGetSet());
                 
                }
            }
            catch (Exception ex)
            {
                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "SatoAppInitialize" + "  ::  Main  ", "Login " + ex.Message);
            }          
        }
       

    }
}
