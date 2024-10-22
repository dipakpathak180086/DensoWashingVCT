using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using SatoLib;
using System.IO;

namespace DENSOScheduler
{
    public partial class frmGetSet : Form
    {
        public frmGetSet()
        {
            InitializeComponent();
        }
        #region Variables



        private System.Timers.Timer VCTPath1Timer = null;
        private System.Timers.Timer VCTPath2Timer = null;
        #endregion
        Bussiness _Bussiness = new Bussiness();
        ClsKanbanDetails _clsUpload = new ClsKanbanDetails();
        MyMail _MyMail = new MyMail();
        private void btnSetting_Click(object sender, EventArgs e)
        {
            SchedulerSetting _SchedulerSetting = new SchedulerSetting();
            _SchedulerSetting.ShowDialog();
        }

        private void frmGetSet_Load(object sender, EventArgs e)
        {
            try
            {

              
                TrayIcon.Text = "SatoAppsScheduler - FTP Upload Scheduler (Running)";
                NotifyWindow.DefaultText = "FTP Upload Scheduler";
                NotifyWindow.Notify("FTP Upload Scheduler (Running)", 3000);
                this.Text = "(SatoApps)(FTPUpload)(Version : " + Application.ProductVersion + " )";
                if (_Bussiness.ConnectToDatabase() != false)
                    lblSqlStatus.BackColor = Color.Green;
                else
                    lblSqlStatus.BackColor = Color.Red;
                BindStation();
                btnStart_Click(sender, e);
                
                //ClsKanbanDetails clsKanban = new ClsKanbanDetails();
                //clsKanban.GetVCTPath2();
            }
            catch (Exception ex)
            {
                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "SatoApps" + "  ::  frmGetSet_Load  ", ex.Message);
                MessageBox.Show(ex.Message, GlobalVariable.mSatoApps, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void frmGetSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnStart.Enabled = true;
           
            ThreadEnableUploadToFtp = false;
                    
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            try
            {
                NotifyWindow.DefaultText = "Denso VCT Scheduler";
                NotifyWindow.Notify("Denso VCT Scheduler (Running)", 3000);
                this.Hide();

            }
            catch (Exception)
            {
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
        
            ThreadEnableUploadToFtp = false;
            ShowAccessScreen();
            if (GlobalVariable.mAccessUser != "")
            {
                GlobalVariable.mAccessUser = "";
                this.Close();
                this.Dispose();
            }
           
        }

        private void btnSqlTest_Click(object sender, EventArgs e)
        {
            if (_Bussiness.ConnectToDatabase() != false)
            {
                lblSqlStatus.BackColor = Color.Green;
                MessageBox.Show("Sucessfully connected to database", GlobalVariable.mSatoApps, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Database Connection Error", GlobalVariable.mSatoApps, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                lblSqlStatus.BackColor = Color.Red;
            }
        }

        

        private void mnuHideWindow_Click(object sender, EventArgs e)
        {
            NotifyWindow.DefaultText = "Denso VCT Scheduler";
            NotifyWindow.Notify("Denso VCT Scheduler (Running)", 3000);
            this.Hide();
        }

        private void mnuExitApp_Click(object sender, EventArgs e)
        {
            ShowAccessScreen();
            if (GlobalVariable.mAccessUser != "")
            {
                GlobalVariable.mAccessUser = "";
                btnExit_Click(sender, e);
            }
        }

        private void mnuShow_Click(object sender, EventArgs e)
        {
            this.BringToFront();
            NotifyWindow.DefaultText = "FTP Upload Scheduler";
            NotifyWindow.Notify("FTP Upload Scheduler (Running)", 3000);
            this.Show();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            ShowAccessScreen();
            if (GlobalVariable.mAccessUser != "")
            {
                GlobalVariable.mAccessUser = "";
                btnExit_Click(sender, e);
            }
           
        }
        void ShowAccessScreen()
        {
            frmAccessPassword oFrmLogin = new frmAccessPassword();
            oFrmLogin.ShowDialog();
            if (GlobalVariable.mAccessUser != "" && oFrmLogin.IsCancel == true)
            {
                // lblShowMessage();
            }
        }
        void BindStation()
        {
            try
            {
                cbStation.Items.Clear();
                cbStation.Items.Insert(0, "--Select--");
                var directoryParth1 = new DirectoryInfo(GlobalVariable.mVCTFolderPath1);
                var directoryParth2 = new DirectoryInfo(GlobalVariable.mVCTFolderPath2);
                cbStation.Items.Add("01");
                cbStation.Items.Add("02");
                cbStation.SelectedIndex = 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        void GetVCTPath2()
        {
            try
            {
                        _clsUpload.GetVCTPath2();
                       
            }
            catch (Exception ex)
            {
                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtError
                                                            , "GoUpload To GetVCTPath2 Error", ex.Message.ToString());
            }
        }
        void GetVCTPath1()
        {
            try
            {

                _clsUpload.GetVCTPath1();

            }
            catch (Exception ex)
            {
                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtError
                                                            , "GoUpload To GetVCTPath2 Function Error", ex.Message.ToString());
            }
        }


        bool ThreadEnableUploadToFtp = false;
       
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                btnStart.Enabled = false;
                btnManaul.Enabled = false;
                cbFileName.Enabled = false;
                if (cbStation.SelectedIndex > 0) { cbStation.SelectedIndex = 0; }
                if (cbFileName.SelectedIndex > 0) { cbFileName.SelectedIndex = 0; }
                cbStation.Enabled = false;
                ThreadEnableUploadToFtp = true;
                //start timer
                //put this into your if statement
                VCTPath1Timer = new System.Timers.Timer(GlobalVariable.mVCTDataUploadTime);
                VCTPath1Timer.Elapsed += VCTPath1Timer_Elapsed;
                VCTPath1Timer.AutoReset = true;
                VCTPath1Timer.Enabled = true;
                VCTPath1Timer.Start();

                VCTPath2Timer = new System.Timers.Timer(GlobalVariable.mVCTDataUploadTime);
                VCTPath2Timer.Elapsed += VCTPath2Timer_Elapsed;
                VCTPath2Timer.AutoReset = true;
                VCTPath2Timer.Enabled = true;
                VCTPath2Timer.Start();

                //_Td = new Thread(GoUploadToFTP);
                //_Td.Start();
            }
            catch (Exception ex)
            {
                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtError
                                                            , "btnStart_Click", ex.Message.ToString());
            }
        }

     

        private readonly object AndonLock = new object();
        private void VCTPath2Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (AndonLock)
            {
                GetVCTPath2();
                
            }
        }

        private readonly object Lock = new object();
        private void VCTPath1Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (Lock)
            {
                GetVCTPath1();
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnManaul.Enabled = true;
            cbFileName.Enabled = true;
            cbStation.Enabled = true;
            //VCTPath1Timer = null;
            VCTPath1Timer.Enabled = false;
            VCTPath1Timer.Stop();
           // VCTPath2Timer = null;
            VCTPath2Timer.Enabled = false;
            VCTPath2Timer.Stop();
            ThreadEnableUploadToFtp = false;
           
        }
        string GetRebootDateTime()
        {
            string _sReturn = "";
            _sReturn = DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Second.ToString().PadLeft(2, '0');
            return _sReturn;
        }

        private void cbStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbStation.SelectedIndex > 0)
                {
                    cbFileName.Items.Clear();
                    cbFileName.Items.Insert(0, "--Select--");

                    if (cbStation.Text.Equals("01"))
                    {
                        var directory01 = new DirectoryInfo(GlobalVariable.mVCTFolderPath1);
                        List<FileInfo> myfiles = directory01.GetFiles().OrderByDescending(f => f.LastWriteTime).ToList();
                        for (int iF = 0; iF < myfiles.Count; iF++)
                        {
                            if (myfiles[iF].Exists)
                            {
                                string fileName = Path.GetFileName(myfiles[iF].FullName);
                                cbFileName.Items.Add(fileName);
                                cbFileName.SelectedIndex = 0;
                            }
                        }
                    }
                    if (cbStation.Text.Equals("02"))
                    {
                        var directory02 = new DirectoryInfo(GlobalVariable.mVCTFolderPath2);
                        List<FileInfo> myfiles = directory02.GetFiles().OrderByDescending(f => f.LastWriteTime).ToList();
                        for (int iF = 0; iF < myfiles.Count; iF++)
                        {
                            if (myfiles[iF].Exists)
                            {
                                string fileName = Path.GetFileName(myfiles[iF].FullName);
                                cbFileName.Items.Add(fileName);
                                cbFileName.SelectedIndex = 0;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        private void btnManaul_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbStation.Text == "01" && cbFileName.SelectedIndex > 0)
                {
                    DialogResult dre = MessageBox.Show("Are you sure want to run manual???", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dre == DialogResult.No)
                    {
                        return;
                    }
                    _clsUpload.GetVCTPath1(cbFileName.Text.Trim());
                }
                if (cbStation.Text == "02" && cbFileName.SelectedIndex > 0)
                {
                    DialogResult dre = MessageBox.Show("Are you sure want to run manual???", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dre == DialogResult.No)
                    {
                        return;
                    }
                    _clsUpload.GetVCTPath2(cbFileName.Text.Trim());
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
