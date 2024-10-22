using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DENSO_VCT_APP;
using DENSO_VCT_COMMON;

namespace DENSO_VCT_APP
{
    public partial class frmAccessPassword : Form
    {
        public string Password { get; set; }
        public string UserType { get; set; }
        public bool IsCancel { get; set; }


        public frmAccessPassword()
        {
            InitializeComponent();
            
        }
        private void Show_ToolTip(Control ctr, string msg)
        {
            toolTip1.SetToolTip(ctr, msg);
            toolTip1.Show(msg, ctr, 2000);

        }
        private void bltOk_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVariable.mAccessUser = "";
                Common common = new Common();
                common.GiveAccess(txtpwd.Text.Trim());
                IsCancel = true;
                this.Close();
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            IsCancel = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtpwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            IsCancel = false;
            this.Close();
        }
    }
}
