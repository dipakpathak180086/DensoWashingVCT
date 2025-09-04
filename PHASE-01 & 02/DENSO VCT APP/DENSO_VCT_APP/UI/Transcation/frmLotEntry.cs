
using DENSO_VCT_BL;
using DENSO_VCT_COMMON;
using DENSO_VCT_PL;
using SatoLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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
        SatoLib.PortReader _ScannerPortReader;
        delegate void dlgScannerProcess();
        private volatile bool _isClosing = false;
        #endregion

        #region Variables Trays Scanning
        private string _barcode = string.Empty;
        private long _iRowId = 0;
        private long _iRefNo = 0;
        private BL_TRAY_SCANNING _blTrayObj = null;
        private PL_TRAY_SCANNING _plTrayObj = null;
        private int _iRemainderQty = 0;
        private int _iTotalTrays = 0;
        private int _iTrayScan = 0;
        private volatile bool _isTrayClosing = false;
        public bool _isTrayClose = false;
        #endregion

        #region Form Methods

        public frmLotEntry()
        {
            try
            {
                InitializeComponent();
                _blTrayObj = new BL_TRAY_SCANNING();
            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }
        }
        void DisConnectScanner()
        {
            try
            {
                //if (serialPort1 != null && serialPort1.IsOpen)
                //{
                //    // Detach event handler if you used one
                //    serialPort1.DataReceived -= serialPort1_DataReceived;

                //    // Stop any ongoing read/write operations
                //    serialPort1.ReadTimeout = 500;
                //    serialPort1.DiscardInBuffer();
                //    serialPort1.DiscardOutBuffer();

                //    // Close and dispose
                //    serialPort1.Close();
                //    serialPort1.Dispose();
                //}

                //lblScanStatus.Text = "Scanner Dis-Connected";
                //lblScanStatus.BackColor = Color.Red;
                ScannerDisConnected();
            }
            catch (Exception ex)
            {
                GlobalVariable.AppLog.LogMessage(EventNotice.EventTypes.evtError, this.Name + "(DisConnectScanner)", ex.StackTrace);
            }
        }
        /// <summary>
        /// Connect Com Based Scaaner
        /// </summary>
        /// <returns></returns>
        bool ConnectScanner()
        {
            bool _bl = false;
            try
            {
                _ScannerPortReader = new PortReader();
                _ScannerPortReader.PortName = GlobalVariable.mKitScannerPort;
                _ScannerPortReader.BaudRate = GlobalVariable.mKitScannerBaudRate;
                _ScannerPortReader.DateBit = GlobalVariable.mKitScannerDataBits;
                _ScannerPortReader.StopBit = GlobalVariable.mKitScannerStopBits;
                _ScannerPortReader.Parity = GlobalVariable.mKitScannerParity;
                _ScannerPortReader.EndReadEvent += new PortReader.PortReaderEventHandler(ScannerProcess);
                if (_ScannerPortReader.DoOpen() == true)
                    _bl = true;
            }
            catch (Exception ex)
            {
                GlobalVariable.AppLog.LogMessage(EventNotice.EventTypes.evtError, this.Name + "(ConnectScanner)", ex.StackTrace);
                throw ex;
            }
            return _bl;
        }
        void ScannerProcess()
        {
            string _sParentItem = string.Empty;
            string _sCategory = "";
            Int32 _iPrimaryMoq = 0;
            Int32 _iSecMoq = 0;
            Int32 _iMaxMoq = 0;
            bool _chkSelect = false;
            string _sKitScanMode = "";//Primary/Secoundary

            try
            {
                if (this.InvokeRequired)
                    this.Invoke(new dlgScannerProcess(ScannerProcess));
                else
                {
                    lblShowMessage();
                    ArrayList _ArrayList;
                    string _ScannerMsg = _ScannerPortReader.Message.ToString().Trim();
                    _ScannerMsg = _ScannerMsg.Trim().Replace("*", "").Replace("@", "").Replace(",", "|").Trim();

                    if (_ScannerMsg.Contains('|'))
                    {
                        if (_ScannerMsg.Split('|').Length > 3)
                        {

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

                            //*************************************************************************
                            _ScannerMsg = _ScannerMsg.Trim().Replace("(", "").Replace(")", "").Trim();

                            _ScannerMsg = GlobalVariable.mStoCustomFunction.BarCodeRule(_ScannerMsg).ToUpper().Trim();
                            txtLotNo.Text = _ScannerMsg;
                            string lotNoBarcode = txtLotNo.Text.Trim();
                            if (!GlobalVariable.mdicChildPart.ContainsValue(lotNoBarcode.Split('|')[0].ToString()))
                            {
                                GlobalVariable.MesseageInfo(lblMessage, "Invalid QR Code against model no.!!!", 2);
                                this.txtLotNo.SelectAll();
                                this.txtLotNo.Focus();
                                //PlayValidationSound();
                                ////ShowAccessScreen();
                                return;
                            }
                            else
                            {
                                GlobalVariable.mChildPart = GlobalVariable.mdicChildPart.FirstOrDefault(x => x.Value == lotNoBarcode.Split('|')[0].ToString()).Value;
                                GlobalVariable.mChildPartName = GlobalVariable.mdicChildPart.FirstOrDefault(x => x.Value == lotNoBarcode.Split('|')[0].ToString()).Key;

                                txtPartName.Text = GlobalVariable.mChildPartName;
                                txtPartNo.Text = GlobalVariable.mChildPart;
                                Common common = new Common();
                                txtShift.Text = GlobalVariable.mShift = common.GetShift();
                                BindView();
                                GetTMAndTLLastData();
                                GetShiftWiseTotalQty();
                            }
                            lblBarcode.Text = lotNoBarcode;
                            lblLastScannedLotBarcode.Visible = true;
                            lblLastScannedLotBarcode.Text = "Last Scan Lot QR Code If Any * :" + lotNoBarcode;

                            txtLotQty.Text = lotNoBarcode.Split('|')[1].ToString();
                            lblVendorCode.Text = lotNoBarcode.Split('|')[2].ToString();
                            txtLotNo.Text = lotNoBarcode.Split('|')[3].ToString();
                            txtSerialNo.Text = lotNoBarcode.Split('|')[4].ToString();
                            FinalSave();
                        }
                    }




                }

            }
            catch (Exception ex)
            {
                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtError, typeof(frmLotEntry).FullName + "::" + MethodBase.GetCurrentMethod().Name, ex.Message);

                lblShowMessage(ex.Message, 2);
            }
        }
        private bool HasSpecialChars(string input)
        {
            // Define what you consider to be special characters
            string specialChars = @"|";
            foreach (char c in input)
            {
                if (specialChars.Contains(c))
                {
                    return true;
                }
            }
            return false;
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

        private void ShowTrayScanning()
        {
            pnlScantray.Visible = true;
            lblHeader.Dock = DockStyle.None;
            pnlScantray.Size = this.ClientSize;
            pnlScantray.Location = new Point(0, 0);
            pnlScantray.Dock = DockStyle.Fill;
            frmScanTray_Load(null, null);

        }
        private void HideTrayScanning()
        {
            pnlScantray.Visible = false;
            lblHeader.Dock = DockStyle.Top;
            pnlScantray.Size = new Size(0, 0);
            pnlScantray.Location = new Point(0, 0);
            pnlScantray.Dock = DockStyle.None;
            BindView();
        }

        private void LotCardScanning(string PLCdata)
        {
            try
            {
                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Lot Scanner Data:: ", PLCdata);

                this.Invoke((MethodInvoker)delegate
                {
                    timer1.Start();
                    if (txtLotNo.Text.Trim().Length == 6)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Please scan Lot card First!!!", 2);
                        this.txtPartName.SelectAll();
                        this.txtPartName.Focus();
                        //PlayValidationSound();
                        //ShowAccessScreen();
                        return;

                    }
                    //MessageBox.Show(PLCdata.Replace("\r", "").Trim());
                    //txtLotNo.Text = PLCdata;
                    txtLotNo.Text = txtLot2.Text = txtSerialNo.Text = lblBarcode.Text = "";
                    txtLotNo.Text = txtLot2.Text = txtSerialNo.Text = "";
                    lblShowMessage();
                    ArrayList _ArrayList;
                    string _ScannerMsg = PLCdata.ToString().Replace("\r", "").Replace(",", "|").TrimEnd('|').Trim();
                    //  _ScannerMsg = _ScannerMsg.Trim().Replace("*", "").Replace("@", "").Replace(",", "|").Trim();

                    if (_ScannerMsg.Contains('|'))
                    {
                        if (_ScannerMsg.Split('|').Length > 3)
                        {
                            txtLotNo.Text = _ScannerMsg;
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

                            //*************************************************************************
                            _ScannerMsg = _ScannerMsg.Trim().Replace("(", "").Replace(")", "").Trim();

                            //       _ScannerMsg = GlobalVariable.mStoCustomFunction.BarCodeRule(_ScannerMsg).ToUpper().Trim();
                            txtLotNo.Text = _ScannerMsg;
                            string lotNoBarcode = txtLotNo.Text.Trim();
                            if (!GlobalVariable.mdicChildPart.ContainsValue(lotNoBarcode.Split('|')[0].ToString()))
                            {
                                GlobalVariable.MesseageInfo(lblMessage, "Invalid QR Code against Model no.!!!", 2);
                                this.txtLotNo.SelectAll();
                                this.txtLotNo.Focus();
                                //PlayValidationSound();
                                ShowAccessScreen();
                                return;
                            }
                            else
                            {
                                GlobalVariable.mChildPart = GlobalVariable.mdicChildPart.FirstOrDefault(x => x.Value == lotNoBarcode.Split('|')[0].ToString()).Value;
                                GlobalVariable.mChildPartName = GlobalVariable.mdicChildPart.FirstOrDefault(x => x.Value == lotNoBarcode.Split('|')[0].ToString()).Key;

                                txtPartName.Text = GlobalVariable.mChildPartName;
                                txtPartNo.Text = GlobalVariable.mChildPart;
                                Common common = new Common();
                                txtShift.Text = GlobalVariable.mShift = common.GetShift();
                                BindView();
                                //GetTMAndTLLastData();
                                GetShiftWiseTotalQty();
                            }
                            lblBarcode.Text = lotNoBarcode;
                            lblLastScannedLotBarcode.Visible = true;
                            lblLastScannedLotBarcode.Text = "Last Scan Lot QR Code If Any * :" + lotNoBarcode;

                            txtLotQty.Text = lotNoBarcode.Split('|')[1].ToString();
                            lblVendorCode.Text = lotNoBarcode.Split('|')[2].ToString();
                            txtLotNo.Text = lotNoBarcode.Split('|')[3].ToString();
                            txtSerialNo.Text = lotNoBarcode.Split('|')[4].ToString();
                            Task.Run(new Action(() => { FinalSave(); }));
                        }
                    }
                    else
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Invalid QR Code!!!", 2);
                        this.txtLotNo.SelectAll();
                        this.txtLotNo.Focus();
                        //PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
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

        private void TrayScanning(string PLCdata)
        {
            try
            {
                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Tray Scanner Data:: ", PLCdata);

                this.BeginInvoke((MethodInvoker)delegate
                {


                    string _ScannerMsg = PLCdata.ToString().Replace("\r", "").Replace(",", "|").TrimEnd('|').Trim();
                    if (string.IsNullOrWhiteSpace(_ScannerMsg)) { return; }
                    txtScanTray.Text = _ScannerMsg;
                    Application.DoEvents();

                    if (txtScanTray.Text.Trim().Length != 6 && txtScanTray.Text.Trim().Length > 12)
                    {

                        GlobalVariable.mIsTrayBarcode = false;
                        lblScannedTrayBarcode.Text = txtScanTray.Text.Trim();
                        GlobalVariable.mScannedBarcode = txtScanTray.Text.Trim();
                        GlobalVariable.mIsLotBarcode = true;
                        HideTrayScanning();
                        return;
                    }

                    Task.Run(() => { FinalTraySave(); });

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

                this.BeginInvoke((MethodInvoker)delegate
                {
                    GlobalVariable.MesseageInfo(lblTrayMessage, ex.Message, 2);
                });
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
                btnAuto.BackColor = Color.Yellow;
                btnManual.BackColor = Color.Transparent;
                btnTrayAuto.BackColor = Color.Yellow;
                btnTrayManual.BackColor = Color.Transparent;
                //GetLotAndQtyLengthData();
                //GetWashingQty();
                GetTMAndTLLastData();

                // txtTMName.Focus();
                txtLotNo.Select();
                txtLotNo.Focus();
                //BindChildMenu();
                GlobalVariable.mWashingQty = 0;
                GetShiftWiseTotalQty();
                //if (ConnectScanner() == true)
                //{

                //    lblScanStatus.Text = "Scanner Connected";
                //    lblScanStatus.BackColor = Color.Green;
                //}
                //else
                //{
                //    lblScanStatus.Text = "Scanner Dis-Connected";
                //    lblScanStatus.BackColor = Color.Red;
                //}
                //Task.Run(() =>
                //{


                //});

                //if (!serialPort1.IsOpen)
                //{
                //    serialPort1.PortName = GlobalVariable.mKitScannerPort;
                //    serialPort1.ReadTimeout = 500; // in ms
                //    serialPort1.Open();     // open port
                //    lblScanStatus.Text = "Scanner Connected";
                //    lblScanStatus.BackColor = Color.Green;
                //}
                //else
                //{
                //    lblScanStatus.Text = "Scanner Dis-Connected";
                //    lblScanStatus.BackColor = Color.Red;
                //}
                try
                {
                    SerialPortManager.AttachHandler(serialPort1_DataReceived);
                    SerialPortManager.Open();

                    lblScanStatus.Text = lblTrayScanStatus.Text = "Scanner Connected";
                    lblScanStatus.BackColor = lblTrayScanStatus.BackColor = Color.Green;
                }
                catch (Exception ex)
                {
                    lblScanStatus.Text = lblTrayScanStatus.Text = "Scanner Dis-Connected";
                    lblScanStatus.BackColor = lblTrayScanStatus.BackColor = Color.Red;
                    lblShowMessage("Error: " + ex.Message, 2);
                    lblShowTrayMessage("Error: " + ex.Message, 2);
                }
            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
                lblShowTrayMessage(ex.Message, 2);
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
            //DisConnectScanner();
            //if (serialPort1.IsOpen)
            //{
            //    //serialPort1.PortName = "COM1";
            //    serialPort1.Close();
            //}
            DisConnectScanner();
            timer1.Stop();
            this.Close();
        }

        #endregion

        #region Methods
        private void ScannerDisConnected()
        {
            try
            {
                //// Detach event handler if you used one
                //_keepReading = false;

                //// Give the DataReceived thread a moment to finish
                //Thread.Sleep(100); // Optional: avoid if port is already idle
                //serialPort1.DiscardInBuffer();
                //serialPort1.DiscardOutBuffer();
                //if (serialPort1 != null && serialPort1.IsOpen)
                //{

                //    serialPort1.DataReceived -= serialPort1_DataReceived; // Unsubscribe
                //    serialPort1.Close();
                //    serialPort1.Dispose();
                //    Thread.Sleep(200); // Allow time to release port
                //    GC.Collect();
                //    GC.WaitForPendingFinalizers();
                //}

                //lblScanStatus.Text = "Scanner Dis-Connected";
                //lblScanStatus.BackColor = Color.Red;
                if (SerialPortManager.Port.IsOpen)
                {
                    SerialPortManager.DetachHandler(serialPort1_DataReceived);
                    SerialPortManager.Close();
                    lblScanStatus.Text = lblTrayScanStatus.Text = "Scanner Dis-Connected";
                    lblScanStatus.BackColor = lblTrayScanStatus.BackColor = Color.Red;
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
                //if (!serialPort1.IsOpen)
                //{
                //serialPort1.PortName = GlobalVariable.mKitScannerPort;
                //serialPort1.ReadTimeout = 1000;
                //serialPort1.WriteTimeout = 1000;
                //serialPort1.DataReceived += serialPort1_DataReceived;
                //serialPort1.Open();
                //lblScanStatus.Text = "Scanner Connected";
                //lblScanStatus.BackColor = Color.Green;
                //GC.Collect();
                //GC.WaitForPendingFinalizers();

                //}
                if (SerialPortManager.Port.IsOpen == false)
                {
                    SerialPortManager.AttachHandler(serialPort1_DataReceived);
                    SerialPortManager.Open();
                    lblScanStatus.Text = lblTrayScanStatus.Text = "Scanner Connected";
                    lblScanStatus.BackColor = lblTrayScanStatus.BackColor = Color.Green;
                }


            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }
        }
        private void OFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }
        private void Clear()
        {
            try
            {
                lblLastScannedLotBarcode.Text = "Last Scan Lot QR Code If Any * :";
                lblLastScannedLotBarcode.Visible = false;
                lblMessage.BackColor = Color.Transparent;
                lblMessage.Text = "";
                lblVendorCode.Text = "";
                txtTLName.Text = txtTMName.Text = txtLotNo.Text = txtSerialNo.Text = txtLot2.Text = txtLotQty.Text = "";

                txtLotNo.Focus();
                // GetLotAndQtyLengthData();
                GetTMAndTLLastData();
                chkManualDate.Checked = false;
                GlobalVariable.mWashingQtyAlert = false;
                _IsUpdate = false;
                _IsFraction = false;
                dpDateTime.Value = DateTime.Now;
                GlobalVariable.mIsTrayScanning = false;
                GlobalVariable.mIsDelete = false;
                GlobalVariable.mTray01 = GlobalVariable.mTray02 = GlobalVariable.mTray03 = GlobalVariable.mTray04 = "";
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
        void GetWashingQty()
        {
            try
            {
                _blObj = new BL_LOT_ENTRY();
                _plObj = new PL_LOT_ENTRY();
                _plObj.DbType = "GET_WASHING_QTY";
                _plObj.ModelNo = GlobalVariable.mParentPart;
                _plObj.ChildPartNo = GlobalVariable.mChildPart;
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    GlobalVariable.mWashingQty = Convert.ToInt32(dt.Rows[0]["WashingQty"].ToString());
                }
            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }
        }
        void GetTMAndTLLastData()
        {
            this.Invoke(new Action(() =>
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
            }));
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
        int iFinalViewTrayIndex = 0;
        private void ToggleColumnType(bool condition)
        {
            string buttonColumnName = "btnViewTrays";  // Button column name
            string textColumnName = "ViewTrays";    // Text column name
            int columnIndex = -1; // Initialize properly

            // Find the column index for reference
            if (iFinalViewTrayIndex == 0)
            {
                if (dgv.Columns.Contains(buttonColumnName))
                    iFinalViewTrayIndex = dgv.Columns[buttonColumnName].Index;
                else if (dgv.Columns.Contains(textColumnName))
                    iFinalViewTrayIndex = dgv.Columns[textColumnName].Index;
            }

            // Remove both columns if they exist
            if (dgv.Columns.Contains(buttonColumnName))
            {
                columnIndex = dgv.Columns[buttonColumnName].Index;
                dgv.Columns.Remove(buttonColumnName);
                if (dgv.Columns.Contains(textColumnName))
                    dgv.Columns.Remove(textColumnName);
                dgv.RefreshEdit();
            }
            if (dgv.Columns.Contains(textColumnName))
            {
                columnIndex = dgv.Columns[textColumnName].Index;
                dgv.Columns.Remove(textColumnName);
            }

            // Store old column data before removing the column
            List<string> cellValues = new List<string>();
            if (columnIndex != -1)  // Only if a column existed before
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!row.IsNewRow && row.Cells.Count > columnIndex)
                        cellValues.Add(row.Cells[columnIndex]?.Value?.ToString() ?? "");
                }
            }

            DataGridViewColumn newColumn;

            if (condition)
            {
                // Create a Button Column
                newColumn = new DataGridViewButtonColumn
                {
                    Name = buttonColumnName,
                    HeaderText = "View Trays",
                    Text = "View Trays",
                    UseColumnTextForButtonValue = true,
                    ReadOnly = false
                };
            }
            else
            {
                // Create a Read-Only TextBox Column
                newColumn = new DataGridViewTextBoxColumn
                {
                    Name = textColumnName,
                    HeaderText = "View Trays",
                    ReadOnly = true
                };
            }

            // Insert at the correct index
            int insertIndex = (columnIndex >= 0 && columnIndex < dgv.Columns.Count) ? columnIndex : dgv.Columns.Count;

            if (iFinalViewTrayIndex == 0)
                iFinalViewTrayIndex = insertIndex;

            dgv.Columns.Insert(iFinalViewTrayIndex, newColumn);

            // Restore old values for the column
            for (int i = 0; i < cellValues.Count; i++)
            {
                if (i < dgv.Rows.Count) // Ensure index is valid
                {
                    dgv.Rows[i].Cells[iFinalViewTrayIndex].Value = condition ? cellValues[i] : "";
                }
            }

            // Refresh the DataGridView to reflect changes
            dgv.Refresh();
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

                        _blObj = new BL_LOT_ENTRY();
                        _plObj = new PL_LOT_ENTRY();
                        _plObj.DbType = "VIEW_TRAY_BUTTON_ENABLE_DISABLE";
                        _plObj.ModelNo = GlobalVariable.mParentPart;
                        _plObj.ChildPartNo = GlobalVariable.mChildPart;
                        DataTable dtCheck = _blObj.BL_ExecuteTask(_plObj);
                        if (dtCheck.Rows.Count > 0)
                        {
                            GlobalVariable.mIsTrayEnable = Convert.ToBoolean(dtCheck.Rows[0]["IsTrayScanning"]);
                            ToggleColumnType(Convert.ToBoolean(dtCheck.Rows[0]["IsTrayScanning"]));


                        }

                        //for (int i = 0; i < dgv.ColumnCount; i++)
                        //{
                        //    this.dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        //    if (dgv.ColumnCount - 1 == i)
                        //    {
                        //        this.dgv.Columns[dgv.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        //    }

                        //}
                    }
                }
                catch (Exception ex)
                {
                    lblShowMessage(ex.Message, 2);
                }
                // dgv.ResumeLayout(true);
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
                lblMessage.BackColor = Color.Red;
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


        private void FinalSave(string strFromTrayModuleBarcode = "", bool _isClose = false)
        {
            this.Invoke(new Action(() =>
            {
                try
                {



                    if (_isClose) { return; }
                    if (strFromTrayModuleBarcode.Contains("|") || strFromTrayModuleBarcode.Contains(","))
                    {
                        strFromTrayModuleBarcode = strFromTrayModuleBarcode.Trim().Replace(",", "|");

                        string lotNoBarcode = strFromTrayModuleBarcode.Trim();
                        if (!GlobalVariable.mdicChildPart.ContainsValue(lotNoBarcode.Split('|')[0].ToString()))
                        {
                            GlobalVariable.MesseageInfo(lblMessage, "Invalid card against model no.!!!", 2);
                            this.txtLotNo.SelectAll();
                            this.txtLotNo.Focus();
                            //PlayValidationSound();
                            ////ShowAccessScreen();
                            return;
                        }
                        else
                        {
                            GlobalVariable.mChildPart = GlobalVariable.mdicChildPart.FirstOrDefault(x => x.Value == lotNoBarcode.Split('|')[0].ToString()).Value;
                            GlobalVariable.mChildPartName = GlobalVariable.mdicChildPart.FirstOrDefault(x => x.Value == lotNoBarcode.Split('|')[0].ToString()).Key;

                            txtPartName.Text = GlobalVariable.mChildPartName;
                            txtPartNo.Text = GlobalVariable.mChildPart;
                            Common common = new Common();
                            txtShift.Text = GlobalVariable.mShift = common.GetShift();
                            BindView();
                            //  GetTMAndTLLastData();
                            GetShiftWiseTotalQty();
                        }
                        lblBarcode.Text = lotNoBarcode;
                        lblLastScannedLotBarcode.Visible = true;
                        lblLastScannedLotBarcode.Text = "Last Scan Lot card If Any * :" + lotNoBarcode;

                        txtLotQty.Text = lotNoBarcode.Split('|')[1].ToString();
                        lblVendorCode.Text = lotNoBarcode.Split('|')[2].ToString();
                        txtLotNo.Text = lotNoBarcode.Split('|')[3].ToString();
                        txtSerialNo.Text = lotNoBarcode.Split('|')[4].ToString();

                    }
                    lblShowMessage();
                    //if (!txtLotNo.Text.Trim().Contains("|"))
                    //{
                    //    lblBarcode.Text = "";
                    //}

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
                    if (txtSerialNo.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Serial No can't be blank!!!", 2);
                        this.txtSerialNo.SelectAll();
                        this.txtSerialNo.Focus();
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
                    _plObj.ModelName = GlobalVariable.mParentPartName;
                    _plObj.ChildPartNo = txtPartNo.Text.Trim();
                    _plObj.ChildPartName = GlobalVariable.mChildPartName;
                    _plObj.TMName = txtTMName.Text.Trim();
                    _plObj.TLName = txtTLName.Text.Trim();
                    if (lblBarcode.Text.Contains("|"))
                    {
                        _plObj.LotNo = txtLotNo.Text.Trim(); //Using BARCODE
                        _plObj.SerialNo = txtSerialNo.Text;
                        _plObj.VendorCode = lblVendorCode.Text;
                        _plObj.Barcode = lblBarcode.Text;
                    }
                    else
                    {
                        _plObj.LotNo = txtLot2.Text.Trim().Equals("") ? txtLotNo.Text.Trim() : txtLotNo.Text.Trim() + "/" + txtLot2.Text.Trim();
                        _plObj.SerialNo = txtSerialNo.Text;
                        _plObj.VendorCode = lblVendorCode.Text;
                        lblBarcode.Text = _plObj.LotNo + "/" + txtSerialNo.Text;
                        _plObj.Barcode = _plObj.LotNo + "/" + txtSerialNo.Text;

                    }
                    //if (_plObj.LotNo.Length >= txtLotNo.MaxLength)
                    //{
                    //    GlobalVariable.MesseageInfo(lblMessage, $"Enter Lot No, Length should be less than  {txtLotNo.MaxLength}!!!", 2);
                    //    this.txtLotNo.SelectAll();
                    //    this.txtLotNo.Focus();
                    //    return;
                    //}
                    _plObj.LotQty = Convert.ToInt32(txtLotQty.Text.Trim());
                    _plObj.Shift = txtShift.Text.Trim();
                    _plObj.Manual_Date = chkManualDate.Checked;
                    _plObj.Date = dpDateTime.Value.ToString("yyyy-MM-dd");
                    _plObj.Time = dpDateTime.Value.ToString("HH:mm:ss.fff");
                    _plObj.CreatedBy = GlobalVariable.UserName = txtTMName.Text.Trim();

                    _plObj.DbType = "CHECK_LOT_SCANNING_COMPLETED";
                    DataTable dtCheckIncompleteScanning = _blObj.BL_ExecuteTask(_plObj);
                    if (dtCheckIncompleteScanning.Rows.Count > 0 && GlobalVariable.mIsTrayEnable == true)
                    {
                        string strPendingLots = "";
                        string[] strAppednLot = new string[dtCheckIncompleteScanning.Rows.Count];
                        for (int i = 0; i < dtCheckIncompleteScanning.Rows.Count; i++)
                        {
                            if (!dtCheckIncompleteScanning.Rows[0]["LotQty"].Equals(dtCheckIncompleteScanning.Rows[0]["ScanQty"]))
                            {
                                strAppednLot[i] = dtCheckIncompleteScanning.Rows[0]["LotNo"].ToString();

                            }
                        }
                        strPendingLots = string.Join(",", strAppednLot);
                        if (!dtCheckIncompleteScanning.Rows[0]["LotQty"].Equals(dtCheckIncompleteScanning.Rows[0]["ScanQty"]))
                        {
                            //GlobalVariable.ShowCustomMessageBox(this, $"These lots ({strPendingLots}) have trays with incomplete scanning!!!");
                        }
                    }
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
                                if (GlobalVariable.mIsTrayEnable == true)
                                {
                                    //long iRowId = 0;
                                    //long iRefNo = 0;
                                    _iRowId = 0; _iRefNo = 0;
                                    try
                                    {
                                        _iRowId = Convert.ToInt64(dt.Rows[0]["LAST_ROW_ID"].ToString());
                                        _iRefNo = Convert.ToInt64(dt.Rows[0]["RefNo"].ToString());

                                        //frmScanTray frmScanTray = new frmScanTray(iRowId, iRefNo);
                                        //if (txtLotNo.ReadOnly) { ScannerDisConnected(); }
                                        //frmScanTray.ShowDialog();
                                        //if (txtLotNo.ReadOnly) { ScannerConnected(); }
                                        ShowTrayScanning();
                                        //BindView();
                                        //FinalSave(frmScanTray.lblScannedBarcode.Text.Trim(), frmScanTray._isTrayClose);
                                    }
                                    catch
                                    {


                                    }
                                }
                            }
                            else
                            {
                                lblShowMessage(dt.Rows[0]["Result"].ToString(), 2);
                                //  PlayValidationSound();
                                // ShowAccessScreen();
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
                                if (GlobalVariable.mIsTrayEnable == true)
                                {

                                    _iRowId = 0; _iRefNo = 0;
                                    try
                                    {
                                        _iRowId = Convert.ToInt64(dt.Rows[0]["LAST_ROW_ID"].ToString());
                                        _iRefNo = Convert.ToInt64(dt.Rows[0]["RefNo"].ToString());
                                        //frmScanTray frmScanTray = new frmScanTray(iRowId, iRefNo);
                                        //if (txtLotNo.ReadOnly) { ScannerDisConnected(); }
                                        //frmScanTray.ShowDialog();
                                        //if (txtLotNo.ReadOnly) { ScannerConnected(); }

                                        ShowTrayScanning();

                                        //BindView();
                                        //FinalSave(lblScannedTrayBarcode.Text.Trim(), _isTrayClose);

                                    }
                                    catch
                                    {


                                    }
                                }
                            }
                            else
                            {

                                if (dt.Rows[0]["Result"].ToString().ToLower().Contains("already exists"))
                                {
                                    lblShowMessage(dt.Rows[0]["Result"].ToString(), 2);
                                    if (GlobalVariable.mIsTrayEnable == true)
                                    {
                                        //long iRowId = 0;
                                        //long iRefNo = 0;
                                        _iRowId = 0; _iRefNo = 0;
                                        try
                                        {
                                            _iRowId = Convert.ToInt64(dt.Rows[0]["LAST_ROW_ID"].ToString());
                                            _iRefNo = Convert.ToInt64(dt.Rows[0]["RefNo"].ToString());

                                            //frmScanTray frmScanTray = new frmScanTray(iRowId, iRefNo);
                                            //if (txtLotNo.ReadOnly) { ScannerDisConnected(); }
                                            //frmScanTray.ShowDialog();
                                            //if (txtLotNo.ReadOnly) { ScannerConnected(); }
                                            ShowTrayScanning();
                                            //BindView();
                                            //FinalSave(frmScanTray.lblScannedBarcode.Text.Trim(), frmScanTray._isTrayClose);

                                        }
                                        catch
                                        {


                                        }
                                    }
                                }
                                else
                                {
                                    if (dt.Rows[0]["Result"].ToString().ToLower().Contains("all child parts used!!!"))
                                    {
                                        lblShowMessage(dt.Rows[0]["Result"].ToString(), 2);
                                    }
                                    else
                                    {
                                        if (GlobalVariable.mIsTrayEnable == true)
                                        {
                                            //long iRowId = 0;
                                            //long iRefNo = 0;
                                            _iRefNo = 0; _iRowId = 0;
                                            try
                                            {
                                                _iRowId = Convert.ToInt64(dt.Rows[0]["LAST_ROW_ID"].ToString());
                                                _iRefNo = Convert.ToInt64(dt.Rows[0]["RefNo"].ToString());

                                                //frmScanTray frmScanTray = new frmScanTray(iRowId, iRefNo);
                                                //if (txtLotNo.ReadOnly) { ScannerDisConnected(); }
                                                //frmScanTray.ShowDialog();
                                                //if (txtLotNo.ReadOnly) { ScannerConnected(); }
                                                ShowTrayScanning();
                                                //BindView();
                                                //FinalSave(frmScanTray.lblScannedBarcode.Text.Trim(), frmScanTray._isTrayClose);

                                            }
                                            catch
                                            {


                                            }
                                        }
                                    }
                                }

                                // PlayValidationSound();
                                // ShowAccessScreen();
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
                                // PlayValidationSound();
                                //ShowAccessScreen();
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
                    GlobalVariable.mIsLotBarcode = false;
                    GlobalVariable.mScannedBarcode = "";
                }
            }));
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
                    if (txtLotNo.Text.Trim().Length == 6)
                    {
                        BL_TRAY_SCANNING _blObjTray = new BL_TRAY_SCANNING();
                        PL_TRAY_SCANNING _plObjTray = new PL_TRAY_SCANNING();
                        _plObjTray.DbType = "CHK_TRAY";
                        _plObjTray.Barcode = txtLotNo.Text.Trim();
                        _plObjTray.LotNo = "";
                        _plObjTray.TrayBarcode = txtLotNo.Text.Trim();

                        DataTable dt = _blObjTray.BL_ExecuteTask(_plObjTray);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["Result"].Equals("TRAY IS FREE"))
                            {
                                GlobalVariable.MesseageInfo(lblMessage, "Please scan Lot card First!!!", 2);
                                this.txtLotNo.SelectAll();
                                this.txtLotNo.Focus();
                                //PlayValidationSound();
                                //ShowAccessScreen();
                                return;
                            }
                            else
                            {
                                GlobalVariable.MesseageInfo(lblMessage, $"{dt.Rows[0]["Result"].ToString()}", 2);
                                this.txtLotNo.SelectAll();
                                this.txtLotNo.Focus();
                                //PlayValidationSound();
                                //ShowAccessScreen();
                                return;
                            }
                        }


                    }
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
                    txtLotNo.Text = txtLotNo.Text.Replace(",", "|");
                    if (txtLotNo.Text.Contains("|"))
                    {

                        string lotNoBarcode = txtLotNo.Text.Trim();
                        if (!GlobalVariable.mdicChildPart.ContainsValue(lotNoBarcode.Split('|')[0].ToString()))
                        {
                            GlobalVariable.MesseageInfo(lblMessage, "Invalid Lot card against model no.!!!", 2);
                            this.txtLotNo.SelectAll();
                            this.txtLotNo.Focus();
                            //PlayValidationSound();
                            ////ShowAccessScreen();
                            return;
                        }
                        else
                        {
                            GlobalVariable.mChildPart = GlobalVariable.mdicChildPart.FirstOrDefault(x => x.Value == lotNoBarcode.Split('|')[0].ToString()).Value;
                            GlobalVariable.mChildPartName = GlobalVariable.mdicChildPart.FirstOrDefault(x => x.Value == lotNoBarcode.Split('|')[0].ToString()).Key;

                            txtPartName.Text = GlobalVariable.mChildPartName;
                            txtPartNo.Text = GlobalVariable.mChildPart;
                            Common common = new Common();
                            txtShift.Text = GlobalVariable.mShift = common.GetShift();
                            BindView();
                            //GetTMAndTLLastData();
                            GetShiftWiseTotalQty();
                        }
                        lblBarcode.Text = lotNoBarcode;
                        lblLastScannedLotBarcode.Visible = true;
                        lblLastScannedLotBarcode.Text = "Last Scan Lot card If Any * :" + lotNoBarcode;

                        txtLotQty.Text = lotNoBarcode.Split('|')[1].ToString();
                        lblVendorCode.Text = lotNoBarcode.Split('|')[2].ToString();
                        txtLotNo.Text = lotNoBarcode.Split('|')[3].ToString();
                        txtSerialNo.Text = lotNoBarcode.Split('|')[4].ToString();

                        FinalSave();
                    }
                    else
                    {
                        lblLastScannedLotBarcode.Visible = false;
                        lblLastScannedLotBarcode.Text = "Last Scan Lot card If Any * :";
                        txtLot2.Enabled = true;
                        txtLot2.Focus();
                    }





                }
                catch (Exception ex)
                {

                    lblShowMessage(ex.Message, 2);
                }
                finally
                {
                    txtLotNo.SelectAll();
                    txtLotNo.Focus();
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
                lblBarcode.Text = "";
                if (GlobalVariable.mWashingQtyAlert)
                {
                    //txtSerialNo.Text = "";
                    txtSerialNo.Focus();
                }
                else
                {
                    FinalSave();
                }
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
                txtSerialNo.Text = dgv.Rows[e.RowIndex].Cells["SerialNo"].Value.ToString();
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
                Task.Run(() => { BindView(); GetTMAndTLLastData(); });
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
                Task.Run(() => { BindView(); GetTMAndTLLastData(); });
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
                    txtSerialNo.Enabled = true;
                    txtSerialNo.Focus();

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
                    if (dgv.RowCount <= 0)
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

        private void txtLotNo_TextChanged(object sender, EventArgs e)
        {
            //if (HasSpecialChars(txtLotNo.Text.Trim()))
            //{
            //    txtLotNo.MaxLength = 32767;
            //    txtLotQty.MaxLength = 32767;
            //}
            //else
            //{
            //    GetLotAndQtyLengthData();
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {

            }));
        }
        private volatile bool _keepReading = true;
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (_isClosing) return;
            try
            {
                string rawData = SerialPortManager.Port.ReadExisting();
                string cleanData = rawData.Split('\r')[0].Replace(",", "|").Trim();
                string PLCdata = cleanData;
                if (PLCdata == "") { return; }
                if (PLCdata.Length == 6 && pnlScantray.Visible) //Tray Scanning Operation
                {
                    TrayScanning(PLCdata);
                }
                else                    //Lot Scanning Operation
                {
                    LotCardScanning(PLCdata);
                }
                SerialPortManager.Port.DiscardInBuffer();

            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    GlobalVariable.MesseageInfo(lblMessage, ex.Message, 2);
                });
            }

        }



        private void btnAutoManual_Click(object sender, EventArgs e)
        {
            try
            {
                if (GlobalVariable.mAccessUser == "")
                    ShowAccessScreen();
                if (GlobalVariable.mAccessUser != "")
                {
                    if ((sender as PictureBox).Name == "btnAutoManual")
                        btnTrayAuto_Click(sender, e);
                    txtLotNo.Text = txtLot2.Text = txtSerialNo.Text = "";
                    btnAuto.BackColor = Color.Yellow;
                    btnManual.BackColor = Color.Transparent;
                    txtLotNo.ReadOnly = txtLot2.ReadOnly = txtSerialNo.ReadOnly = true;
                    txtLotNo.Focus();

                    ScannerConnected();






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

                if (GlobalVariable.mAccessUser == "")
                    ShowAccessScreen();
                if (GlobalVariable.mAccessUser != "")
                {
                    if ((sender as PictureBox).Name == "btnManual")
                        btnTrayManual_Click(sender, e);
                    txtLotNo.Text = txtLot2.Text = txtSerialNo.Text = "";
                    btnAuto.BackColor = Color.Transparent;
                    btnManual.BackColor = Color.Yellow;
                    txtLotNo.ReadOnly = txtLot2.ReadOnly = txtSerialNo.ReadOnly = false;
                    txtLotNo.Focus();

                    DisConnectScanner();





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

        private void txtSerialNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (GlobalVariable.mWashingQtyAlert)
                {
                    FinalSave();
                }
                else
                {

                    txtLotQty.Enabled = true;
                    txtLotQty.Focus();
                }
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GlobalVariable.mIsTrayEnable == true)
            {
                if (e.ColumnIndex == dgv.Columns["btnViewTrays"].Index)
                {
                    try
                    {

                        _iRowId = Convert.ToInt64(dgv.Rows[e.RowIndex].Cells["RowId"].Value.ToString());
                        _iRefNo = Convert.ToInt64(dgv.Rows[e.RowIndex].Cells["RefNo"].Value.ToString());

                        //frmScanTray frm = new frmScanTray(_iRowId, _iRefNo);
                        //if (txtLotNo.ReadOnly) { ScannerDisConnected(); }
                        //frm.ShowDialog();
                        //if (txtLotNo.ReadOnly) { ScannerConnected(); }
                        //BindView();
                        ShowTrayScanning();
                        //FinalSave(frm.lblScannedBarcode.Text.Trim(), frm._isTrayClose);
                        //txtLotNo.SelectAll();
                        //txtLotNo.Focus();
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

        private void frmLotEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isClosing = true;
            DisConnectScanner();
        }
        #region Tray Scanning Private Method
        void ShowTrayAccessScreen()
        {
            frmAccessPassword oFrmLogin = new frmAccessPassword();
            oFrmLogin.ShowDialog();
            if (GlobalVariable.mAccessUser != "" && oFrmLogin.IsCancel == true)
            {
                // lblShowMessage();
            }
        }
        void lblShowTrayMessage(string msg = "", int ictr = -1)
        {
            if (ictr == 1)
            {
                lblTrayMessage.BackColor = Color.DarkGreen;
                lblTrayMessage.Text = msg;
            }
            else if (ictr == 2)
            {
                lblTrayMessage.BackColor = Color.Red;
                lblTrayMessage.Text = msg;

            }
            else
            {
                lblTrayMessage.BackColor = Color.Transparent;
                lblTrayMessage.Text = msg;
            }
        }




        private void btnTrayClose_Click(object sender, EventArgs e)
        {
            GlobalVariable.mIsDelete = false;
            lblScannedTrayBarcode.Text = "";
            this._isTrayClose = true;
            HideTrayScanning();
        }

        private void ScannerTrayDisConnected()
        {
            try
            {
                //if (serialPort1.IsOpen)
                //{
                //    serialPort1.DataReceived -= serialPort1_DataReceived;
                //    // Give time for any pending DataReceived event to complete
                //    Thread.Sleep(100); // small delay (optional but helps)

                //    // Discard any remaining buffers to prevent blocking
                //    serialPort1.DiscardInBuffer();
                //    serialPort1.DiscardOutBuffer();
                //    if (serialPort1 != null && serialPort1.IsOpen)
                //    {
                //        serialPort1.DataReceived -= serialPort1_DataReceived; // Unsubscribe
                //        serialPort1.Close();
                //        serialPort1.Dispose();
                //        Thread.Sleep(200); // Allow time to release port
                //        GC.Collect();
                //        GC.WaitForPendingFinalizers();
                //    }

                //    lblScanStatus.Text = "Scanner Dis-Connected";
                //    lblScanStatus.BackColor = Color.Red;
                //}
                SerialPortManager.DetachHandler(serialPort1_DataReceived);
                SerialPortManager.Close();

                lblScanStatus.Text = "Scanner Dis-Connected";
                lblScanStatus.BackColor = Color.Red;

            }
            catch (Exception ex)
            {
                lblShowTrayMessage(ex.Message, 2);
            }
        }
        private void ScannerTrayConnected()
        {
            try
            {
                // if (!serialPort1.IsOpen)
                //{
                //    serialPort1.PortName = GlobalVariable.mKitScannerPort;
                //    serialPort1.DataReceived += serialPort1_DataReceived;
                //    serialPort1.Open();
                //    lblScanStatus.Text = "Scanner Connected";
                //    lblScanStatus.BackColor = Color.Green;
                //    GC.Collect();
                //    GC.WaitForPendingFinalizers();
                //}
                //else
                //{
                //    lblScanStatus.Text = "Scanner Dis-Connected";
                //    lblScanStatus.BackColor = Color.Red;
                //}

                try
                {
                    SerialPortManager.AttachHandler(serialPort1_DataReceived);
                    SerialPortManager.Open();

                    lblScanStatus.Text = "Scanner Connected";
                    lblScanStatus.BackColor = Color.Green;
                }
                catch (Exception ex)
                {
                    lblScanStatus.Text = "Scanner Dis-Connected";
                    lblScanStatus.BackColor = Color.Red;
                    lblShowTrayMessage("Error: " + ex.Message, 2);
                }


            }
            catch (Exception ex)
            {
                lblShowTrayMessage(ex.Message, 2);
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
                DataTable dt = _blTrayObj.BL_ExecuteTask(_plObj);
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
                        _iTrayScan = dgvTray.RowCount;
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

                lblShowTrayMessage(ex.Message, 2);
            }

        }
        void BindTrayView()
        {
            try
            {
                for (int i = dgvTray.Rows.Count - 1; i >= 0; i--)
                {
                    dgvTray.Rows.RemoveAt(i);
                }

                PL_TRAY_SCANNING _plObj = new PL_TRAY_SCANNING();
                _plObj.DbType = "BIND_VIEW";
                _plObj.RowId = _iRowId;
                _plObj.RefNo = _iRefNo.ToString();
                DataTable dt = _blTrayObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    dgvTray.DataSource = dt.DefaultView;


                }




            }
            catch (Exception ex)
            {

                lblShowTrayMessage(ex.Message, 2);
            }

        }
        void DeleteJunkTryas()
        {
            try
            {


                PL_TRAY_SCANNING _plObj = new PL_TRAY_SCANNING();
                _plObj.DbType = "DELETE_JUNK_TRAYS";
                DataTable dt = _blTrayObj.BL_ExecuteTask(_plObj);

            }
            catch (Exception ex)
            {

                lblShowTrayMessage(ex.Message, 2);
            }

        }
        private void frmScanTray_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                //btnTrayAuto.BackColor = Color.Yellow;
                //btnTrayManual.BackColor = Color.Transparent;

                lblModelNo.Text = lblChildPartNo.Text = lblTotalQty.Text = lblScanQty.Text = lblTrayScanTotalQty.Text = "XXXXXXXXXXXXX";
                txtScanTray.Text = "";
                BindTrayView();
                BindLabelData();
                DeleteJunkTryas();
                lblShowTrayMessage("Please Scan Tray!!!", 1);
                //ScannerTrayConnected();
                txtScanTray.Focus();
            }
            catch (Exception ex)
            {

                lblShowTrayMessage(ex.Message, 2);
            }
        }

        private void lblTrayMessage_Click(object sender, EventArgs e)
        {

        }


        private void btnTrayUnmapped_Click(object sender, EventArgs e)
        {
            try
            {
                ShowTrayAccessScreen();
                if (GlobalVariable.mAccessUser == "")
                {
                    goto SameForm;
                }
                string strTray = "";
                GlobalVariable.mAccessUser = "";
                //Atleast one Module right
                bool IsChecked = false;


                foreach (DataGridViewRow row in dgvTray.Rows)
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
                foreach (DataGridViewRow row in dgvTray.Rows)
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
                        dt = _blTrayObj.BL_ExecuteTask(_plObj);
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["RESULT"].Equals("Y"))
                    {
                        lblShowTrayMessage($" Trays Unmapped Successfully!!!!", 1);
                        BindTrayView();
                        BindLabelData();
                        txtScanTray.Text = "";
                    }
                    else
                    {
                        lblShowTrayMessage($" {dt.Rows[0]["RESULT"].ToString()}", 2);
                        txtScanTray.Text = "";
                    }
                }

            }
            catch (Exception ex)
            {

                lblShowTrayMessage(ex.Message, 2);
            }
        SameForm:
            this.Focus();
        }
        private void FinalTraySave()
        {
            this.BeginInvoke(new Action(() =>
            {
                try
                {
                    lblScannedTrayBarcode.Text = txtScanTray.Text.Trim();
                    if (_iTotalTrays == _iTrayScan)
                    {
                        lblShowTrayMessage("Please scan Lot card First!!!", 2);
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
                    DataTable dt = _blTrayObj.BL_ExecuteTask(_plObj);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["RESULT"].Equals("Y"))
                        {
                            lblShowTrayMessage($" Tray {txtScanTray.Text.Trim()} Scanned,Please Scan Next Tray!!!!", 1);
                            BindTrayView();
                            BindLabelData();
                            txtScanTray.Text = "";
                            //if (dgv.Rows.Count == 4)
                            if (dt.Rows[0]["TRY_COUNT"].ToString().Equals("4"))
                            {
                                btnTrayClose_Click(null, null);
                            }
                            if (_iTotalTrays == _iTrayScan)
                            {
                                lblShowTrayMessage("This Lot card all child parts used,Scan new Lot card", 1);
                                goto SameForm;
                            }
                        }
                        else
                        {
                            lblShowTrayMessage($" {dt.Rows[0]["RESULT"].ToString()}", 2);
                            txtScanTray.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {


                    lblShowTrayMessage(ex.Message, 2);
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
                        lblScannedTrayBarcode.Text = txtScanTray.Text.Trim();
                        GlobalVariable.mScannedBarcode = txtScanTray.Text.Trim();
                        GlobalVariable.mIsLotBarcode = true;
                        HideTrayScanning();
                       
                    }

                    if (txtScanTray.Text.Trim().Length == 6 && pnlScantray.Visible) //Tray Scanning Operation
                    {
                        TrayScanning(txtScanTray.Text.Trim());
                    }
                    else                    //Lot Scanning Operation
                    {
                        LotCardScanning(txtScanTray.Text.Trim());
                    }


                }
                catch (Exception ex)
                {

                    lblShowTrayMessage(ex.Message, 2);
                }

            }
        }

        private void dgvTray_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTray_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvTray.Columns["chkSelect"].Index && e.RowIndex >= 0)
                {
                    object value = dgvTray.Rows[e.RowIndex].Cells["chkSelect"].Value;

                    if (value == null || value == DBNull.Value) // Handle null values
                    {
                        dgvTray.Rows[e.RowIndex].Cells["chkSelect"].Value = true; // Set to true if null
                    }
                    else
                    {
                        bool currentValue = Convert.ToBoolean(value);
                        dgvTray.Rows[e.RowIndex].Cells["chkSelect"].Value = !currentValue;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

        }



        private void frmScanTray_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }

        private void frmScanTray_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isTrayClosing = true;
            //ScannerTrayDisConnected();
        }
        private volatile bool _keepTrayReading = true;
        private void serialTrayPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (_isTrayClosing) return;
            try
            {


                // string PLCdata = serialPort1.ReadExisting();
                string PLCdata = SerialPortManager.Port.ReadExisting();

            }
            catch (Exception ex)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    GlobalVariable.MesseageInfo(lblTrayMessage, ex.Message, 2);
                });
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmScanTray_Shown(object sender, EventArgs e)
        {

        }

        private void btnTrayAuto_Click(object sender, EventArgs e)
        {
            try
            {
                if (GlobalVariable.mAccessUser == "")
                    ShowTrayAccessScreen();
                if (GlobalVariable.mAccessUser != "")
                {
                    if ((sender as PictureBox).Name == "btnTrayAuto")
                        btnAutoManual_Click(sender, e);

                    btnTrayAuto.BackColor = Color.Yellow;
                    btnTrayManual.BackColor = Color.Transparent;
                    txtScanTray.ReadOnly = true;
                    txtScanTray.Focus();
                    //if (!serialPort1.IsOpen)
                    //{
                    //    ScannerConnected();
                    //}

                    ScannerConnected();



                    GlobalVariable.mAccessUser = "";

                }
            }
            catch (Exception ex)
            {

                this.Invoke((MethodInvoker)delegate
                {
                    GlobalVariable.MesseageInfo(lblTrayMessage, ex.Message, 2);
                });
            }
        }

        private void btnTrayManual_Click(object sender, EventArgs e)
        {
            try
            {

                if (GlobalVariable.mAccessUser == "")
                    ShowTrayAccessScreen();
                if (GlobalVariable.mAccessUser != "")
                {
                    if ((sender as PictureBox).Name == "btnTrayManual")
                        btnManual_Click(sender, e);

                    txtScanTray.Text = "";
                    btnTrayAuto.BackColor = Color.Transparent;
                    btnTrayManual.BackColor = Color.Yellow;
                    txtScanTray.ReadOnly = false;
                    txtScanTray.Focus();
                    //if (serialPort1.IsOpen)
                    //{
                    //    ScannerDisConnected();
                    //}
                    ScannerDisConnected();

                    GlobalVariable.mAccessUser = "";

                }
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    GlobalVariable.MesseageInfo(lblTrayMessage, ex.Message, 2);
                });

            }
        }
        #endregion

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }

        private void pnlScantray_VisibleChanged(object sender, EventArgs e)
        {
            //if (pnlScantray.Visible == false)
            //{
            //    if (SerialPortManager.Port.IsOpen == false)
            //    {
            //        try
            //        {
            //            SerialPortManager.AttachHandler(serialPort1_DataReceived);
            //            SerialPortManager.Open();

            //            lblScanStatus.Text = lblTrayScanStatus.Text = "Scanner Connected";
            //            lblScanStatus.BackColor = lblTrayScanStatus.BackColor = Color.Green;
            //        }
            //        catch (Exception ex)
            //        {
            //            lblScanStatus.Text = lblTrayScanStatus.Text = "Scanner Dis-Connected";
            //            lblScanStatus.BackColor = lblTrayScanStatus.BackColor = Color.Red;
            //            lblShowMessage("Error: " + ex.Message, 2);
            //            lblShowTrayMessage("Error: " + ex.Message, 2);
            //        }
            //    }
            //}
            if (pnlScantray.Visible && btnTrayManual.BackColor == Color.Yellow)
            {
                txtScanTray.TabStop = true;
                txtScanTray.TabIndex = 0;
                txtScanTray.ReadOnly = false;
                txtScanTray.Focus();
            }
        }

        private void pnlScantray_Enter(object sender, EventArgs e)
        {
            txtScanTray.Focus();
        }
    }
}
