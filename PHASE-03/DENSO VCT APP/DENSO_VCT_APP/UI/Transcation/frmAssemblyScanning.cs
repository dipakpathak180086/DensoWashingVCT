
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DENSO_VCT_BL;
using DENSO_VCT_COMMON;
using DENSO_VCT_PL;
using Serilog;

namespace DENSO_VCT_APP
{
    public partial class frmAssemblyScanning : Form
    {
        //public bool PLCStatus { get { return lblPLCStatus.BackColor.Name.Equals("Green"); } set { lblPLCStatus.BackColor = value == false ? Color.Red : Color.Green; lblPLCStatus.Refresh(); } }
        public bool ScannerStatus { get { return lblScannerStatus.BackColor.Name.Equals("Green"); } set { lblScannerStatus.BackColor = value == false ? Color.Red : Color.Green; lblScannerStatus.Refresh(); } }

        #region Variables
        MyTcpClient _tcpClient = null;
        bool _IsTcpComplete = true;
        bool IsWaitingForTCP = false;
        private int iScanCount = 0;
        private int iPrintCount = 0;
        private BL_TRAY_ASSY _blObj = null;
        private PL_TRAY_ASSY _plObj = null;
        private Common _comObj = null;
        private string _packType = string.Empty;
        private DataTable dtBindGrid = new DataTable();
        clsTCPClient printer;
        clsTCPClient Scanner;
        private bool localPLCStatus = false;
        private bool localScannerStatus = false;
        string iPrintQty = "";
        DataTable dt;
        #endregion

        #region Form Methods

        public frmAssemblyScanning()
        {
            try
            {
                InitializeComponent();
                _blObj = new BL_TRAY_ASSY();
                _plObj = new PL_TRAY_ASSY();
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void frmReprinting_Load(object sender, EventArgs e)
        {
            try
            {
                //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                //Scanner = new clsTCPClient(GlobalVariable.mScannerIP, GlobalVariable.mScannerPort);
                //tmrCaseVerify.Start();
                BindView();
                txtTrayNo.Focus();
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
            }
        }

        #endregion

        #region Button Event
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void OFrm_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.Show();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dre = MessageBox.Show("Are you sure want to back???", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dre == DialogResult.No)
                {
                    return;
                }
                this.Close();

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            GlobalVariable.ExportInCSV(dgv);
        }
        #endregion

        #region Methods
        private void ConnectToSocketClient()
        {
            try
            {
                //Start for the station 1 IR
                //now station 1 IR having 4 more tool will be added //modified by dipak 07-12-21
                /* dispose previous object if having any reference*/
                if (_tcpClient != null)
                {
                    _tcpClient.Dispose();
                    _tcpClient = null;
                }
                _tcpClient = new MyTcpClient(GlobalVariable.mPLCIP, GlobalVariable.mPLCPort);


            }
            catch (Exception ex) { Log.Error(ex, $"Exception Occured"); }
        }
        private async Task StartSocketClientAsync()
        {
            try
            {
                await Task.Run(() => ConnectToSocketClient());
                //Start timer for Check TcpClient connection for Server Type Controller
                timerTcpClient.Enabled = true;
            }
            catch (Exception ex) { Log.Error(ex, $"Exception Occured"); }
        }

        //public string connectionSerialPort()
        //{
        //    try
        //    {
        //        if (!serialPort1.IsOpen)
        //        {
        //            serialPort1.PortName = GlobalVariable.mCOMPort;
        //            serialPort1.Open();     // open port
        //            return "PLC Connected";
        //        }
        //        else
        //        {
        //            return "PLC Connected";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return "PLC Disconnected";
        //    }

        //}
        private DataTable PrintPartbarcode(string PartNo, string machineParam)
        {
            //_plObj = new PL_TRAY_ASSY();
            //_plObj.CreatedBy = GlobalVariable.mSatoAppsLoginUser;
            //_plObj.MasterialCode = PartNo;
            //_plObj.MachineParam = machineParam;
            //if (machineParam.StartsWith("OK") || machineParam.StartsWith("1"))
            //{
            //    _plObj.MachineStatus = "OK";
            //}
            //else
            //{
            //    _plObj.MachineStatus = "NG";
            //}
            //_plObj.DbType = "PRINTING";
            DataTable dataTable = _blObj.BL_ExecuteTask(_plObj);
            return dataTable;
        }
        private DataTable VerifyPartbarcode(string PartBarcode, string PartNo)
        {
            _plObj = new PL_TRAY_ASSY();
            _plObj.CreatedBy = GlobalVariable.mSatoAppsLoginUser;
            //_plObj.MasterialCode = PartNo;
            //_plObj.Barcode = PartBarcode;
            _plObj.DbType = "SCANNING";
            DataTable dataTable = _blObj.BL_ExecuteTask(_plObj);
            return dataTable;
        }
        private void BarcodePrint(PL_TRAY_ASSY plObj)
        {
            //SatoPrinter objSatoPrinter = new SatoPrinter();
            //objSatoPrinter.PrintPartBarcode(plObj);
        }




        private void Clear()
        {
            try
            {


                iScanCount = iPrintCount = 0;
                for (int i = dgv.Rows.Count - 1; i >= 0; i--)
                {
                    dgv.Rows.RemoveAt(i);
                }

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        #endregion

        #region Label Event

        #endregion

        #region DataGridView Events


        #endregion

        #region TextBox Event

        private void txtEnterQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            GlobalVariable.allowOnlyNumeric(sender, e);
        }


        #endregion




        private void CheckPLCState()
        {
            if (localPLCStatus == false)
            {
                if (Scanner.CheckPLCAndScannerPinging(GlobalVariable.mPLCIP)) { localPLCStatus = true; }
                else
                {
                    localPLCStatus = false;
                }
            }
        }

        private void CheckScannerState()
        {
            if (localScannerStatus == false)
            {
                if (Scanner.CheckPLCAndScannerPinging(GlobalVariable.mScannerIP)) { localScannerStatus = true; }
                else
                {
                    localScannerStatus = false;
                }
            }
        }
        private void timerAllHardware_Tick(object sender, EventArgs e)
        {
            Task.Run(() => CheckPLCState());
            Task.Run(() => CheckScannerState());
            if (localScannerStatus)
            { ScannerStatus = true; }
            else
            { ScannerStatus = false; }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void tmrCaseVerify_Tick(object sender, EventArgs e)
        {
            try
            {
                tmrCaseVerify.Stop();
                // Program.Log("Reading Scanner data.");
                string ScannedCaseNo = await Scanner.GetScannerData();
                //Program.Log(string.Format("Get {0} from Scanner.", ScannedCaseNo));
                tmrCaseVerify.Start();
                if (ScannedCaseNo != "Scanner not connected.")
                {
                    if (!ScannerStatus)
                    {
                        ScannerStatus = true;
                        //ShowMessage("Scanner Connected.", Color.Maroon, true);
                        //Program.Log("Scanner Connected.");
                    }
                }
                if (ScannedCaseNo != "")
                {
                    GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Scanner Data", ScannedCaseNo.Trim('\r').ToUpper());
                    if (ScannedCaseNo.ToUpper() == "NRD" || ScannedCaseNo.ToUpper() == "NOREADE" || ScannedCaseNo.Trim('\r').ToUpper() == "ERROR")
                    {
                        ScannedCaseNo = "NRD";
                    }

                    if (ScannedCaseNo != "NRD")
                    {
                        //_plObj = new PL_TRAY_ASSY();
                        //_plObj.DbType = "SCANNING";
                        //_plObj.Barcode = ScannedCaseNo.Trim('\r');
                        //_plObj.CreatedBy = GlobalVariable.UserName;
                        DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                        if (dt.Rows.Count > 0)
                        {
                            lblMsg.BackColor = Color.Ivory;
                            lblMsg.ForeColor = Color.Black;
                            //lblScannedDataMsg.Text = dt.Rows[0]["RESULT"].ToString();
                            if (dt.Rows[0]["RESULT"].ToString() == "Y")
                            {
                                lblMsg.BackColor = Color.Green;
                                lblMsg.ForeColor = Color.White;
                                lblMsg.Text = "THIS BARCODE (" + ScannedCaseNo + ") SUCCESSFULLY VERIFIED!!!";
                                dgv.Rows.Add(new string[] { ScannedCaseNo });
                                iScanCount = iScanCount + 1;
                            }
                            else
                            {
                                lblMsg.BackColor = Color.Red;
                                lblMsg.ForeColor = Color.White;
                                lblMsg.Text = dt.Rows[0]["RESULT"].ToString();
                            }
                        }
                        GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Acutal Scanner Data", ScannedCaseNo.Trim('\r').ToUpper());
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frmBarcodePrinting_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Program.Log("Application closed.");

            Process.GetCurrentProcess().Kill();
            try
            {
                if (GlobalVariable.mCaseTcpClient != null)
                {
                    GlobalVariable.mCaseTcpClient.Close();
                    tmrCaseVerify.Stop();
                }
                timerTcpClient.Enabled = false;
                //if (Program.mCaseRejectTcpClient != null)
                //{
                //    Program.mCaseRejectTcpClient.Close();
                //}
                //if (Program.mPLCTcpClient != null)
                //{
                //    Program.mPLCTcpClient.Close();
                //}
                GC.Collect();
            }
            catch (Exception)
            {
            }
            finally
            {
                GlobalVariable.mCaseTcpClient = null;
                GlobalVariable.mPLCTcpClient = null;
                // Program.mPLCTcpClient = null;
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {

                if (lblScannerStatus.BackColor == Color.Red)
                {
                    GlobalVariable.MesseageInfo(lblMsg, "Scanner Not Connected!!!", 2);
                    return;
                }
                StartSocketClientAsync();
                timerTcpClient.Enabled = true;
                btnStart.Enabled = false;
            }
            catch (Exception)
            {

                throw;
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
                    _blObj = new BL_TRAY_ASSY();
                    _plObj = new PL_TRAY_ASSY();
                    _plObj.DbType = "BIND_VIEW";
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
                    
                }
                dgv.ResumeLayout(true);
            }
            ));
        }
        private void GetPlcInputData()
        {
            try
            {
                // bool IsConnected = _tcpClient.GetServerStatus();
                //SetStation1UpDown(IsConnected);
                if (_IsTcpComplete)
                {
                    _IsTcpComplete = false;
                    string data = _tcpClient.GetServerInput();
                    this.Invoke(new Action(() =>
                    {
                        //lblPLCChar.Text = data;
                    }));
                    GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Acutal Data From PLC", $"PLC Input data received {data}");
                    if (data != "")
                    {
                        GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Acutal Data From PLC", $"PLC Input data received {data}");
                        if (data.Contains(","))
                        {
                            string[] sArrData = data.Split(',');
                            this.Invoke(new Action(() =>
                            {
                                //store the data in class object


                                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Acutal Data From PLC", data.Trim('\r').ToUpper());
                                DataTable dt = new DataTable();

                                if (data.Trim().Replace("\0", string.Empty).StartsWith("1") || data.Trim().Replace("\0", string.Empty).StartsWith("OK"))
                                {
                                    GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Acutal OK Data From PLC", data.Trim().Replace("\0", string.Empty));
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        if (txtTrayNo.Text.Length > 0)
                                        {
                                            // dt = PrintPartbarcode(cmbPartNo.Text.ToString().Trim(), data.Trim().Replace("\0", string.Empty));
                                            if (dt.Rows[0]["RESULT"].ToString() == "Y")
                                            {
                                                //_plObj = new PL_TRAY_ASSY();
                                                ////_plObj.MasterialCode = cmbPartNo.Text.Trim();
                                                //_plObj.Barcode = dt.Rows[0]["BARCODE"].ToString();
                                                //BarcodePrint(_plObj);
                                                ////GlobalVariable.MesseageInfo(lblPrintMessage, $"Print Successfully ({ dt.Rows[0]["BARCODE"].ToString()})", 1);
                                                //iPrintCount = iPrintCount + 1;
                                                // lblPrintCount.Text = iPrintCount.ToString();
                                            }
                                            else
                                            {

                                                //GlobalVariable.MesseageInfo(lblPrintMessage, dt.Rows[0]["Msg"].ToString(), 2);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            // GlobalVariable.MesseageInfo(lblPrintMessage, "Please select Part No.", 2);
                                            return;
                                        }
                                    });
                                }
                                else
                                {
                                    // dt = PrintPartbarcode(cmbPartNo.SelectedItem.ToString().Trim(), data.Trim().Replace("\0", string.Empty));
                                    if (dt.Rows[0]["RESULT"].ToString() == "Y")
                                    {
                                        // GlobalVariable.MesseageInfo(lblPrintMessage, $"NG Status Found!!! ({ dt.Rows[0]["BARCODE"].ToString()})", 1);

                                    }
                                    else
                                    {

                                        // GlobalVariable.MesseageInfo(lblPrintMessage, dt.Rows[0]["BARCODE"].ToString(), 2);

                                    }
                                    GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Acutal NG Data From PLC", data.Trim().Replace("\0", string.Empty));
                                }
                            }));
                        }
                        else
                        {
                            GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtMessage, "Acutal NG Data From PLC", data.Trim().Replace("\0", string.Empty));
                            Log.Warning($"PLC Input - data format is not valid");
                        }
                        _IsTcpComplete = true;
                    }


                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception Occured");
                _IsTcpComplete = true;
            }
            finally
            {
                _IsTcpComplete = true;
            }
        }
        private void timerTcpClient_Tick(object sender, EventArgs e)
        {
            if (!IsWaitingForTCP)
            {
                IsWaitingForTCP = true;
                if (_IsTcpComplete == true)
                    Task.Run(() => GetPlcInputData());
                IsWaitingForTCP = false;
            }
        }

        private void txtTrayNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    GlobalVariable.MesseageInfo(lblMsg, $"", 3);
                    _plObj = new PL_TRAY_ASSY();
                    _plObj.DbType = "SCAN_TRAY";
                    _plObj.TrayBarcode = txtTrayNo.Text.Trim('\r');
                    _plObj.CreatedBy = GlobalVariable.UserName;
                    DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "Y")
                        {
                            GlobalVariable.MesseageInfo(lblMsg, $"Tray {txtTrayNo.Text.Trim() } Scanned Successfully!!!", 1);
                            BindView();
                            txtTrayNo.Text = "";
                        }
                        else if (dt.Rows[0][0].ToString() == "N")
                        {
                            BindView();
                            txtTrayNo.Text = "";
                        }
                        else
                        {
                            GlobalVariable.MesseageInfo(lblMsg, $"{dt.Rows[0][0].ToString()}", 2);
                            txtTrayNo.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalVariable.MesseageInfo(lblMsg, $"Tray {txtTrayNo.Text.Trim() } Scanned Successfully!!!", 1);
               
            }
        }

        private void gbPrintingParameter_Enter(object sender, EventArgs e)
        {

        }
    }
}
