using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace DENSOScheduler
{
    public partial class SchedulerSetting : Form
    {
        Bussiness _Bussiness = new Bussiness();
        MyMail _MyMail = new MyMail(); 
        public SchedulerSetting()
        {
            InitializeComponent();
        }

        private void SchedulerSetting_Load(object sender, EventArgs e)
        {
            try
            {
                string[] _str=null;
                this.Text = "(SatoApps)(Configration)(Version : " + Application.ProductVersion + " )";                
                if (_Bussiness.PopulateSettingFile() !=-1)
                {
                    for (int i = 0; i < GlobalVariable.mBarcodeCorrectionTime.Count; i++)
                    {
                        dtmailTime.Text = GlobalVariable.mBarcodeCorrectionTime[i].ToString();
                    }                    
                    txtSapClient.Text = GlobalVariable.mSapClient;
                    txtSapLng.Text = GlobalVariable.mSapLng ;
                    txtSapServer.Text = GlobalVariable.mSapServer ;
                    txtSmtpPort.Text = Convert.ToInt32(GlobalVariable.mSmtpPort).ToString ();
                    txtSmtpHost.Text = GlobalVariable.mSmtpHost;
                    txtSapPwd.Text = GlobalVariable.mSapPassword ;
                    txtSapSysNo.Text = GlobalVariable.mSapSysNo ;
                    txtSapUserId.Text = GlobalVariable.mSapUser ;
                    txtSqlDb.Text =GlobalVariable.mDb ;
                    txtSqlPwd.Text = GlobalVariable.mDbPassword ;
                    txtSqlServer.Text = GlobalVariable.mDbServer ;
                    txtSqlUser.Text =GlobalVariable.mDbUser ;                    
                    txtSenderId.Text = GlobalVariable.mSenderId ;
                    txtSenderPass.Text = GlobalVariable.mSenderPassword ;
                    if (GlobalVariable.mMailId[0] != null)
                    {
                        _str = GlobalVariable.mMailId[0].Split(',');
                        for (Int32 i = 0; i < _str.Length; i++)
                        {
                            DG.Rows.Add(_str[i].ToString().Trim());
                        }
                    }
                    if (GlobalVariable.mMailId[1] != null)
                    {
                        _str = GlobalVariable.mMailId[1].Split(',');
                        for (Int32 i = 0; i < _str.Length; i++)
                        {
                            dg1.Rows.Add(_str[i].ToString().Trim());
                        }
                    }
                }                                
            }
            catch (Exception ex)
            {
                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "SatoApps" + "  ::  SchedulerSetting_Load  ", ex.Message);
                MessageBox.Show(ex.Message, GlobalVariable.mSatoApps, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public void ScheduleWriteSetting()
        {
            StreamWriter _Writer = default(StreamWriter);
            string _sTake="";
                try
                {
                    GlobalVariable.mBarcodeCorrectionTime.Add (dtmailTime.Text.Trim());
                    GlobalVariable.mSapServer = txtSapServer.Text.Trim();
                    GlobalVariable.mSapClient = txtSapClient.Text.Trim();
                    GlobalVariable.mSapLng = txtSapLng.Text.Trim();
                    GlobalVariable.mSapPassword= txtSapPwd.Text.Trim();
                    GlobalVariable.mSapSysNo = txtSapSysNo.Text.Trim();
                    GlobalVariable.mSapUser = txtSapUserId.Text.Trim();
                    GlobalVariable.mDb = txtSqlDb.Text.Trim();
                    GlobalVariable.mDbPassword = txtSqlPwd.Text.Trim();
                    GlobalVariable.mDbServer = txtSqlServer.Text.Trim();
                    GlobalVariable.mDbUser = txtSqlUser.Text.Trim();
                    _sTake = "";
                    for (int i = 0; i < DG.Rows.Count-1; i++)
                    {
                       if (DG.Rows[i].Cells[0].Value.ToString().Trim() != "" & DG.Rows[i].Cells[0].Value.ToString().Trim() != null)
                            {
                                if (_sTake=="")
                                    _sTake=DG.Rows[i].Cells[0].Value.ToString().Trim();
                                else
                                    _sTake= _sTake + "," + DG.Rows[i].Cells[0].Value.ToString().Trim();
                            }                                              
                    }
                    GlobalVariable.mMailId[0] = _sTake;
                    _sTake = "";
                    for (int i = 0; i < dg1.Rows.Count-1; i++)
                    {
                        if (dg1.Rows[i].Cells[0].Value.ToString().Trim() != "" & dg1.Rows[i].Cells[0].Value.ToString().Trim() != null)
                        {
                            if (_sTake == "")
                                _sTake = dg1.Rows[i].Cells[0].Value.ToString().Trim();
                            else
                            _sTake = _sTake + "," + dg1.Rows[i].Cells[0].Value.ToString().Trim();
                        }                       
                    }
                    GlobalVariable.mMailId[1] = _sTake;
                    GlobalVariable.mSenderId = txtSenderId.Text.Trim();
                    GlobalVariable.mSenderPassword = txtSenderPass.Text.Trim();
                    _Writer = new StreamWriter(Application.StartupPath + "\\SatoScheduler.ini", false);                    
                    _Writer.WriteLine("[SAP_LOCAL_SETTING]");
                    _Writer.WriteLine("*****************************************");
                    _Writer.WriteLine("SAP_SERVER=" + GlobalVariable.mSapServer);
                    _Writer.WriteLine("SAP_CLIENT=" + GlobalVariable.mSapClient);
                    _Writer.WriteLine("SAP_LANGUAGE=" + GlobalVariable.mSapLng);
                    _Writer.WriteLine("SAP_SYSTEM_NO=" + GlobalVariable.mSapSysNo);
                    _Writer.WriteLine("SAP_USER=" + GlobalVariable.mSapUser);
                    _Writer.WriteLine("SAP_PASSWORD=" + GlobalVariable.mSapPassword);
                    _Writer.WriteLine("*****************************************");
                    _Writer.WriteLine("[SAP_LOCAL_SETTING]");
                    _Writer.WriteLine("[SQL_LOCAL_SETTING]");
                    _Writer.WriteLine("*****************************************");
                    _Writer.WriteLine("SQL_DATABASE_NAME=" + GlobalVariable.mDb);
                    _Writer.WriteLine("SQL_SERVER_NAME=" + GlobalVariable.mDbServer);
                    _Writer.WriteLine("SQL_USER_NAME=" + GlobalVariable.mDbUser);
                    _Writer.WriteLine("SQL_PASSWORD=" + GlobalVariable.mDbPassword);
                    _Writer.WriteLine("*****************************************");
                    _Writer.WriteLine("[SQL_LOCAL_SETTING]");
                    _Writer.WriteLine("[MAIL_CONFIGRATION]");
                    _Writer.WriteLine("*****************************************");
                    _Writer.WriteLine("SMTP_HOST=" + GlobalVariable.mSmtpHost);
                    _Writer.WriteLine("SMTP_PORT=" + GlobalVariable.mSmtpPort);   
                    _Writer.WriteLine("SENDER_ID=" + GlobalVariable.mSenderId);
                    _Writer.WriteLine("SENDER_PASSWORD=" + GlobalVariable.mSenderPassword);
                    if (GlobalVariable.mMailId[0] != null)                    
                        _Writer.WriteLine("DAILY_CORRECTION_MAIL_ID=" + GlobalVariable.mMailId[0]);
                    for (int i = 0; i < GlobalVariable.mBarcodeCorrectionTime.Count; i++)
                    {
                        _Writer.WriteLine("DAILY_CORRECTION_MAIL_INTERVAL=" + GlobalVariable.mBarcodeCorrectionTime[i].ToString ());
                    }                    
                    if (GlobalVariable.mMailId[1] != null)
                        _Writer.WriteLine("SAP_PACKING_SLIP_MAIL_ID=" + GlobalVariable.mMailId[1]);
                    for (int i = 0; i < GlobalVariable.mPackingTime.Count; i++)
                    {
                        _Writer.WriteLine("SAP_PACKING_SLIP_MAIL_INTERVAL=" + GlobalVariable.mPackingTime[i].ToString());
                    }
                    for (int i = 0; i < GlobalVariable.mPackingTimeDailyBasis.Count; i++)
                    {
                        _Writer.WriteLine("SAP_PACKING_SLIP_MAIL_ON_DAILY_BASIS=" + GlobalVariable.mPackingTimeDailyBasis[i].ToString());
                    }
                    for (int i = 0; i < GlobalVariable.mBarcodeTempPartTime.Count; i++)
                    {
                        _Writer.WriteLine("DAILY_TEMP_PART_MAIL=" + GlobalVariable.mBarcodeTempPartTime[i].ToString());
                    }
                    for (int i = 0; i < GlobalVariable.mAllTempPartTime.Count; i++)
                    {
                        _Writer.WriteLine("DAILY_ALL_TEMP_PART_MAIL=" + GlobalVariable.mAllTempPartTime[i].ToString());
                    }                                  
                    _Writer.WriteLine("*****************************************");
                    _Writer.WriteLine("[MAIL_CONFIGRATION]");
                    _Writer.Close();
                    _Writer = null;
                    MessageBox.Show("SETTING FILE SAVE SUCESSFULLY", GlobalVariable.mSatoApps, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        private void btnSqlReset_Click(object sender, EventArgs e)
        {
            txtSqlDb.Enabled = true ;
            txtSqlPwd.Enabled =  true ;
            txtSqlServer.Enabled =  true ;
            txtSqlUser.Enabled = true;
        }

        private void btnSAPReset_Click(object sender, EventArgs e)
        {
              txtSapClient.Enabled = true ;
              txtSapUserId.Enabled = true;
            txtSapLng.Enabled = true ;
            txtSapPwd.Enabled = true ;
            txtSapServer.Enabled = true ;
            txtSapSysNo.Enabled = true;
        }

        private void btnDeletePicklistReset_Click(object sender, EventArgs e)
        {
            dtmailTime.Enabled = true ;
            DG.Enabled = true;
            txtSenderId.Enabled = true ;
            txtSenderPass.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("ARE YOU SURE THE SETTING FILE IS CORRECT", GlobalVariable.mSatoApps, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                {
                    ScheduleWriteSetting();
                }
            }
            catch (Exception ex)
            {
                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "SatoApps" + "  ::  btnSave_Click  ", ex.Message);
                MessageBox.Show(ex.Message, GlobalVariable.mSatoApps, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPlan _frmPlan = new frmPlan();
            _frmPlan.ShowDialog();
        }

        private void btnMailReset_Click(object sender, EventArgs e)
        {            
            dg1.Enabled = true;          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSmtpHost.Enabled = true;
            txtSmtpPort.Enabled = true;
            txtSenderId.Enabled = true;
            txtSenderPass.Enabled = true;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string _sBody = "Dear Sir,\n\n";
            _sBody = _sBody + "This is test mail.\n";
            _sBody = _sBody + "Kindly ignor it.\n\n";
            _sBody = _sBody + "Thanks & Regards,\n";
            _sBody = _sBody + "Barcode Support Team\n\n";
            ArrayList alAttachments = new ArrayList();
            //alAttachments.Add(Application.StartupPath + @"\BarcodeCorrectionReport.csv".ToString());
            if (GlobalVariable.mMailId[0] == null)
            {
                MessageBox.Show("Please save email id in grid","Input error");
                return;
            }            
            string _sResult = _MyMail.SendMail(GlobalVariable.mSenderId, GlobalVariable.mSenderPassword
                                                , GlobalVariable.mMailId[0], GlobalVariable.mSmtpHost
                                                , GlobalVariable.mSmtpPort, _sBody, alAttachments,"TestMail");
            if (_sResult=="1")
                MessageBox.Show("Message send sucessfully", "Information");
            else
                MessageBox.Show("Problem in sending mail.\n See log file", "Information");

        }           
    }
}
