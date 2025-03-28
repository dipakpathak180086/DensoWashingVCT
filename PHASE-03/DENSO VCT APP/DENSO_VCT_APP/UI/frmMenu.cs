﻿using System;
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
        private void picMasterConfig_Click(object sender, EventArgs e)
        {
            ShowAccessScreen();
            if (GlobalVariable.mAccessUser != "")
            {
                pnlMaster.Visible = true;
                GlobalVariable.mAccessUser = "";
               // pnlMaster.Visible = false;
            }
           

        }
       


      
        #endregion

        #region Method

     

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
            if (GlobalVariable.mAccessUser != "" )
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

        private void btnTrayScanning_Click(object sender, EventArgs e)
        {
            frmAssemblyScanning frm = new frmAssemblyScanning();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();
        }
    }
}
