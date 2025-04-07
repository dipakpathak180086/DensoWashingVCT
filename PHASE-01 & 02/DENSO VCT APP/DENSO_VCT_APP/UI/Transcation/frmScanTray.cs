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

        private string _barcode = string.Empty;
        private long _iRowId = 0;
        private long _iRefNo = 0;
        private BL_TRAY_SCANNING _blObj = null;
        private PL_TRAY_SCANNING _plObj = null;
        private int _iRemainderQty = 0;
        private int _iTotalTrays = 0;
        private int _iTrayScan = 0;
        public bool _isClose = false;
        public frmScanTray(long iRowid, long iRefNo = 0)
        {
            InitializeComponent();
            _iRowId = iRowid;
            _iRefNo = iRefNo;
            _blObj = new BL_TRAY_SCANNING();
        }
        #region Private Method
        void ShowAccessScreen()
        {
            frmAccessPassword oFrmLogin = new frmAccessPassword();
            oFrmLogin.ShowDialog();
            if (GlobalVariable.mAccessUser != "" && oFrmLogin.IsCancel == true)
            {
                // lblShowMessage();
            }
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
                lblMessage.BackColor = Color.Red;
                lblMessage.Text = msg;

            }
            else
            {
                lblMessage.BackColor = Color.Transparent;
                lblMessage.Text = msg;
            }
        }
        #endregion



        private void btnClose_Click(object sender, EventArgs e)
        {
            GlobalVariable.mIsDelete = false;
            lblScannedBarcode.Text = "";
            _isClose = true;
            this.Close();
        }
        void Clear()
        {

        }
        private void ScannerDisConnected()
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.DataReceived -= serialPort1_DataReceived;
                    serialPort1.Close();
                    lblScanStatus.Text = "Scanner Dis-Connected";
                    lblScanStatus.BackColor = Color.Red;
                }

            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }
        }
        private void ScannerConnected()
        {
            try
            {
                if (!serialPort1.IsOpen)
                {
                    serialPort1.DataReceived += serialPort1_DataReceived;
                    serialPort1.Open();
                    lblScanStatus.Text = "Scanner Connected";
                    lblScanStatus.BackColor = Color.Green;
                }

            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }
        }
        void BindLabelData()
        {
            try
            {
                PL_TRAY_SCANNING _plObj = new PL_TRAY_SCANNING();
                _plObj.DbType = "BIND_TRAY_LABEL_DATA";
                _plObj.RowId = _iRowId;
                _plObj.RefNo = _iRefNo.ToString();
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    lblModelNo.Text = dt.Rows[0]["ModelNo"].ToString();
                    lblChildPartNo.Text = dt.Rows[0]["ChildPartNo"].ToString();
                    lblTotalQty.Text = dt.Rows[0]["TotalQty"].ToString();
                    lblScanQty.Text = dt.Rows[0]["ScanQty"].ToString();
                    int iTotalQty = Convert.ToInt32(dt.Rows[0]["TotalQty"].ToString());
                    int iScanQty = Convert.ToInt32(dt.Rows[0]["ScanQty"].ToString());
                    int iRemainQty = iTotalQty - iScanQty;
                    int iRemainder = iTotalQty % 6; //28-24
                    _iRemainderQty = iRemainder;
                    int iDevisible = iTotalQty / 6;
                    int iScanQtyAct = iScanQty / 6;
                    int iCalc = iDevisible * 6;
                    int iRemCalc = iCalc + iRemainder;
                    _iTotalTrays = iDevisible;
                    //_iTrayScan = dgv.RowCount;
                    _iTrayScan = iScanQtyAct;
                    if (iRemainder > 0)
                    {
                        _iTotalTrays = iDevisible + 1;
                    }
                    lblTrayScanTotalQty.Text = _iTrayScan + "/" + _iTotalTrays;
                }
                else
                {
                    lblModelNo.Text = lblChildPartNo.Text = lblTotalQty.Text = lblScanQty.Text = lblTrayScanTotalQty.Text = "XXXXXXXXXXXXX";
                    MessageBox.Show("THIS IS THE OLD ENTRY CAN'T MAPPED TRAY!!!!!");
                    this.Close();
                }


            }
            catch (Exception ex)
            {

                lblShowMessage(ex.Message, 2);
            }

        }
        void BindView()
        {
            try
            {
                for (int i = dgv.Rows.Count - 1; i >= 0; i--)
                {
                    dgv.Rows.RemoveAt(i);
                }

                PL_TRAY_SCANNING _plObj = new PL_TRAY_SCANNING();
                _plObj.DbType = "BIND_VIEW";
                _plObj.RowId = _iRowId;
                _plObj.RefNo = _iRefNo.ToString();
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    dgv.DataSource = dt.DefaultView;


                }




            }
            catch (Exception ex)
            {

                lblShowMessage(ex.Message, 2);
            }

        }
        private void frmScanTray_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                btnAuto.BackColor = Color.Yellow;
                btnManual.BackColor = Color.Transparent;
                timer1.Stop();
                timer1.Start();
                lblModelNo.Text = lblChildPartNo.Text = lblTotalQty.Text = lblScanQty.Text = lblTrayScanTotalQty.Text = "XXXXXXXXXXXXX";
                txtScanTray.Text = "";
                BindView();
                BindLabelData();
                lblShowMessage("Please Scan Tray!!!", 1);
                if (!serialPort1.IsOpen)
                {
                    serialPort1.PortName = GlobalVariable.mKitScannerPort;
                    serialPort1.Open();     // open port
                    lblScanStatus.Text = "Scanner Connected";
                    lblScanStatus.BackColor = Color.Green;
                }
                else
                {
                    lblScanStatus.Text = "Scanner Dis-Connected";
                    lblScanStatus.BackColor = Color.Red;
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


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ShowAccessScreen();
                if (GlobalVariable.mAccessUser == "")
                {
                    goto SameForm;
                }
                string strTray = "";
                GlobalVariable.mAccessUser = "";
                //Atleast one Module right
                bool IsChecked = false;


                foreach (DataGridViewRow row in dgv.Rows)
                {

                    if (Convert.ToBoolean(row.Cells["chkSelect"].Value) == true)
                    {
                        strTray = row.Cells["TRAYS"].Value.ToString();
                        IsChecked = true;
                        break;
                    }
                }

                if (IsChecked == false)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Select Atleast one data!!", 3);
                    goto SameForm;
                }
                DialogResult dre = MessageBox.Show("Are you sure want to un-mapped the tray ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dre == DialogResult.No)
                {
                    goto SameForm;
                }
                DataTable dt = null;
                foreach (DataGridViewRow row in dgv.Rows)
                {

                    if (Convert.ToBoolean(row.Cells["chkSelect"].Value) == true)
                    {
                        strTray = row.Cells["TRAYS"].Value.ToString();
                        PL_TRAY_SCANNING _plObj = new PL_TRAY_SCANNING();
                        _plObj.DbType = "UN_MAPPED";
                        _plObj.RowId = _iRowId;
                        _plObj.ModelNo = lblModelNo.Text.Trim();
                        _plObj.ChildPartNo = lblChildPartNo.Text.Trim();
                        _plObj.TrayBarcode = strTray;
                        _plObj.CreatedBy = GlobalVariable.UserName;
                        dt = _blObj.BL_ExecuteTask(_plObj);
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["RESULT"].Equals("Y"))
                    {
                        lblShowMessage($" Trays Unmapped Successfully!!!!", 1);
                        BindView();
                        BindLabelData();
                        txtScanTray.Text = "";
                    }
                    else
                    {
                        lblShowMessage($" {dt.Rows[0]["RESULT"].ToString()}", 2);
                        txtScanTray.Text = "";
                    }
                }

            }
            catch (Exception ex)
            {

                lblShowMessage(ex.Message, 2);
            }
        SameForm:
            this.Focus();
        }
        private void FinalSave()
        {
            this.Invoke(new Action(() =>
            {
                try
                {
                    lblScannedBarcode.Text = txtScanTray.Text.Trim();
                    if (_iTotalTrays == _iTrayScan)
                    {
                        lblShowMessage("Please scan Lot card First!!!", 2);
                        txtScanTray.Text = "";
                        txtScanTray.Focus();
                        goto SameForm;
                    }

                    PL_TRAY_SCANNING _plObj = new PL_TRAY_SCANNING();
                    _plObj.DbType = "MAPPED";
                    _plObj.RowId = _iRowId;
                    _plObj.ModelNo = lblModelNo.Text.Trim();
                    _plObj.ChildPartNo = lblChildPartNo.Text.Trim();
                    _plObj.Barcode = txtScanTray.Text.Trim();
                    _plObj.LotNo = "";
                    _plObj.TrayBarcode = txtScanTray.Text.Trim();
                    _plObj.RefNo = _iRefNo.ToString();
                    if (_iTotalTrays == _iTrayScan + 1 && _iRemainderQty != 0)
                    {
                        _plObj.Qty = _iRemainderQty;
                    }
                    else
                    {
                        _plObj.Qty = 6;
                    }
                    _plObj.CreatedBy = GlobalVariable.UserName;
                    DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["RESULT"].Equals("Y"))
                        {
                            lblShowMessage($" Tray {txtScanTray.Text.Trim()} Scanned,Please Scan Next Tray!!!!", 1);
                            BindView();
                            BindLabelData();
                            txtScanTray.Text = "";
                            //if (dgv.Rows.Count == 4)
                            if (dt.Rows[0]["TRY_COUNT"].ToString().Equals("4"))
                            {
                                btnClose_Click(null, null);
                            }
                            if (_iTotalTrays == _iTrayScan)
                            {
                                lblShowMessage("This Lot card all child parts used,Scan new Lot card", 1);
                                goto SameForm;
                            }
                        }
                        else
                        {
                            lblShowMessage($" {dt.Rows[0]["RESULT"].ToString()}", 2);
                            txtScanTray.Text = "";
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
            SameForm:
                this.ResumeLayout();
            }));
        }
        private void txtScanTray_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {

                    if (txtScanTray.Text.Trim().Length != 6 && txtScanTray.Text.Trim().Length > 12)
                    {

                        GlobalVariable.mIsTrayBarcode = false;
                        GlobalVariable.mScannedBarcode = txtScanTray.Text.Trim();
                        GlobalVariable.mIsLotBarcode = true;
                        this.Close();
                    }

                    FinalSave();


                }
                catch (Exception ex)
                {

                    lblShowMessage(ex.Message, 2);
                }

            }
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgv.Columns["chkSelect"].Index && e.RowIndex >= 0)
                {
                    object value = dgv.Rows[e.RowIndex].Cells["chkSelect"].Value;

                    if (value == null || value == DBNull.Value) // Handle null values
                    {
                        dgv.Rows[e.RowIndex].Cells["chkSelect"].Value = true; // Set to true if null
                    }
                    else
                    {
                        bool currentValue = Convert.ToBoolean(value);
                        dgv.Rows[e.RowIndex].Cells["chkSelect"].Value = !currentValue;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.Invoke(new Action(() => 
            //{
            //    GlobalVariable.mScannedBarcode = txtScanTray.Text.Trim();
            //    GlobalVariable.mIsLotBarcode = true;
            //}
            //));
        }

        private void frmScanTray_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }

        private void frmScanTray_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            ScannerDisConnected();
        }
        private volatile bool _keepReading = true;
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {

                string PLCdata = serialPort1.ReadExisting();
                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Tray Scanner Data:: ", PLCdata);
                //SerialPort port = (SerialPort)sender;
                //byte[] data = new byte[port.BytesToRead];
                //port.Read(data, 0, data.Length);
                //string PLCdata = Encoding.GetEncoding("Windows-1252").GetString(data);
                //serialPort1.DiscardInBuffer();
                //serialPort1.DiscardOutBuffer();
                // Thread.Sleep(2000);
                this.Invoke((MethodInvoker)delegate
                {
                    timer1.Start();
                    if (txtScanTray.Text.Trim().Length != 6 && txtScanTray.Text.Trim().Length > 12)
                    {

                        GlobalVariable.mIsTrayBarcode = false;
                        GlobalVariable.mScannedBarcode = txtScanTray.Text.Trim();
                        GlobalVariable.mIsLotBarcode = true;
                        this.Close();
                    }

                    string _ScannerMsg = PLCdata.ToString().Replace("\r", "").Replace(",", "|").TrimEnd('|').Trim();
                    txtScanTray.Text = _ScannerMsg;
                    Task.Run(() => { FinalSave(); });
                    //  _ScannerMsg = _ScannerMsg.Trim().Replace("*", "").Replace("@", "").Replace(",", "|").Trim();

                    //if (_ScannerMsg.Contains('|'))
                    //{

                    //}
                    //else
                    //{
                    //    GlobalVariable.MesseageInfo(lblMessage, "Invalid QR Code!!!", 2);
                    //    this.txtScanTray.SelectAll();
                    //    this.txtScanTray.Focus();
                    //    //PlayValidationSound();
                    //    ShowAccessScreen();
                    //    return;
                    //}
                });
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    GlobalVariable.MesseageInfo(lblMessage, ex.Message, 2);
                });
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmScanTray_Shown(object sender, EventArgs e)
        {

        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            try
            {
                ShowAccessScreen();
                if (GlobalVariable.mAccessUser != "")
                {

                    btnAuto.BackColor = Color.Yellow;
                    btnManual.BackColor = Color.Transparent;
                    txtScanTray.ReadOnly = true;
                    txtScanTray.Focus();
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                        lblScanStatus.Text = "Scanner Dis-Connected";
                        lblScanStatus.BackColor = Color.Red;
                    }





                    GlobalVariable.mAccessUser = "";

                }
            }
            catch (Exception ex)
            {

                this.Invoke((MethodInvoker)delegate
                {
                    GlobalVariable.MesseageInfo(lblMessage, ex.Message, 2);
                });
            }
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            try
            {


                ShowAccessScreen();
                if (GlobalVariable.mAccessUser != "")
                {
                    txtScanTray.Text = "";
                    btnAuto.BackColor = Color.Transparent;
                    btnManual.BackColor = Color.Yellow;
                    txtScanTray.ReadOnly = false;
                    txtScanTray.Focus();
                    if (!serialPort1.IsOpen)
                    {
                        serialPort1.PortName = GlobalVariable.mKitScannerPort;
                        serialPort1.Open();     // open port
                        lblScanStatus.Text = "Scanner Connected";
                        lblScanStatus.BackColor = Color.Green;
                    }



                    GlobalVariable.mAccessUser = "";

                }
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    GlobalVariable.MesseageInfo(lblMessage, ex.Message, 2);
                });

            }
        }
    }
}
