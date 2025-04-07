using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using DENSO_VCT_COMMON;
using DENSO_VCT_BL;
using DENSO_VCT_PL;
using DENSO_VCT_PL;
using DENSO_VCT_BL;

namespace DENSO_VCT_APP
{
    public partial class frmMenu : Form
    {
        #region Variables

        private bool isCancel = false;
        private BL_ENABLE_DISABLE_ASSY _blObj = null;
        private PL_ENABLE_DISABLE_ASSY _plObj = null;

        #endregion

        #region Form Methods

        public frmMenu()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {

            }
        }
        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                cp.ClassStyle |= 0x08;
                return cp;
            }
        }
        private void frmModelMaster_Load(object sender, EventArgs e)
        {
            try
            {
                // this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                //this.Bounds = Screen.PrimaryScreen.Bounds;
                //this.TopMost = true;
                // SetMenuRight();
                lblWelcome.TextAlign = ContentAlignment.MiddleRight;
                lblWelcome.Text = "© Developed by SATO Argox India Pvt Ltd." + GlobalVariable.mSatoAppsLoginUser;
                Left = Top = 0;
                Width = Screen.PrimaryScreen.WorkingArea.Width;
                Height = Screen.PrimaryScreen.WorkingArea.Height;
                //AutoLogOut timer
                CheckEnabledDisableAssyProcess();
            }
            catch (Exception ex)
            {

            }
        }

        private void OFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        #endregion

        #region Button Event

        private void picLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Menu Click Events
        private void chkDisableAssy_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void chkDisableAssy_Click(object sender, EventArgs e)
        {
            try
            {


                ShowAccessScreen();
                if (GlobalVariable.mAccessUser != "")
                {

                    if (chkDisableAssy.Checked)
                    {
                        DialogResult result = MessageBox.Show(
               $"Are you sure you want to disable the entire Assembly Scanning Process?",
               "Confirmation",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning);
                        if (result == DialogResult.No)
                        {
                            GlobalVariable.mAccessUser = "";
                            return;
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show(
                 $"Are you sure you want to enable the entire Assembly Scanning Process?",
                 "Confirmation",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning);
                        if (result == DialogResult.No)
                        {
                            GlobalVariable.mAccessUser = "";
                            return;
                        }

                    }


                    _blObj = new BL_ENABLE_DISABLE_ASSY();
                    _plObj = new PL_ENABLE_DISABLE_ASSY();
                    if (chkDisableAssy.Checked)
                        _plObj.DbType = "DISABLE";
                    else
                        _plObj.DbType = "ENBALE";
                    DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                    GlobalVariable.mAccessUser = "";
                    if (chkDisableAssy.Checked)
                    {
                        
                        GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Entire Assembly Process Successfully Disabled.", 1);
                    }
                    else
                    {
                        
                        GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Entire Assembly Process Successfully Enabled.", 1);
                    }
                    CheckEnabledDisableAssyProcess();
                    Application.DoEvents();
                }
                else
                    chkDisableAssy.Checked = CheckEnabledDisableAssyProcess();
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    GlobalVariable.ShowCustomMessageBox(this, ex.Message);
                });

            }
        }
        private void picMasterConfig_Click(object sender, EventArgs e)
        {
            ShowAccessScreen();
            if (GlobalVariable.mAccessUser != "")
            {
                pnlMaster.Visible = true;
                pnlStep03.Visible = true;

                GlobalVariable.mAccessUser = "";
                // pnlMaster.Visible = false;
            }


        }




        #endregion

        #region Method

        private bool CheckEnabledDisableAssyProcess()
        {
            bool _isFlag = false;
            try
            {
                _blObj = new BL_ENABLE_DISABLE_ASSY();
                _plObj = new PL_ENABLE_DISABLE_ASSY();
                _plObj.DbType = "CHK_ENABLE_DISABLE";
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["Result"].Equals("DISABLED"))
                    {
                        chkDisableAssy.Text = "Tray Scanning Traceability System Disabled";
                        chkDisableAssy.Checked = true;
                        _isFlag = true;
                        for (int i = 0; i < pnlStep03.Controls.Count; i++)
                        {
                            if (pnlStep03.Controls[i] is Button)
                            {
                                Button btn = pnlStep03.Controls[i] as Button;
                                btn.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        chkDisableAssy.Text = "Tray Scanning Traceability System Enabled";
                        chkDisableAssy.Checked = false;
                        _isFlag = false;
                        for (int i = 0; i < pnlStep03.Controls.Count; i++)
                        {
                            if (pnlStep03.Controls[i] is Button)
                            {
                                Button btn = pnlStep03.Controls[i] as Button;
                                btn.Enabled = true;
                            }
                        }

                    }
                }

                return _isFlag;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Timer Event
        private void timerAutoLogOut_Tick(object sender, EventArgs e)
        {

        }

        private void timerReOiling_Tick(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

































        #endregion

        private void btnAddLotEntry_Click(object sender, EventArgs e)
        {

            frmAddParentMenu frm = new frmAddParentMenu();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();

        }

        private void btnAddModel_Click(object sender, EventArgs e)
        {
            ShowAccessScreen();
            if (GlobalVariable.mAccessUser != "")
            {
                frmModelMaster frm = new frmModelMaster();
                frm.Show();
                frm.FormClosing += OFrm_FormClosing;
                this.Hide();
                GlobalVariable.mAccessUser = "";
                pnlMaster.Visible = false;
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
        private void btnManagePassword_Click(object sender, EventArgs e)
        {
            ShowAccessScreen();
            if (GlobalVariable.mAccessUser != "")
            {
                frmChangePassword frm = new frmChangePassword();
                frm.ShowDialog();
                frm.FormClosing += OFrm_FormClosing;
                GlobalVariable.mAccessUser = "";
                //this.Hide();
                pnlMaster.Visible = false;
            }

        }

        private void btnNGMaster_Click(object sender, EventArgs e)
        {
            ShowAccessScreen();
            if (GlobalVariable.mAccessUser != "")
            {
                frmNGMaster frm = new frmNGMaster();
                frm.Show();
                frm.FormClosing += OFrm_FormClosing;
                this.Hide();
                GlobalVariable.mAccessUser = "";
                pnlMaster.Visible = false;
            }
        }

        private void btnConveyorMaster_Click(object sender, EventArgs e)
        {
            ShowAccessScreen();
            if (GlobalVariable.mAccessUser != "")
            {
                frmConveyorMaster frm = new frmConveyorMaster();
                frm.Show();
                frm.FormClosing += OFrm_FormClosing;
                this.Hide();
                GlobalVariable.mAccessUser = "";
                pnlMaster.Visible = false;
            }
        }

        private void btnTrayMaster_Click(object sender, EventArgs e)
        {
            ShowAccessScreen();
            if (GlobalVariable.mAccessUser != "")
            {
                frmTrayMaster frm = new frmTrayMaster();
                frm.Show();
                frm.FormClosing += OFrm_FormClosing;
                this.Hide();
                GlobalVariable.mAccessUser = "";
                pnlMaster.Visible = false;
            }

        }

        private void btnCameraIPMaster_Click(object sender, EventArgs e)
        {
            ShowAccessScreen();
            if (GlobalVariable.mAccessUser != "")
            {
                frmCameraIPMaster frm = new frmCameraIPMaster();
                frm.Show();
                frm.FormClosing += OFrm_FormClosing;
                this.Hide();
                GlobalVariable.mAccessUser = "";
                pnlMaster.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowAccessScreen();
            if (GlobalVariable.mAccessUser != "")
            {
                frmConveyorCamMappingMaster frm = new frmConveyorCamMappingMaster();
                frm.Show();
                frm.FormClosing += OFrm_FormClosing;
                this.Hide();
                GlobalVariable.mAccessUser = "";
                pnlMaster.Visible = false;
            }
        }

        private void btnRoutingMaster_Click(object sender, EventArgs e)
        {
            ShowAccessScreen();
            if (GlobalVariable.mAccessUser != "")
            {
                frmRountingMaster frm = new frmRountingMaster();
                frm.Show();
                frm.FormClosing += OFrm_FormClosing;
                this.Hide();
                GlobalVariable.mAccessUser = "";
                pnlMaster.Visible = false;
            }

        }

        private void btnLinePCConveyor_Click(object sender, EventArgs e)
        {
            ShowAccessScreen();
            if (GlobalVariable.mAccessUser != "")
            {
                frmConveyorLinePCMappingMaster frm = new frmConveyorLinePCMappingMaster();
                frm.Show();
                frm.FormClosing += OFrm_FormClosing;
                this.Hide();
                GlobalVariable.mAccessUser = "";
                pnlMaster.Visible = false;
            }
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            ShowAccessScreen();
            if (GlobalVariable.mAccessUser != "")
            {
                frmMainDashboard frm = new frmMainDashboard();
                frm.Show();
                frm.FormClosing += OFrm_FormClosing;
                this.Hide();
                GlobalVariable.mAccessUser = "";
                pnlMaster.Visible = false;
            }
        }

        private void btnScannerTriggerTimeMaster_Click(object sender, EventArgs e)
        {
            ShowAccessScreen();
            if (GlobalVariable.mAccessUser != "")
            {
                frmScannerTiggerTImeMaster frm = new frmScannerTiggerTImeMaster();
                frm.Show();
                frm.FormClosing += OFrm_FormClosing;
                this.Hide();
                GlobalVariable.mAccessUser = "";
                pnlMaster.Visible = false;
            }

        }
    }
}
