
using DENSO_VCT_BL;
using DENSO_VCT_COMMON;
using DENSO_VCT_PL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DENSO_VCT_APP
{
    public partial class frmLotEntry : Form
    {

        #region Variables

        private BL_LOT_ENTRY _blObj = null;
        private PL_LOT_ENTRY _plObj = null;
        private Common _comObj = null;
        private string _rowId = string.Empty;
        private DataTable dtBindGrid = new DataTable();
        private bool _IsUpdate = false;
        private bool _IsFraction = false;
        #endregion

        #region Form Methods

        public frmLotEntry()
        {
            try
            {
                InitializeComponent();

            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }
        }
        private void BindChildMenu()
        {
            try
            {
                BL_PC_MENU blObj = new BL_PC_MENU();
                PL_PC_MENU plObj = new PL_PC_MENU();
                plObj.DbType = "GET_CHILD_PART";
                plObj.Model = GlobalVariable.mParentPart;
                DataTable dt = blObj.BL_ExecuteTask(plObj);
                if (dt.Rows.Count > 0)
                {
                    GlobalVariable.mIRunningIndex = 0;
                    GlobalVariable.mdicChildPart = new Dictionary<string, string>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (!GlobalVariable.mdicChildPart.ContainsKey(dt.Rows[i]["ChildPartName"].ToString()))
                        {
                            GlobalVariable.mdicChildPart.Add(dt.Rows[i]["ChildPartName"].ToString(), dt.Rows[i]["ChildPartNo"].ToString());

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void frmModelMaster_Load(object sender, EventArgs e)
        {
            try
            {
                //  this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                txtPartName.Enabled = txtPartNo.Enabled = false;
                txtPartName.Text = GlobalVariable.mChildPartName;
                txtPartNo.Text = GlobalVariable.mChildPart;
                Common common = new Common();
                txtShift.Text = GlobalVariable.mShift = common.GetShift();
                BindView();

                GetLotAndQtyLengthData();
                GetTMAndTLLastData();
                txtTMName.Focus();
                //BindChildMenu();
                GetShiftWiseTotalQty();
            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }
        }

        #endregion

        #region Button Event
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {

                Clear();


            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dre = MessageBox.Show("Are you sure want to back???", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dre == DialogResult.No)
            {
                return;
            }
            this.Close();
        }

        #endregion

        #region Methods
        private void OFrm_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.Show();
        }
        private void Clear()
        {
            try
            {
                lblLastScannedLotBarcode.Text = "Last Scan Lot Barcode If Any * :";
                lblLastScannedLotBarcode.Visible = false;
                lblMessage.BackColor = Color.Transparent;
                lblMessage.Text = "";
                txtTLName.Text = txtTMName.Text = txtLotNo.Text = txtLot2.Text = txtLotQty.Text=txtScanTray.Text = "";
                txtTMName.Focus();
                GetTMAndTLLastData();
                chkManualDate.Checked = false;
                _IsUpdate = false;
                _IsFraction = false;
                dpDateTime.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }
        }

        void GetLotAndQtyLengthData()
        {
            try
            {
                _blObj = new BL_LOT_ENTRY();
                _plObj = new PL_LOT_ENTRY();
                _plObj.DbType = "LOT_AND_QTY_LEN";
                _plObj.ModelNo = GlobalVariable.mParentPart;
                _plObj.ChildPartNo = GlobalVariable.mChildPart;
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    txtLotNo.MaxLength = Convert.ToInt32(dt.Rows[0]["LotNoLength"]);
                    txtLotQty.MaxLength = Convert.ToInt32(dt.Rows[0]["LotQtyLength"]);
                }
            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }
        }
        void GetTMAndTLLastData()
        {
            try
            {
                _blObj = new BL_LOT_ENTRY();
                _plObj = new PL_LOT_ENTRY();
                _plObj.DbType = "LAST_TM_AND_TL_DATA";
                _plObj.ModelNo = GlobalVariable.mParentPart;
                _plObj.ChildPartNo = GlobalVariable.mChildPart;
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    txtTMName.Text = Convert.ToString(dt.Rows[0]["TMName"]);
                    txtTLName.Text = Convert.ToString(dt.Rows[0]["TLName"]);
                }
            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }
        }
        void GetShiftWiseTotalQty()
        {
            try
            {
                _blObj = new BL_LOT_ENTRY();
                _plObj = new PL_LOT_ENTRY();
                _plObj.DbType = "GET_SHIFTWISE_TOTAL_QTY";
                _plObj.ModelNo = GlobalVariable.mParentPart;
                _plObj.ChildPartNo = GlobalVariable.mChildPart;
                _plObj.Shift = GlobalVariable.mShift;
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString().Equals(""))
                    {
                        lblTotalPartQty.Text = "0";
                    }
                    else
                    {
                        lblTotalPartQty.Text = Convert.ToString(dt.Rows[0]["ShiftWiseTotalQty"]);
                    }
                }
            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }
        }
        void BindView()
        {
            this.Invoke(new Action(() =>
            {
                try
                {
                    for (int i = dgv.Rows.Count - 1; i >= 0; i--)
                    {
                        dgv.Rows.RemoveAt(i);
                    }
                    _blObj = new BL_LOT_ENTRY();
                    _plObj = new PL_LOT_ENTRY();
                    _plObj.DbType = "SELECT";
                    _plObj.ModelNo = GlobalVariable.mParentPart;
                    _plObj.ChildPartNo = GlobalVariable.mChildPart;
                    DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                    if (dt.Rows.Count > 0)
                    {

                        dgv.DataSource = dt.DefaultView;
                        for (int i = 0; i < dgv.ColumnCount; i++)
                        {
                            this.dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                            if (dgv.ColumnCount - 1 == i)
                            {
                                this.dgv.Columns[dgv.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    lblShowMessage(ex.Message, 2);
                }
                dgv.ResumeLayout(true);
            }
            ));
        }
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

        void PlayValidationSound()
        {
            try
            {
                Application.DoEvents();
                SoundPlayer simpleSound = new SoundPlayer(Application.StartupPath + @"\Sound\Beep1.wav");
                simpleSound.Play();
                Thread.Sleep(3000);
                simpleSound.Stop();

            }
            catch (Exception)
            {

                throw;
            }
        }
        void ShowAccessScreen()
        {
            frmAccessPassword oFrmLogin = new frmAccessPassword();
            oFrmLogin.ShowDialog();
            if (GlobalVariable.mAccessUser != "" && oFrmLogin.IsCancel == true)
            {
                lblShowMessage();
            }
        }

        void DisableFields()
        {
            txtPartName.Enabled = true;
            // txtLotNo.Enabled = txtPCBPartNo.Enabled = txtPartNo.Enabled = txtTMName.Enabled = false;
        }


        private void FinalSave()
        {
            try
            {
                lblShowMessage();
                if (txtPartName.Text.Length == 0)
                {
                    GlobalVariable.MesseageInfo(lblMessage, "Part Name can't be blank!!!", 2);
                    this.txtPartName.SelectAll();
                    this.txtPartName.Focus();
                    //PlayValidationSound();
                    //ShowAccessScreen();
                    return;
                }
                if (txtTMName.Text.Length == 0)
                {
                    GlobalVariable.MesseageInfo(lblMessage, "TM Name can't be blank!!!", 2);
                    this.txtTMName.SelectAll();
                    this.txtTMName.Focus();
                    //PlayValidationSound();
                    //ShowAccessScreen();
                    return;
                }
                if (txtTLName.Text.Length == 0)
                {
                    GlobalVariable.MesseageInfo(lblMessage, "TL Name can't be  blank!!!", 2);
                    this.txtTLName.SelectAll();
                    this.txtTLName.Focus();
                    //PlayValidationSound();
                    //ShowAccessScreen();
                    return;
                }
                if (txtShift.Text.Length == 0)
                {
                    GlobalVariable.MesseageInfo(lblMessage, "TL Name can't be blank!!!", 2);
                    this.txtTLName.SelectAll();
                    this.txtTLName.Focus();
                    //PlayValidationSound();
                    //ShowAccessScreen();
                    return;
                }
                if (txtPartNo.Text.Length == 0)
                {
                    GlobalVariable.MesseageInfo(lblMessage, "Part No can't be blank!!!", 2);
                    this.txtPartNo.SelectAll();
                    this.txtPartNo.Focus();
                    //PlayValidationSound();
                    //ShowAccessScreen();
                    return;
                }
                if (txtLotNo.Text.Length == 0)
                {
                    GlobalVariable.MesseageInfo(lblMessage, "Lot No can't be blank!!!", 2);
                    this.txtLotNo.SelectAll();
                    this.txtLotNo.Focus();
                    //PlayValidationSound();
                    //ShowAccessScreen();
                    return;
                }
                if (txtLotQty.Text.Length == 0)
                {
                    GlobalVariable.MesseageInfo(lblMessage, "Lot Qty can't be blank!!!", 2);
                    this.txtLotQty.SelectAll();
                    this.txtLotQty.Focus();
                    //PlayValidationSound();
                    //ShowAccessScreen();
                    return;
                }
                if (Convert.ToInt32(txtLotQty.Text) == 0)
                {
                    GlobalVariable.MesseageInfo(lblMessage, "Lot Qty can't be zero!!!", 2);
                    this.txtLotQty.SelectAll();
                    this.txtLotQty.Focus();
                    //PlayValidationSound();
                    //ShowAccessScreen();
                    return;
                }

                _blObj = new BL_LOT_ENTRY();
                _plObj = new PL_LOT_ENTRY();

                _plObj.ModelNo = GlobalVariable.mParentPart;
                _plObj.ModelName = txtPartName.Text.Trim();
                _plObj.ChildPartNo = txtPartNo.Text.Trim();
                _plObj.ChildPartName = GlobalVariable.mChildPartName;
                _plObj.TMName = txtTMName.Text.Trim();
                _plObj.TLName = txtTLName.Text.Trim();
                _plObj.LotNo = txtLot2.Text.Trim().Equals("") ? txtLotNo.Text.Trim() : txtLotNo.Text.Trim() + "/" + txtLot2.Text.Trim();
                if (_plObj.LotNo.Length >= txtLotNo.MaxLength)
                {
                    GlobalVariable.MesseageInfo(lblMessage, $"Enter Lot No, Length should be less than  {txtLotNo.MaxLength}!!!", 2);
                    this.txtLotNo.SelectAll();
                    this.txtLotNo.Focus();
                    return;
                }
                _plObj.LotQty = Convert.ToInt32(txtLotQty.Text.Trim());
                _plObj.Shift = txtShift.Text.Trim();
                _plObj.Manual_Date = chkManualDate.Checked;
                _plObj.Date = dpDateTime.Value.ToString("yyyy-MM-dd");
                _plObj.Time = dpDateTime.Value.ToString("HH:mm:ss.fff");
                _plObj.CreatedBy = txtTMName.Text.Trim();
                _plObj.TrayNo = txtScanTray.Text.Trim();
                if (_IsFraction == true)
                {
                    _plObj.DbType = "INSERT";
                    DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Result"].ToString() == "Y")
                        {
                            BindView();
                            GetShiftWiseTotalQty();
                            Clear();
                            lblShowMessage("Data Saved Successfully", 1);
                        }
                        else
                        {
                            lblShowMessage(dt.Rows[0]["Result"].ToString(), 2);
                        }
                    }

                }
                else if (_IsUpdate == false)
                {
                    _plObj.DbType = "INSERT";
                    DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Result"].ToString() == "Y")
                        {
                            BindView();
                            GetShiftWiseTotalQty();
                            Clear();
                            lblShowMessage("Data Saved Successfully", 1);
                        }
                        else
                        {
                            lblShowMessage(dt.Rows[0]["Result"].ToString(), 2);
                        }
                    }

                }
                else
                {
                    _plObj.RowId = Convert.ToInt64(_rowId);
                    _plObj.DbType = "UPDATE";
                    DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Result"].ToString() == "Y")
                        {
                            BindView();
                            GetShiftWiseTotalQty();
                            Clear();
                            lblShowMessage("Data Updated Successfully", 1);
                        }
                        else
                        {
                            lblShowMessage(dt.Rows[0]["Result"].ToString(), 2);
                        }
                    }
                }




            }
            catch (Exception ex)
            {

                lblShowMessage(ex.Message, 2);
            }
            finally
            {

            }
        }


        #endregion

        #region Label Event

        #endregion

        #region DataGridView Events


        #endregion

        #region TextBox Event

        private void txtTMName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    lblShowMessage();
                    if (txtPartName.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Part Name can't be blank!!!", 2);
                        this.txtPartName.SelectAll();
                        this.txtPartName.Focus();
                        //PlayValidationSound();
                        //ShowAccessScreen();
                        return;
                    }

                    if (txtPartNo.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Part No. can't be blank!!!", 2);
                        this.txtPartNo.SelectAll();
                        this.txtPartNo.Focus();
                        //PlayValidationSound();
                        //ShowAccessScreen();
                        return;
                    }


                    if (txtTMName.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "TM Name can't be blank!!!", 2);
                        this.txtTMName.SelectAll();
                        this.txtTMName.Focus();
                        //PlayValidationSound();
                        //ShowAccessScreen();
                        return;
                    }

                    txtTLName.Enabled = true;
                    txtTLName.Focus();




                }
                catch (Exception ex)
                {

                    lblShowMessage(ex.Message, 2);
                }
                finally
                {

                }
            }
        }

        private void txtLotNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    lblShowMessage();
                    if (txtPartName.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Change Over Sheet can't be blank!!!", 2);
                        this.txtPartName.SelectAll();
                        this.txtPartName.Focus();
                        //PlayValidationSound();
                        //ShowAccessScreen();
                        return;
                    }

                    if (txtPartNo.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Kanban can't be blank!!!", 2);
                        this.txtPartNo.SelectAll();
                        this.txtPartNo.Focus();
                        //PlayValidationSound();
                        //ShowAccessScreen();
                        return;
                    }
                    if (txtTMName.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "TM Name can't be blank!!!", 2);
                        this.txtTMName.SelectAll();
                        this.txtTMName.Focus();
                        //PlayValidationSound();
                        //ShowAccessScreen();
                        return;
                    }
                    if (txtShift.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Shift can't be blank!!!", 2);
                        this.txtShift.SelectAll();
                        this.txtShift.Focus();
                        //PlayValidationSound();
                        //ShowAccessScreen();
                        return;
                    }
                    if (txtLotNo.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Lot No can't be blank!!!", 2);
                        this.txtLotNo.SelectAll();
                        this.txtLotNo.Focus();
                        //PlayValidationSound();
                        ////ShowAccessScreen();
                        return;
                    }
                    lblLastScannedLotBarcode.Visible = false;
                    lblLastScannedLotBarcode.Text = "Last Scan Lot Barcode If Any * :";
                    txtLot2.Enabled = true;
                    txtLot2.Focus();
                    if (txtLotNo.Text.Contains(",") && txtLotNo.Text.Length == 44)
                    {
                        string lotNo = txtLotNo.Text.Trim();
                        lblLastScannedLotBarcode.Visible = true;
                        lblLastScannedLotBarcode.Text = "Last Scan Lot Barcode If Any * :" + lotNo;
                        txtLotNo.Text = lotNo.Split(',')[2].ToString();
                        txtLotQty.Text = lotNo.Split(',')[1].ToString();
                        //FinalSave();
                        txtScanTray.Focus();
                    }
                    else
                    {
                        txtLotQty.Enabled = true;
                        txtLotQty.Focus();
                    }





                }
                catch (Exception ex)
                {

                    lblShowMessage(ex.Message, 2);
                }
                finally
                {

                }
            }
        }

        private void txtTLName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    lblShowMessage();
                    if (txtPartName.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Change Over Sheet can't be blank!!!", 2);
                        this.txtPartName.SelectAll();
                        this.txtPartName.Focus();
                        //PlayValidationSound();
                        //ShowAccessScreen();
                        return;
                    }

                    if (txtPartNo.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Kanban can't be blank!!!", 2);
                        this.txtPartNo.SelectAll();
                        this.txtPartNo.Focus();
                        //PlayValidationSound();
                        //ShowAccessScreen();
                        return;
                    }
                    if (txtTMName.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "TM Name can't be blank!!!", 2);
                        this.txtTMName.SelectAll();
                        this.txtTMName.Focus();
                        //PlayValidationSound();
                        ////ShowAccessScreen();
                        return;
                    }

                    if (txtTLName.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "TL Name can't be blank!!!", 2);
                        this.txtTLName.SelectAll();
                        this.txtTLName.Focus();
                        //PlayValidationSound();
                        //ShowAccessScreen();
                        return;
                    }
                    txtShift.Enabled = true;
                    txtShift.Focus();




                }
                catch (Exception ex)
                {

                    lblShowMessage(ex.Message, 2);
                }
                finally
                {

                }

            }
        }
        private void txtShift_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    lblShowMessage();
                    if (txtPartName.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Change Over Sheet can't be blank!!!", 2);
                        this.txtPartName.SelectAll();
                        this.txtPartName.Focus();
                        //PlayValidationSound();
                        //ShowAccessScreen();
                        return;
                    }

                    if (txtPartNo.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Kanban can't be blank!!!", 2);
                        this.txtPartNo.SelectAll();
                        this.txtPartNo.Focus();
                        //PlayValidationSound();
                        //ShowAccessScreen();
                        return;
                    }
                    if (txtTMName.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "TM Name can't be blank!!!", 2);
                        this.txtTMName.SelectAll();
                        this.txtTMName.Focus();
                        //PlayValidationSound();
                        //ShowAccessScreen();
                        return;
                    }

                    if (txtTLName.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "TL Name can't be blank!!!", 2);
                        this.txtTLName.SelectAll();
                        this.txtTLName.Focus();
                        //PlayValidationSound();
                        //ShowAccessScreen();
                        return;
                    }
                    if (txtShift.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Shift can't be blank!!!", 2);
                        this.txtShift.SelectAll();
                        this.txtShift.Focus();
                        //PlayValidationSound();
                        //ShowAccessScreen();
                        return;
                    }
                    txtLotNo.Enabled = true;
                    txtLotNo.Focus();




                }
                catch (Exception ex)
                {

                    lblShowMessage(ex.Message, 2);
                }
                finally
                {

                }

            }
        }
        private void txtLotQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    lblShowMessage();
                    if (txtPartName.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Change Over Sheet can't be blank!!!", 2);
                        this.txtPartName.SelectAll();
                        this.txtPartName.Focus();
                        //PlayValidationSound();
                        //ShowAccessScreen();
                        return;
                    }

                    if (txtPartNo.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Kanban can't be blank!!!", 2);
                        this.txtPartNo.SelectAll();
                        this.txtPartNo.Focus();
                        //PlayValidationSound();
                        //ShowAccessScreen();
                        return;
                    }
                    if (txtTMName.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "TM Name can't be blank!!!", 2);
                        this.txtTMName.SelectAll();
                        this.txtTMName.Focus();
                        //PlayValidationSound();
                        //ShowAccessScreen();
                        return;
                    }
                    if (txtShift.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Shift can't be blank!!!", 2);
                        this.txtShift.SelectAll();
                        this.txtShift.Focus();
                        //PlayValidationSound();
                        //ShowAccessScreen();
                        return;
                    }
                    if (txtLotNo.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Lot No can't be blank!!!", 2);
                        this.txtLotNo.SelectAll();
                        this.txtLotNo.Focus();
                        //PlayValidationSound();
                        ////ShowAccessScreen();
                        return;
                    }

                    if (txtLotQty.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Lot Qty can't be blank!!!", 2);
                        this.txtLotQty.SelectAll();
                        this.txtLotQty.Focus();
                        //PlayValidationSound();
                        ////ShowAccessScreen();
                        return;
                    }
                    if (int.Parse(txtLotQty.Text) == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Lot Qty can't be Zero!!!", 2);
                        this.txtLotQty.SelectAll();
                        this.txtLotQty.Focus();
                        //PlayValidationSound();
                        ////ShowAccessScreen();
                        return;
                    }
                    txtScanTray.Focus();
                    //if (txtLotNo.Text.Contains(",") && txtLotNo.Text.Length==44)
                    //{
                    //    string lotNo = txtLotNo.Text.Trim();
                    //    lblLastScannedLotBarcode.Visible = true;
                    //    lblLastScannedLotBarcode.Text = "Last Scan Lot Barcode If Any * :" + lotNo;
                    //    txtLotNo.Text = lotNo.Split(',')[0].ToString();
                    //    txtLotQty.Text= lotNo.Split(',')[1].ToString();
                    //    FinalSave();
                    //}
                    //else
                    //{
                    //    txtLotQty.Enabled = true;
                    //    txtLotQty.Focus();
                    //}





                }
                catch (Exception ex)
                {

                    lblShowMessage(ex.Message, 2);
                }
                finally
                {

                }
            }
        }
        private void txtScanTray_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FinalSave();
            }
        }

        #endregion


        private void dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex <= -1)
                {
                    return;
                }
                Clear();
                _rowId = dgv.Rows[e.RowIndex].Cells["RowId"].Value.ToString();
                txtPartName.Enabled = txtPartNo.Enabled = false;
                txtShift.Text = dgv.Rows[e.RowIndex].Cells["Shift"].Value.ToString();
                txtPartName.Text = dgv.Rows[e.RowIndex].Cells["ModelName"].Value.ToString();
                txtPartNo.Text = dgv.Rows[e.RowIndex].Cells["ChildPartNo"].Value.ToString();
                txtTMName.Text = dgv.Rows[e.RowIndex].Cells["TMName"].Value.ToString();
                if (dgv.Rows[e.RowIndex].Cells["LotNo"].Value.ToString().Contains("/"))
                {
                    txtLotNo.Text = dgv.Rows[e.RowIndex].Cells["LotNo"].Value.ToString().Split('/')[0];
                    txtLot2.Text = dgv.Rows[e.RowIndex].Cells["LotNo"].Value.ToString().Split('/')[1];
                }
                else
                    txtLotNo.Text = dgv.Rows[e.RowIndex].Cells["LotNo"].Value.ToString();
                txtTLName.Text = dgv.Rows[e.RowIndex].Cells["TLName"].Value.ToString();
                txtLotQty.Text = dgv.Rows[e.RowIndex].Cells["LotQty"].Value.ToString();
                txtScanTray.Text = dgv.Rows[e.RowIndex].Cells["TrayNo"].Value.ToString();
                //txtModelNo.Enabled = false;
                //txtModelName.Enabled = false;
                _IsUpdate = true;

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void txtLotQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            GlobalVariable.allowOnlyNumeric(sender, e);
        }

        private void txtShift_KeyPress(object sender, KeyPressEventArgs e)
        {
            //GlobalVariable.allowOnlyAlpha(sender, e);
            if ((e.KeyChar.ToString().ToUpper() == "A" || e.KeyChar.ToString().ToUpper() == "B" || e.KeyChar.ToString().ToUpper() == "C"))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            //e.Handled= (!char.IsLetterOrDigit('A') || !char.IsLetterOrDigit('B') || !char.IsLetterOrDigit('C') )&& !char.IsControl(e.KeyChar);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            frmLotEntryReport frm = new frmLotEntryReport();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();
        }

        private void chkManualDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkManualDate.Checked)
            {
                ShowAccessScreen();
                if (GlobalVariable.mAccessUser != "")
                {
                    dpDateTime.Enabled = true;
                    GlobalVariable.mAccessUser = "";
                }
                else
                {
                    chkManualDate.Checked = false;
                }
            }
            else
            {
                dpDateTime.Enabled = false;
            }
        }

        private void frmLotEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                btnClose_Click(null, null);
            }
        }



        private void btnNext_Click(object sender, EventArgs e)
        {
            btnPrevious.Enabled = true;
            if (GlobalVariable.mdicChildPart.Count > 0)
            {
                if (GlobalVariable.mdicChildPart.Count - 1 == GlobalVariable.mIRunningIndex)
                {
                    btnNext.Enabled = false;
                }
                else
                {
                    GlobalVariable.mIRunningIndex++;
                }
                if (GlobalVariable.mIRunningIndex > GlobalVariable.mdicChildPart.Count - 1) { GlobalVariable.mIRunningIndex = 0; return; }
                txtPartNo.Text = GlobalVariable.mdicChildPart.ElementAt(GlobalVariable.mIRunningIndex).Value;
                txtPartName.Text = GlobalVariable.mdicChildPart.ElementAt(GlobalVariable.mIRunningIndex).Key;
                GlobalVariable.mChildPart = GlobalVariable.mChildPartName = "";
                GlobalVariable.mChildPartName = GlobalVariable.mdicChildPart.ElementAt(GlobalVariable.mIRunningIndex).Key;
                GlobalVariable.mChildPart = GlobalVariable.mdicChildPart.ElementAt(GlobalVariable.mIRunningIndex).Value;
                Task.Run(() => { BindView(); });
            }


        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            btnNext.Enabled = true;
            if (GlobalVariable.mdicChildPart.Count > 0)
            {
                if (GlobalVariable.mIRunningIndex <= GlobalVariable.mdicChildPart.Count - 1)
                {
                    GlobalVariable.mIRunningIndex--;
                    if (GlobalVariable.mIRunningIndex <= -1)
                    {
                        btnPrevious.Enabled = false;
                        GlobalVariable.mIRunningIndex = 0;
                        return;
                    }

                }


                //if (GlobalVariable.mIRunningIndex <0) { GlobalVariable.mIRunningIndex = 0; return; }
                txtPartNo.Text = GlobalVariable.mdicChildPart.ElementAt(GlobalVariable.mIRunningIndex).Value;
                txtPartName.Text = GlobalVariable.mdicChildPart.ElementAt(GlobalVariable.mIRunningIndex).Key;
                GlobalVariable.mChildPart = GlobalVariable.mChildPartName = "";
                GlobalVariable.mChildPartName = GlobalVariable.mdicChildPart.ElementAt(GlobalVariable.mIRunningIndex).Key;
                GlobalVariable.mChildPart = GlobalVariable.mdicChildPart.ElementAt(GlobalVariable.mIRunningIndex).Value;
                Task.Run(() => { BindView(); });
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                // _rowId = dgv.CurrentRow.Cells["RowId"].Value.ToString();
                if (_rowId == "") { return; }
                ShowAccessScreen();
                if (GlobalVariable.mAccessUser != "")
                {
                    GlobalVariable.mAccessUser = "";
                    // pnlMaster.Visible = false;

                    DialogResult dre = MessageBox.Show("Are you sure want to delete the entry???", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dre == DialogResult.No)
                    {
                        return;
                    }
                    _plObj.RowId = Convert.ToInt64(_rowId);
                    _plObj.DbType = "DELETE";
                    DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Result"].ToString() == "Y")
                        {
                            BindView();
                            Clear();
                            lblShowMessage("Data Deleted Successfully", 1);
                        }
                        else
                        {
                            lblShowMessage(dt.Rows[0]["Result"].ToString(), 2);
                        }
                    }
                    _rowId = "";
                }
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }

        }

        private void txtLot2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtLotQty.Enabled = true;
                    txtLotQty.Focus();
                }
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void btnFraction_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (dgv.RowCount <= -1)
                    {
                        return;
                    }
                    Clear();

                    _rowId = dgv.Rows[0].Cells["RowId"].Value.ToString();
                    txtPartName.Enabled = txtPartNo.Enabled = false;
                    txtShift.Text = dgv.Rows[0].Cells["Shift"].Value.ToString();
                    txtPartName.Text = dgv.Rows[0].Cells["ModelName"].Value.ToString();
                    txtPartNo.Text = dgv.Rows[0].Cells["ChildPartNo"].Value.ToString();
                    txtTMName.Text = dgv.Rows[0].Cells["TMName"].Value.ToString();
                    if (dgv.Rows[0].Cells["LotNo"].Value.ToString().Contains("/"))
                    {
                        txtLotNo.Text = dgv.Rows[0].Cells["LotNo"].Value.ToString().Split('/')[0];
                        txtLot2.Text = dgv.Rows[0].Cells["LotNo"].Value.ToString().Split('/')[1];
                    }
                    else
                        txtLotNo.Text = dgv.Rows[0].Cells["LotNo"].Value.ToString();
                    txtTLName.Text = dgv.Rows[0].Cells["TLName"].Value.ToString();
                    txtLotQty.Text = dgv.Rows[0].Cells["LotQty"].Value.ToString();
                    //txtModelNo.Enabled = false;
                    //txtModelName.Enabled = false;
                    _IsFraction = true;

                }
                catch (Exception ex)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
