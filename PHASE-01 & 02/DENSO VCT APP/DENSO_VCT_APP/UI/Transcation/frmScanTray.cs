using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DENSO_VCT_BL;
using DENSO_VCT_COMMON;
using DENSO_VCT_PL;

namespace DENSO_VCT_APP
{
    public partial class frmScanTray : Form
    {
        private int _iLotQty = 0;
        private int _iRemainderLotQty = 0;
        private int _iDivLotQty = 0;
        private string _strMode = string.Empty;
        private int _iRowId = 0;
        HashSet<string> _hs = new HashSet<string>();
        private BL_LOT_ENTRY _blObj = null;
        private PL_LOT_ENTRY _plObj = null;
        public frmScanTray(int iLotQty, string mode,int iRowid)
        {
            InitializeComponent();
            _iLotQty = iLotQty;
            _strMode = mode;
            _iRowId = iRowid;
            GlobalVariable.mIsTrayScanning = false;
        }
        #region Private Method
        void lblShowMessage(string msg = "", int ictr = -1)
        {
            if (ictr == 1)
            {
                lblMessage.BackColor = Color.DarkGreen;
                lblMessage.Text = msg;
            }
            else if (ictr == 2)
            {
                lblMessage.BackColor = Color.DarkRed;
                lblMessage.Text = msg;

            }
            else
            {
                lblMessage.BackColor = Color.Transparent;
                lblMessage.Text = msg;
            }
        }
        #endregion
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTray01.Text) && txtTray01.Enabled)
                {
                    GlobalVariable.MesseageInfo(lblMessage, "Trya-01 can't be blank!!!", 2);
                    this.txtTray01.SelectAll();
                    this.txtTray01.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtTray02.Text) && txtTray02.Enabled)
                {
                    GlobalVariable.MesseageInfo(lblMessage, "Trya-02 can't be blank!!!", 2);
                    this.txtTray02.SelectAll();
                    this.txtTray02.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtTray03.Text) && txtTray03.Enabled)
                {
                    GlobalVariable.MesseageInfo(lblMessage, "Trya-03 can't be blank!!!", 2);
                    this.txtTray03.SelectAll();
                    this.txtTray03.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtTray04.Text) && txtTray04.Enabled)
                {
                    GlobalVariable.MesseageInfo(lblMessage, "Trya-04 can't be blank!!!", 2);
                    this.txtTray04.SelectAll();
                    this.txtTray04.Focus();
                    return;
                }
                if ((txtTray01.Enabled && txtTray01.Text.Trim().Equals(txtTray02.Text.Trim())) ||
    (txtTray01.Enabled && txtTray01.Text.Trim().Equals(txtTray03.Text.Trim())) ||
    (txtTray01.Enabled && txtTray01.Text.Trim().Equals(txtTray04.Text.Trim())) ||
    (txtTray02.Enabled && txtTray02.Text.Trim().Equals(txtTray03.Text.Trim())) ||
    (txtTray02.Enabled && txtTray02.Text.Trim().Equals(txtTray04.Text.Trim())) ||
    (txtTray03.Enabled && txtTray03.Text.Trim().Equals(txtTray04.Text.Trim())))
                {
                    GlobalVariable.MesseageInfo(lblMessage, "Trays cannot have duplicate values!", 2);

                    // Focus on the first field with a duplicate value, considering whether it's enabled
                    if (txtTray01.Enabled && (txtTray01.Text.Trim().Equals(txtTray02.Text.Trim()) ||
                                              txtTray01.Text.Trim().Equals(txtTray03.Text.Trim()) ||
                                              txtTray01.Text.Trim().Equals(txtTray04.Text.Trim())))
                    {
                        this.txtTray01.SelectAll();
                        this.txtTray01.Focus();
                    }
                    else if (txtTray02.Enabled && (txtTray02.Text.Trim().Equals(txtTray03.Text.Trim()) ||
                                                   txtTray02.Text.Trim().Equals(txtTray04.Text.Trim())))
                    {
                        this.txtTray02.SelectAll();
                        this.txtTray02.Focus();
                    }
                    else if (txtTray03.Enabled && txtTray03.Text.Trim().Equals(txtTray04.Text.Trim()))
                    {
                        this.txtTray03.SelectAll();
                        this.txtTray03.Focus();
                    }

                    return;
                }

                GlobalVariable.mTray01 = txtTray01.Text.Trim();
                GlobalVariable.mTray02 = txtTray02.Text.Trim();
                GlobalVariable.mTray03 = txtTray03.Text.Trim();
                GlobalVariable.mTray04 = txtTray04.Text.Trim();
                GlobalVariable.mIsTrayScanning = true;
                this.Close();

            }
            catch (Exception ex)
            {

                lblShowMessage(ex.Message, 2);
            }
        }

        private void frmMsg_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GlobalVariable.mIsDelete = false;
            this.Close();
        }

        private void frmScanTray_Load(object sender, EventArgs e)
        {
            try
            {
                txtTray01.Enabled = txtTray02.Enabled = txtTray03.Enabled = txtTray04.Enabled = false;
                if (_strMode == "INSERT")
                {
                    btnSave.Enabled = true;
                    btnDelete.Enabled = false;
                    _iRemainderLotQty = _iLotQty % 6;
                    _iDivLotQty = _iLotQty / 6;
                    if (_iDivLotQty == 1)
                    {
                        txtTray01.Enabled = true;
                    }
                    if (_iDivLotQty == 2)
                    {
                        txtTray01.Enabled = true;
                        txtTray02.Enabled = true;
                    }
                    if (_iDivLotQty == 3)
                    {
                        txtTray01.Enabled = true;
                        txtTray02.Enabled = true;
                        txtTray03.Enabled = true;
                    }
                    if (_iDivLotQty >= 4)
                    {
                        txtTray01.Enabled = true;
                        txtTray02.Enabled = true;
                        txtTray03.Enabled = true;
                        txtTray04.Enabled = true;
                    }
                    Application.DoEvents();
                    if (_iRemainderLotQty > 0)
                    {
                        if (!txtTray01.Enabled)
                        {
                            txtTray01.Enabled = true;
                            return;
                        }
                        if (!txtTray02.Enabled)
                        {
                            txtTray02.Enabled = true;
                            return;
                        }
                        if (!txtTray03.Enabled)
                        {
                            txtTray03.Enabled = true;
                            return;
                        }
                        if (!txtTray04.Enabled)
                        {
                            txtTray04.Enabled = true;
                            return;
                        }
                    }
                }
                else
                {
                    btnDelete.Enabled = true;
                    btnSave.Enabled = false;
                    txtTray01.Text = GlobalVariable.mTray01;
                    txtTray02.Text = GlobalVariable.mTray02;
                    txtTray03.Text = GlobalVariable.mTray03;
                    txtTray04.Text = GlobalVariable.mTray04;
                }

            }
            catch (Exception ex)
            {

                lblShowMessage(ex.Message, 2);
            }
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }

        private void txtTray01_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTray02.Focus();
            }
        }

        private void txtTray01_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTray01.Text.Trim())) { return; }
            //if (_hs.Contains(txtTray01.Text.Trim()))
            //{
            //    GlobalVariable.MesseageInfo(lblMessage, "Trya-01 can't be duplicate!!!", 2);
            //    this.txtTray01.SelectAll();
            //    this.txtTray01.Focus();
            //    return;
            //}
            if (string.IsNullOrEmpty(txtTray01.Text) && txtTray01.Enabled)
            {
                GlobalVariable.MesseageInfo(lblMessage, "Trya-01 can't be blank!!!", 2);
                this.txtTray01.SelectAll();
                this.txtTray01.Focus();
                return;
            }
            if (!_hs.Contains(txtTray01.Text.Trim()))
            {
                _hs.Add(txtTray01.Text.Trim());
            }
        }

        private void txtTray02_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTray03.Focus();
            }
        }
        private void txtTray02_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTray02.Text.Trim())) { return; }
            //if (_hs.Contains(txtTray02.Text.Trim()))
            //{
            //    GlobalVariable.MesseageInfo(lblMessage, "Trya-02 can't be duplicate!!!", 2);
            //    this.txtTray02.SelectAll();
            //    this.txtTray02.Focus();
            //    return;
            //}
            if (string.IsNullOrEmpty(txtTray01.Text) && txtTray01.Enabled)
            {
                GlobalVariable.MesseageInfo(lblMessage, "Trya-01 can't be blank!!!", 2);
                this.txtTray01.SelectAll();
                this.txtTray01.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTray02.Text) && txtTray02.Enabled)
            {
                GlobalVariable.MesseageInfo(lblMessage, "Trya-02 can't be blank!!!", 2);
                this.txtTray02.SelectAll();
                this.txtTray02.Focus();
                return;
            }
            if (!_hs.Contains(txtTray02.Text.Trim()))
            {
                _hs.Add(txtTray02.Text.Trim());
            }
        }
        private void txtTray03_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTray04.Focus();
            }

        }

        private void txtTray03_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTray03.Text.Trim())) { return; }
            //if (_hs.Contains(txtTray03.Text.Trim()))
            //{
            //    GlobalVariable.MesseageInfo(lblMessage, "Trya-03 can't be duplicate!!!", 2);
            //    this.txtTray03.SelectAll();
            //    this.txtTray03.Focus();
            //    return;
            //}
            if (string.IsNullOrEmpty(txtTray01.Text) && txtTray01.Enabled)
            {
                GlobalVariable.MesseageInfo(lblMessage, "Trya-01 can't be blank!!!", 2);
                this.txtTray01.SelectAll();
                this.txtTray01.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTray02.Text) && txtTray02.Enabled)
            {
                GlobalVariable.MesseageInfo(lblMessage, "Trya-02 can't be blank!!!", 2);
                this.txtTray02.SelectAll();
                this.txtTray02.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTray03.Text) && txtTray03.Enabled)
            {
                GlobalVariable.MesseageInfo(lblMessage, "Trya-03 can't be blank!!!", 2);
                this.txtTray03.SelectAll();
                this.txtTray03.Focus();
                return;
            }
            if (!_hs.Contains(txtTray03.Text.Trim()))
            {
                _hs.Add(txtTray03.Text.Trim());
            }
        }
        private void txtTray04_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(null, null);
            }

        }
        private void txtTray04_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTray04.Text.Trim())) { return; }
            //if (_hs.Contains(txtTray04.Text.Trim()))
            //{
            //    GlobalVariable.MesseageInfo(lblMessage, "Trya-04 can't be duplicate!!!", 2);
            //    this.txtTray04.SelectAll();
            //    this.txtTray04.Focus();
            //    return;
            //}
            if (string.IsNullOrEmpty(txtTray01.Text) && txtTray01.Enabled)
            {
                GlobalVariable.MesseageInfo(lblMessage, "Trya-01 can't be blank!!!", 2);
                this.txtTray01.SelectAll();
                this.txtTray01.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTray02.Text) && txtTray02.Enabled)
            {
                GlobalVariable.MesseageInfo(lblMessage, "Trya-02 can't be blank!!!", 2);
                this.txtTray02.SelectAll();
                this.txtTray02.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTray03.Text) && txtTray03.Enabled)
            {
                GlobalVariable.MesseageInfo(lblMessage, "Trya-03 can't be blank!!!", 2);
                this.txtTray03.SelectAll();
                this.txtTray03.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTray04.Text) && txtTray04.Enabled)
            {
                GlobalVariable.MesseageInfo(lblMessage, "Trya-04 can't be blank!!!", 2);
                this.txtTray04.SelectAll();
                this.txtTray04.Focus();
                return;
            }
            if (!_hs.Contains(txtTray04.Text.Trim()))
            {
                _hs.Add(txtTray04.Text.Trim());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalVariable.mIsDelete = true;
        }
    }
}
