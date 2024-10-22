using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DENSO_VCT_COMMON;

namespace DENSO_VCT_APP
{
    public partial class frmMsg : Form
    {
        public frmMsg()
        {
            InitializeComponent();
            lblMsg.Text = "Lot Qty does not match with Lot Master Qty. (" + GlobalVariable.mWashingQty + ")";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            GlobalVariable.mWashingQtyAlert = true;
            this.Close();
        }

        private void frmMsg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(null, null);
            }
        }
    }
}
