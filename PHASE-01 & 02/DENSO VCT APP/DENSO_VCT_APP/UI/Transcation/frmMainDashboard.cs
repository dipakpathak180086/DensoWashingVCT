using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DENSO_VCT_PL;
using DENSO_VCT_BL;
using DENSO_VCT_COMMON;
using Serilog;
using System.Net.NetworkInformation;
using System.Threading;
using System.IO;

namespace DENSO_VCT_APP
{
    public partial class frmMainDashboard : Form
    {
        #region Private Variables
        private BL_LINE_ASSY_DASH _blObj = null;
        private PL_LINE_ASSY_DASH _plObj = null;
        private BL_ASYY_LOG_MSG _blObjLog = null;
        private PL_ASYY_LOG_MSG _plObjLog = null;
        private BL_LINE_ASSY _blObjAssy = null;
        private PL_LINE_ASSY _plObjAssy = null;
        clsPLC_Update _tcpClientScanner1 = null, _tcpClientScanner2 = null, _tcpClientScanner3 = null;
        bool _IsScanner1Complete = true, _IsScanner2Complete = true, _IsScanner3Complete = true;
        bool IsWaitingForTCP = false; /* if timer is already waiting for previous  call */
        bool _IsDashboardComplete = true; // this flag will be used to get the dashboard data from the database
        bool IsPingComplete = true;
        private int SCANNER_1_TRIGGER_TIME = 0;
        private int SCANNER_2_TRIGGER_TIME = 0;
        private int SCANNER_3_TRIGGER_TIME = 0;
        private int elapsedTime = 0;
        private int RESET_TIME = 0;
        #endregion
        public frmMainDashboard()
        {
            InitializeComponent();
            _blObj = new BL_LINE_ASSY_DASH();
            _blObjAssy = new BL_LINE_ASSY();
            _blObjLog = new BL_ASYY_LOG_MSG();
        }


        #region Private Methods


        private void OFrm_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.Show();
        }
        void CollapseThirdPanel()
        {
            splitContainer2.Panel2Collapsed = true; // Hide the third panel

            int totalWidth = splitContainer1.Width; // Get total available width
            int newWidth = totalWidth / 2; // Divide equally between first and second panels

            splitContainer1.SplitterDistance = newWidth; // Adjust first panel width

        }

        private void timerTcpClient_Tick(object sender, EventArgs e)
        {
            if (!IsWaitingForTCP)
            {
                IsWaitingForTCP = true;
                if (_IsScanner1Complete == true)
                    Task.Run(() => GetScanner1InputData());
                if (_IsScanner2Complete == true)
                    Task.Run(() => GetScanner2InputData());
                if (_IsScanner3Complete == true)
                    Task.Run(() => GetScanner3InputData());
                IsWaitingForTCP = false;
            }
        }

        private void timerPing_Tick(object sender, EventArgs e)
        {
            if (IsPingComplete) // this flag will be in the below function complete process call
            {
                IsPingComplete = false;

                Task.Run(() => CheckIPStatus());

            }
        }
        private void BindLabelConveyor1()
        {
            try
            {
                _plObjAssy = new PL_LINE_ASSY();
                _plObjAssy.DbType = "BIND_TRY_MODEL_LABEL_DATA";
                _plObjAssy.Conveyor = lblSC1Conveyor.Text.Trim();
                _plObjAssy.Line = GlobalVariable.mPCName;
                DataTable dtGetData = _blObjAssy.BL_ExecuteTask(_plObjAssy);
                if (dtGetData.Rows.Count > 0)
                {
                    lblSC1ModelNo.Text = dtGetData.Rows[0]["ModelNo"].ToString();
                    lblSC1ModelName.Text = dtGetData.Rows[0]["ModelName"].ToString();
                    lblSC1PartNo.Text = dtGetData.Rows[0]["ChildPartNo"].ToString();
                    lblSC1PartName.Text = dtGetData.Rows[0]["ChildPartName"].ToString();
                    lblSC1LotNo.Text = dtGetData.Rows[0]["LotNo"].ToString();
                    lblSC1CurrentTray.Text = dtGetData.Rows[0]["TrayBarcode"].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void BindLabelConveyor2()
        {
            try
            {
                _plObjAssy = new PL_LINE_ASSY();
                _plObjAssy.DbType = "BIND_TRY_MODEL_LABEL_DATA";
                _plObjAssy.Conveyor = lblSC2Conveyor.Text.Trim();
                _plObjAssy.Line = GlobalVariable.mPCName;
                DataTable dtGetData = _blObjAssy.BL_ExecuteTask(_plObjAssy);
                if (dtGetData.Rows.Count > 0)
                {
                    lblSC2ModelNo.Text = dtGetData.Rows[0]["ModelNo"].ToString();
                    lblSC2ModelName.Text = dtGetData.Rows[0]["ModelName"].ToString();
                    lblSC2PartNo.Text = dtGetData.Rows[0]["ChildPartNo"].ToString();
                    lblSC2PartName.Text = dtGetData.Rows[0]["ChildPartName"].ToString();
                    lblSC2LotNo.Text = dtGetData.Rows[0]["LotNo"].ToString();
                    lblSC2CurrentTray.Text = dtGetData.Rows[0]["TrayBarcode"].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void AssyLogStampScanner1(PL_LINE_ASSY plObj)
        {
            try
            {
                PL_ASYY_LOG_MSG plObjLog = new PL_ASYY_LOG_MSG();
                plObjLog.Line = GlobalVariable.mLineNo;
                plObjLog.PC = GlobalVariable.mPCName;
                plObjLog.Conveyor = plObj.Conveyor;
                plObjLog.ScannerIp = GlobalVariable.SC1ScannerIP;
                plObjLog.ScannerData = plObj.TrayBarcode;
                plObjLog.LogMsg = plObj.LogMSG;
                DataTable dtGetData = _blObjLog.BL_ExecuteTask(plObjLog);
                if (dtGetData.Rows.Count > 0)
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void AssyLogStampScanner2(PL_LINE_ASSY plObj)
        {
            try
            {
                PL_ASYY_LOG_MSG plObjLog = new PL_ASYY_LOG_MSG();
                plObjLog.Line = GlobalVariable.mLineNo;
                plObjLog.PC = GlobalVariable.mPCName;
                plObjLog.Conveyor = plObj.Conveyor;
                plObjLog.ScannerIp = GlobalVariable.SC2ScannerIP;
                plObjLog.ScannerData = plObj.TrayBarcode;
                plObjLog.LogMsg = plObj.LogMSG;
                DataTable dtGetData = _blObjLog.BL_ExecuteTask(plObjLog);
                if (dtGetData.Rows.Count > 0)
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void AssyLogStampScanner3(PL_LINE_ASSY plObj)
        {
            try
            {
                PL_ASYY_LOG_MSG plObjLog = new PL_ASYY_LOG_MSG();
                plObjLog.Line = GlobalVariable.mLineNo;
                plObjLog.PC = GlobalVariable.mPCName;
                plObjLog.Conveyor = plObj.Conveyor;
                plObjLog.ScannerIp = GlobalVariable.SC3ScannerIP;
                plObjLog.ScannerData = plObj.TrayBarcode;
                plObjLog.LogMsg = plObj.LogMSG;
                DataTable dtGetData = _blObjLog.BL_ExecuteTask(plObjLog);
                if (dtGetData.Rows.Count > 0)
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void BindLabelConveyor3()
        {
            try
            {
                _plObjAssy = new PL_LINE_ASSY();
                _plObjAssy.DbType = "BIND_TRY_MODEL_LABEL_DATA";
                _plObjAssy.Conveyor = lblSC3Conveyor.Text.Trim();
                _plObjAssy.Line = GlobalVariable.mPCName;
                DataTable dtGetData = _blObjAssy.BL_ExecuteTask(_plObjAssy);
                if (dtGetData.Rows.Count > 0)
                {
                    lblSC3ModelNo.Text = dtGetData.Rows[0]["ModelNo"].ToString();
                    lblSC3ModelName.Text = dtGetData.Rows[0]["ModelName"].ToString();
                    lblSC3PartNo.Text = dtGetData.Rows[0]["ChildPartNo"].ToString();
                    lblSC3PartName.Text = dtGetData.Rows[0]["ChildPartName"].ToString();
                    lblSC3LotNo.Text = dtGetData.Rows[0]["LotNo"].ToString();
                    lblSC3CurrentTray.Text = dtGetData.Rows[0]["TrayBarcode"].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void BindViewConveyor1()
        {
            try
            {
                _plObjAssy = new PL_LINE_ASSY();
                _plObjAssy.DbType = "BIND_VIEW";
                _plObjAssy.Conveyor = lblSC1Conveyor.Text.Trim();
                _plObjAssy.PcName = GlobalVariable.mPCName;
                DataTable dtBindView = _blObjAssy.BL_ExecuteTask(_plObjAssy);
                dgvSC1.DataSource = dtBindView.DefaultView;
                if (btnClose2.Visible == true)
                {
                    for (int i = 0; i < dgvSC1.ColumnCount; i++)
                    {
                        this.dgvSC1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        if (dgvSC1.ColumnCount - 1 == i)
                        {
                            this.dgvSC1.Columns[dgvSC1.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void BindViewConveyor2()
        {
            try
            {
                _plObjAssy = new PL_LINE_ASSY();
                _plObjAssy.DbType = "BIND_VIEW";
                _plObjAssy.Conveyor = lblSC2Conveyor.Text.Trim();
                _plObjAssy.PcName = GlobalVariable.mPCName;
                DataTable dtBindView = _blObjAssy.BL_ExecuteTask(_plObjAssy);
                dgvSC2.DataSource = dtBindView.DefaultView;
                if (btnClose2.Visible == true)
                {
                    for (int i = 0; i < dgvSC2.ColumnCount; i++)
                    {
                        this.dgvSC2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        if (dgvSC2.ColumnCount - 1 == i)
                        {
                            this.dgvSC2.Columns[dgvSC2.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void BindViewConveyor3()
        {
            try
            {
                _plObjAssy = new PL_LINE_ASSY();
                _plObjAssy.DbType = "BIND_VIEW";
                _plObjAssy.Conveyor = lblSC3Conveyor.Text.Trim();
                _plObjAssy.PcName = GlobalVariable.mPCName;
                DataTable dtBindView = _blObjAssy.BL_ExecuteTask(_plObjAssy);
                dgvSC3.DataSource = dtBindView.DefaultView;
                if (btnClose2.Visible == true)
                {
                    for (int i = 0; i < dgvSC3.ColumnCount; i++)
                    {
                        this.dgvSC3.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        if (dgvSC3.ColumnCount - 1 == i)
                        {
                            this.dgvSC3.Columns[dgvSC3.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BindViewConveyor1TriggerTime()
        {
            try
            {
                _plObjAssy = new PL_LINE_ASSY();
                _plObjAssy.DbType = "GET_TRIGGER_TIME";
                _plObjAssy.Conveyor = lblSC1Conveyor.Text.Trim();
                _plObjAssy.PcName = GlobalVariable.mPCName;
                DataTable dataTable = _blObjAssy.BL_ExecuteTask(_plObjAssy);
                if (dataTable.Rows.Count > 0)
                {
                    SCANNER_1_TRIGGER_TIME = Convert.ToInt32(dataTable.Rows[0]["ScannerTriggerTimeInSec"]);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void BindViewConveyor2TriggerTime()
        {
            try
            {
                _plObjAssy = new PL_LINE_ASSY();
                _plObjAssy.DbType = "GET_TRIGGER_TIME";
                _plObjAssy.Conveyor = lblSC2Conveyor.Text.Trim();
                _plObjAssy.PcName = GlobalVariable.mPCName;
                DataTable dataTable = _blObjAssy.BL_ExecuteTask(_plObjAssy);
                if (dataTable.Rows.Count > 0)
                {
                    SCANNER_2_TRIGGER_TIME = Convert.ToInt32(dataTable.Rows[0]["ScannerTriggerTimeInSec"]);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BindViewConveyor3TriggerTime()
        {
            try
            {
                _plObjAssy = new PL_LINE_ASSY();
                _plObjAssy.DbType = "GET_TRIGGER_TIME";
                _plObjAssy.Conveyor = lblSC3Conveyor.Text.Trim();
                _plObjAssy.PcName = GlobalVariable.mPCName;
                DataTable dataTable = _blObjAssy.BL_ExecuteTask(_plObjAssy);
                if (dataTable.Rows.Count > 0)
                {
                    SCANNER_3_TRIGGER_TIME = Convert.ToInt32(dataTable.Rows[0]["ScannerTriggerTimeInSec"]);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetScanner1InputData()
        {
            try
            {
                // bool IsConnected = _tcpClient.GetServerStatus();
                //SetStation1UpDown(IsConnected);
                string isConnectedScanner1 = _tcpClientScanner1.GetPLCStatus();
                string newImageScanner1 = isConnectedScanner1 == "Connected" ? @"Resources\ScannerConnected.png" : @"Resources\ScannerDisconnected.png";
                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Check isConnectedScanner1::", $"Scanner1 IsConnected :: {isConnectedScanner1}");
                picSC1Img.Invoke(new Action(() =>
                {

                    if (picSC1Img.Tag == null || picSC1Img.Tag.ToString() != newImageScanner1)  // Prevent unnecessary updates
                    {
                        //if (picSC1Img.Image != null)
                        //{
                        //    picSC1Img.Image.Dispose();
                        //}
                        picSC1Img.Image = Image.FromFile(newImageScanner1);
                        picSC1Img.SizeMode = PictureBoxSizeMode.Zoom;
                        picSC1Img.Tag = newImageScanner1; // Store last assigned image
                    }
                }));
                if (_IsScanner1Complete)
                {
                    _IsScanner1Complete = false;
                    string data = _tcpClientScanner1.GetPLCInput();

                    GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Acutal Data From Scanner-1", $"Scanner-1 Input data received {data}");
                    if (data.Length > 3)
                    {

                        this.Invoke(new Action(() =>
                        {


                            GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Acutal Data From Scanner-1", data.Trim('\r').ToUpper());


                            if (data.Trim().Replace("\0", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty).Length > 3)
                            {
                                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Acutal OK Data From Scanner-1", data.Trim().Replace("\0", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty));

                                _plObjAssy = new PL_LINE_ASSY();
                                _plObjAssy.DbType = "BIND_TRY_MODEL_DATA";
                                _plObjAssy.Conveyor = lblSC1Conveyor.Text.Trim();
                                _plObjAssy.Line = GlobalVariable.mPCName;
                                _plObjAssy.TrayBarcode = data.Trim();
                                _plObjAssy.LogMSG = $"Before Check From DB Scanned Barcode {data}";
                                DataTable dtGetData = _blObjAssy.BL_ExecuteTask(_plObjAssy);
                                if (dtGetData.Rows.Count > 0)
                                {
                                    lblSC1ModelNo.Text = dtGetData.Rows[0]["ModelNo"].ToString();
                                    lblSC1ModelName.Text = dtGetData.Rows[0]["ModelName"].ToString();
                                    lblSC1PartNo.Text = dtGetData.Rows[0]["ChildPartNo"].ToString();
                                    lblSC1PartName.Text = dtGetData.Rows[0]["ChildPartName"].ToString();
                                    lblSC1LotNo.Text = dtGetData.Rows[0]["LotNo"].ToString();

                                    lblSC1CurrentTray.Text = data.Trim();
                                    _plObjAssy = new PL_LINE_ASSY();
                                    _plObjAssy.DbType = "SCAN_AND_SAVE";
                                    _plObjAssy.Conveyor = lblSC1Conveyor.Text.Trim();
                                    _plObjAssy.PcName = GlobalVariable.mPCName;
                                    _plObjAssy.ModelNo = lblSC1ModelNo.Text.Trim();
                                    _plObjAssy.ChildPartNo = lblSC1PartNo.Text.Trim();
                                    _plObjAssy.LotNo = lblSC1LotNo.Text.Trim();
                                    _plObjAssy.TrayBarcode = data.Trim();
                                    _plObjAssy.CreatedBy = "ADMIN";
                                    DataTable dt = _blObjAssy.BL_ExecuteTask(_plObjAssy);
                                    if (dt.Rows.Count > 0)
                                    {
                                        if (dt.Rows[0]["Result"].Equals("Y"))
                                        {
                                            lblShowMessage(lblSC1Message, $"Tray Scanned Successfully ({data})", 1);
                                            _plObjAssy.LogMSG = $"Tray Scanned Successfully ({data})";
                                            AssyLogStampScanner1(_plObjAssy);
                                            BindViewConveyor1();

                                        }
                                        else
                                        {
                                            if (dt.Rows[0]["Result"].ToString().StartsWith("This TRAY") && dt.Rows[0]["Result"].ToString().EndsWith("Scanned."))
                                            {
                                                lblShowMessage(lblSC1Message, $"{dt.Rows[0]["Result"]}", 1);
                                            }
                                            else
                                            {
                                                GlobalVariable.MesseageInfo(lblSC1Message, $"{dt.Rows[0]["Result"]}", 2);
                                            }
                                            _plObjAssy.LogMSG = $"Tray ({data}) DB Response:: {dt.Rows[0]["Result"]}";
                                            AssyLogStampScanner1(_plObjAssy);
                                            return;
                                        }
                                    }



                                }
                                else
                                {

                                    GlobalVariable.MesseageInfo(lblSC1Message, $"Invalid {data.Trim()} Tray. Not Mapped on Washing Station", 2);
                                    _plObjAssy.LogMSG = $"Invalid {data.Trim()} Tray. Not Mapped on Washing Station";
                                    AssyLogStampScanner1(_plObjAssy);
                                    return;
                                }

                            }

                        }));
                    }
                    else
                    {
                        GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtMessage, "Acutal NG Data From Scanner-1", data.Trim().Replace("\0", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty));
                        Log.Warning($"Scanner Input - data format is not valid");
                    }
                    _IsScanner1Complete = true;
                }




            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception Occured");
                _IsScanner1Complete = true;
            }
            finally
            {
                _IsScanner1Complete = true;
            }
        }
        private void GetScanner2InputData()
        {
            try
            {
                // bool IsConnected = _tcpClient.GetServerStatus();
                //SetStation1UpDown(IsConnected);
                string isConnectedScanner2 = _tcpClientScanner2.GetPLCStatus();
                string newImageScanner2 = isConnectedScanner2 == "Connected" ? @"Resources\ScannerConnected.png" : @"Resources\ScannerDisconnected.png";
                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Check isConnectedScanner2::", $"Scanner2 IsConnected :: {isConnectedScanner2}");
                picSC2Img.Invoke(new Action(() =>
                {

                    if (picSC2Img.Tag == null || picSC2Img.Tag.ToString() != newImageScanner2)
                    {
                        //if (picSC2Img.Image != null)
                        //{
                        //    picSC2Img.Image.Dispose();
                        //}
                        picSC2Img.Image = Image.FromFile(newImageScanner2);
                        picSC2Img.SizeMode = PictureBoxSizeMode.Zoom;
                        picSC2Img.Tag = newImageScanner2;
                    }
                }));
                if (_IsScanner2Complete)
                {
                    _IsScanner2Complete = false;
                    string data = _tcpClientScanner2.GetPLCInput();

                    GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Acutal Data From Scanner-2", $"Scanner Input data received {data}");
                    if (data.Length > 3)
                    {

                        this.pnlConveyor2.Invoke(new Action(() =>
                        {


                            GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Acutal Data From Scanner-2", data.Trim('\r').ToUpper());


                            if (data.Trim().Replace("\0", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty).Length > 3)
                            {
                                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Acutal OK Data From Scanner-2", data.Trim().Replace("\0", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty));

                                _plObjAssy = new PL_LINE_ASSY();
                                _plObjAssy.DbType = "BIND_TRY_MODEL_DATA";
                                _plObjAssy.Conveyor = lblSC2Conveyor.Text.Trim();
                                _plObjAssy.Line = GlobalVariable.mPCName;
                                _plObjAssy.TrayBarcode = data.Trim();
                                _plObjAssy.LogMSG = $"Before Check From DB Scanned Barcode {data}";
                                DataTable dtGetData = _blObjAssy.BL_ExecuteTask(_plObjAssy);
                                if (dtGetData.Rows.Count > 0)
                                {
                                    lblSC2ModelNo.Text = dtGetData.Rows[0]["ModelNo"].ToString();
                                    lblSC2ModelName.Text = dtGetData.Rows[0]["ModelName"].ToString();
                                    lblSC2PartNo.Text = dtGetData.Rows[0]["ChildPartNo"].ToString();
                                    lblSC2PartName.Text = dtGetData.Rows[0]["ChildPartName"].ToString();
                                    lblSC2LotNo.Text = dtGetData.Rows[0]["LotNo"].ToString();

                                    lblSC2CurrentTray.Text = data.Trim();
                                    _plObjAssy = new PL_LINE_ASSY();
                                    _plObjAssy.DbType = "SCAN_AND_SAVE";
                                    _plObjAssy.Conveyor = lblSC2Conveyor.Text.Trim();
                                    _plObjAssy.PcName = GlobalVariable.mPCName;
                                    _plObjAssy.ModelNo = lblSC2ModelNo.Text.Trim();
                                    _plObjAssy.ChildPartNo = lblSC2PartNo.Text.Trim();
                                    _plObjAssy.LotNo = lblSC2LotNo.Text.Trim();
                                    _plObjAssy.TrayBarcode = data.Trim();
                                    _plObjAssy.CreatedBy = "ADMIN";

                                    DataTable dt = _blObjAssy.BL_ExecuteTask(_plObjAssy);
                                    if (dt.Rows.Count > 0)
                                    {
                                        if (dt.Rows[0]["Result"].Equals("Y"))
                                        {
                                            lblShowMessage(lblSC2Message, $"Tray Scanned Successfully ({data})", 1);
                                            _plObjAssy.LogMSG = $"Tray Scanned Successfully ({data})";
                                            AssyLogStampScanner2(_plObjAssy);
                                            BindViewConveyor2();

                                        }
                                        else
                                        {
                                            if (dt.Rows[0]["Result"].ToString().StartsWith("This TRAY") && dt.Rows[0]["Result"].ToString().EndsWith("Scanned."))
                                            {
                                                lblShowMessage(lblSC2Message, $"{dt.Rows[0]["Result"]}", 1);
                                            }
                                            else
                                            {
                                                GlobalVariable.MesseageInfo(lblSC2Message, $"{dt.Rows[0]["Result"]}", 2);
                                            }
                                            _plObjAssy.LogMSG = $"Tray ({data}) DB Response:: {dt.Rows[0]["Result"]}";
                                            AssyLogStampScanner2(_plObjAssy);
                                            return;
                                        }
                                    }



                                }
                                else
                                {

                                    GlobalVariable.MesseageInfo(lblSC2Message, $"Invalid {data.Trim()} Tray. Not Mapped on Washing Station", 2);
                                    _plObjAssy.LogMSG = $"Invalid {data.Trim()} Tray. Not Mapped on Washing Station";
                                    AssyLogStampScanner2(_plObjAssy);
                                    return;
                                }

                            }

                        }));
                    }
                    else
                    {
                        GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtMessage, "Acutal NG Data From Scanner-2", data.Trim().Replace("\0", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty));
                        Log.Warning($"Scanner Input - data format is not valid");
                    }
                    _IsScanner2Complete = true;
                }




            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception Occured");
                _IsScanner2Complete = true;
            }
            finally
            {
                _IsScanner2Complete = true;
            }
        }

        private void GetScanner3InputData()
        {
            try
            {
                // bool IsConnected = _tcpClient.GetServerStatus();
                //SetStation1UpDown(IsConnected);
                string isConnectedScanner3 = _tcpClientScanner3.GetPLCStatus();
                string newImageScanner3 = isConnectedScanner3 == "Connected" ? @"Resources\ScannerConnected.png" : @"Resources\ScannerDisconnected.png";
                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Check isConnectedScanner3::", $"Scanner3 IsConnected :: {isConnectedScanner3}");
                picSC3Img.Invoke(new Action(() =>
                {
                    if (picSC3Img.Tag == null || picSC3Img.Tag.ToString() != newImageScanner3)
                    {
                        //if (picSC3Img.Image != null)
                        //{
                        //    picSC3Img.Image.Dispose();
                        //}
                        picSC3Img.Image = Image.FromFile(newImageScanner3);
                        picSC3Img.SizeMode = PictureBoxSizeMode.Zoom;
                        picSC3Img.Tag = newImageScanner3;
                    }
                }));
                if (_IsScanner3Complete)
                {
                    _IsScanner3Complete = false;
                    string data = _tcpClientScanner3.GetPLCInput();

                    GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Acutal Data From Scanner-3", $"Scanner-3 Input data received {data}");
                    if (data.Length > 3)
                    {
                        string[] sArrData = data.Split(',');
                        this.Invoke(new Action(() =>
                        {


                            GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Acutal Data From Scanner-3", data.Trim('\r').ToUpper());
                            if (data.Trim().Replace("\0", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty).Length > 3)
                            {
                                GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Acutal OK Data From Scanner-3", data.Trim().Replace("\0", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty));

                                _plObjAssy = new PL_LINE_ASSY();
                                _plObjAssy.DbType = "BIND_TRY_MODEL_DATA";
                                _plObjAssy.Conveyor = lblSC3Conveyor.Text.Trim();
                                _plObjAssy.Line = GlobalVariable.mPCName;
                                _plObjAssy.TrayBarcode = data.Trim();
                                _plObjAssy.LogMSG = $"Before Check From DB Scanned Barcode {data}";
                                DataTable dtGetData = _blObjAssy.BL_ExecuteTask(_plObjAssy);
                                if (dtGetData.Rows.Count > 0)
                                {
                                    lblSC3ModelNo.Text = dtGetData.Rows[0]["ModelNo"].ToString();
                                    lblSC3ModelName.Text = dtGetData.Rows[0]["ModelName"].ToString();
                                    lblSC3PartNo.Text = dtGetData.Rows[0]["ChildPartNo"].ToString();
                                    lblSC3PartName.Text = dtGetData.Rows[0]["ChildPartName"].ToString();
                                    lblSC3LotNo.Text = dtGetData.Rows[0]["LotNo"].ToString();

                                    lblSC3CurrentTray.Text = data.Trim();
                                    _plObjAssy = new PL_LINE_ASSY();
                                    _plObjAssy.DbType = "SCAN_AND_SAVE";
                                    _plObjAssy.Conveyor = lblSC3Conveyor.Text.Trim();
                                    _plObjAssy.PcName = GlobalVariable.mPCName;
                                    _plObjAssy.ModelNo = lblSC3ModelNo.Text.Trim();
                                    _plObjAssy.ChildPartNo = lblSC3PartNo.Text.Trim();
                                    _plObjAssy.LotNo = lblSC3LotNo.Text.Trim();
                                    _plObjAssy.TrayBarcode = data.Trim();
                                    _plObjAssy.CreatedBy = "ADMIN";
                                    DataTable dt = _blObjAssy.BL_ExecuteTask(_plObjAssy);
                                    if (dt.Rows.Count > 0)
                                    {
                                        if (dt.Rows[0]["Result"].Equals("Y"))
                                        {
                                            lblShowMessage(lblSC3Message, $"Tray Scanned Successfully ({data})", 1);
                                            _plObjAssy.LogMSG = $"Tray Scanned Successfully ({data})";
                                            AssyLogStampScanner3(_plObjAssy);
                                            BindViewConveyor3();

                                        }
                                        else
                                        {
                                            if (dt.Rows[0]["Result"].ToString().StartsWith("This TRAY") && dt.Rows[0]["Result"].ToString().EndsWith("Scanned."))
                                            {
                                                lblShowMessage(lblSC3Message, $"{dt.Rows[0]["Result"]}", 1);
                                            }
                                            else
                                            {
                                                GlobalVariable.MesseageInfo(lblSC3Message, $"{dt.Rows[0]["Result"]}", 2);
                                            }
                                            _plObjAssy.LogMSG = $"Tray ({data}) DB Response:: {dt.Rows[0]["Result"]}";
                                            AssyLogStampScanner3(_plObjAssy);
                                            return;
                                        }
                                    }



                                }
                                else
                                {

                                    GlobalVariable.MesseageInfo(lblSC3Message, $"Invalid {data.Trim()} Tray. Not Mapped on Washing Station", 2);
                                    _plObjAssy.LogMSG = $"Invalid {data.Trim()} Tray. Not Mapped on Washing Station";
                                    AssyLogStampScanner3(_plObjAssy);
                                    return;
                                }

                            }



                        }));
                    }
                    else
                    {
                        GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtMessage, "Acutal NG Data From PLC", data.Trim().Replace("\0", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty));
                        Log.Warning($"Scanner Input - data format is not valid");
                    }
                    _IsScanner3Complete = true;
                }




            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception Occured");
                _IsScanner3Complete = true;
            }
            finally
            {
                _IsScanner3Complete = true;
            }
        }
        void lblShowMessage(Label lblMsg, string msg = "", int ictr = -1)
        {
            if (ictr == 1)
            {
                lblMsg.BackColor = Color.DarkGreen;
                lblMsg.Text = msg;
            }
            else if (ictr == 2)
            {
                lblMsg.BackColor = Color.Red;
                lblMsg.Text = msg;

            }
            else
            {
                lblMsg.BackColor = Color.Transparent;
                lblMsg.Text = msg;
            }
        }
        private async void PingScannersAsync()
        {
            await Task.Run(() =>
            {
                // Ping all scanners asynchronously
                PingScanner(1, GlobalVariable.SC1ScannerIP, GlobalVariable.SC1ScannerPort, picSC1Img, lblSC1Message, lblSC1Conveyor);
                PingScanner(2, GlobalVariable.SC2ScannerIP, GlobalVariable.SC2ScannerPort, picSC2Img, lblSC2Message, lblSC2Conveyor);
                PingScanner(3, GlobalVariable.SC3ScannerIP, GlobalVariable.SC3ScannerPort, picSC3Img, lblSC3Message, lblSC3Conveyor);

                // Allow the timer to invoke the function again
                IsPingComplete = true;
            });
        }

        private void PingScanner(int scannerId, string ip, int port, PictureBox picScannerImg, Label lblScannerMessage, Label lblScannerConveyor)
        {
            clsPLC_Update tcpClientScanner = new clsPLC_Update(ip, port);
            string isConnected = tcpClientScanner.GetPLCStatus();

            // Update UI on the main thread
            picScannerImg.Invoke(new Action(() =>
            {
                if (picScannerImg.Image != null)
                {
                    picScannerImg.Image.Dispose(); // Properly dispose of previous image
                }

                picScannerImg.Image = Image.FromFile(isConnected == "Connected" ? @"Resources\ScannerConnected.png" : @"Resources\ScannerDisconnected.png");
                picScannerImg.SizeMode = PictureBoxSizeMode.Zoom;
            }));

            lblScannerMessage.Invoke(new Action(() =>
            {
                if (isConnected == "Not Connected")
                {
                    lblShowMessage(lblScannerMessage, $"Conveyor {lblScannerConveyor.Text.Trim()} Scanner Not Connected", 2);
                }
                else
                {
                    lblShowMessage(lblScannerMessage, "", -1);
                }
            }));
        }
        private void CheckIPStatusOLD()
        {
            try
            {
                PingScannersAsync();
            }
            catch (Exception ex)
            {

                Log.Error($"Exception Occured::CheckPinging::Message-{ex.Message}");

            }
        }

        private void CheckIPStatus()
        {
            elapsedTime++;
            try
            {
                // Scanner 1
                //if (_tcpClientScanner1 != null)
                //{
                //    _tcpClientScanner1.Dispose();
                //    _tcpClientScanner1 = null;
                //}
                if (_tcpClientScanner1 == null)
                {
                    _tcpClientScanner1 = new clsPLC_Update(GlobalVariable.SC1ScannerIP, GlobalVariable.SC1ScannerPort);
                    GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "_tcpClientScanner1 Object Initiated", $"Object Initilized");
                }

                string isConnectedScanner1 = _tcpClientScanner1.GetPLCStatus();
                //string newImageScanner1 = isConnectedScanner1== "Connected" ? @"Resources\ScannerConnected.png" : @"Resources\ScannerDisconnected.png";
                //GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Check isConnectedScanner1::", $"Scanner1 IsConnected :: {isConnectedScanner1}");
                //picSC1Img.Invoke(new Action(() =>
                //{

                //    if (picSC1Img.Tag == null || picSC1Img.Tag.ToString() != newImageScanner1)  // Prevent unnecessary updates
                //    {
                //        //if (picSC1Img.Image != null)
                //        //{
                //        //    picSC1Img.Image.Dispose();
                //        //}
                //        picSC1Img.Image = Image.FromFile(newImageScanner1);
                //        picSC1Img.SizeMode = PictureBoxSizeMode.Zoom;
                //        picSC1Img.Tag = newImageScanner1; // Store last assigned image
                //    }
                //}));
                try
                {
                    if (isConnectedScanner1 == "Connected" && elapsedTime % SCANNER_1_TRIGGER_TIME == 0)
                    {
                        _tcpClientScanner1.WriteToPLC("TRG\r");
                    }

                }
                catch
                {


                }

                //lblSC1Message.Invoke(new Action(() =>
                //{
                //    if (!isConnectedScanner1)
                //    {
                //        lblShowMessage(lblSC1Message, $"Conveyor {lblSC1Conveyor.Text.Trim()} Scanner Not Connected", 2);
                //    }
                //    else
                //    {
                //        lblShowMessage(lblSC1Message, $"", -1);
                //    }
                //}));

                // Scanner 2
                //if (_tcpClientScanner2 != null)
                //{
                //    _tcpClientScanner2.Dispose();
                //    _tcpClientScanner2 = null;
                //}
                if (_tcpClientScanner2 == null)
                {
                    _tcpClientScanner2 = new clsPLC_Update(GlobalVariable.SC2ScannerIP, GlobalVariable.SC2ScannerPort);
                    GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "_tcpClientScanner2 Object Initiated", $"Object Initilized");
                }

                string isConnectedScanner2 = _tcpClientScanner2.GetPLCStatus();
                //string newImageScanner2 = isConnectedScanner2=="Connected" ? @"Resources\ScannerConnected.png" : @"Resources\ScannerDisconnected.png";
                //GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Check isConnectedScanner2::", $"Scanner2 IsConnected :: {isConnectedScanner2}");
                //picSC2Img.Invoke(new Action(() =>
                //{

                //    if (picSC2Img.Tag == null || picSC2Img.Tag.ToString() != newImageScanner2)
                //    {
                //        //if (picSC2Img.Image != null)
                //        //{
                //        //    picSC2Img.Image.Dispose();
                //        //}
                //        picSC2Img.Image = Image.FromFile(newImageScanner2);
                //        picSC2Img.SizeMode = PictureBoxSizeMode.Zoom;
                //        picSC2Img.Tag = newImageScanner2;
                //    }
                //}));
                try
                {
                    if (isConnectedScanner2 == "Connected" && elapsedTime % SCANNER_2_TRIGGER_TIME == 0)
                    {
                        _tcpClientScanner2.WriteToPLC("TRG\r");
                    }
                }
                catch
                {


                }

                //lblSC2Message.Invoke(new Action(() =>
                //{
                //    if (!isConnectedScanner2)
                //    {
                //        lblShowMessage(lblSC2Message, $"Conveyor {lblSC2Conveyor.Text.Trim()} Scanner Not Connected", 2);
                //    }
                //    else
                //    {
                //        lblShowMessage(lblSC2Message, $"", -1);
                //    }
                //}));

                // Scanner 3
                //if (_tcpClientScanner3 != null)
                //{
                //    _tcpClientScanner3.Dispose();
                //    _tcpClientScanner3 = null;
                //}
                if (_tcpClientScanner3 == null)
                {
                    _tcpClientScanner3 = new clsPLC_Update(GlobalVariable.SC3ScannerIP, GlobalVariable.SC3ScannerPort);
                    GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "_tcpClientScanner3 Object Initiated", $"Object Initilized");
                }

                string isConnectedScanner3 = _tcpClientScanner3.GetPLCStatus();
                //string newImageScanner3 = isConnectedScanner3=="Connected" ? @"Resources\ScannerConnected.png" : @"Resources\ScannerDisconnected.png";
                //GlobalVariable.AppLog.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Check isConnectedScanner3::", $"Scanner3 IsConnected :: {isConnectedScanner3}");
                //picSC3Img.Invoke(new Action(() =>
                //{
                //    if (picSC3Img.Tag == null || picSC3Img.Tag.ToString() != newImageScanner3)
                //    {
                //        //if (picSC3Img.Image != null)
                //        //{
                //        //    picSC3Img.Image.Dispose();
                //        //}
                //        picSC3Img.Image = Image.FromFile(newImageScanner3);
                //        picSC3Img.SizeMode = PictureBoxSizeMode.Zoom;
                //        picSC3Img.Tag = newImageScanner3;
                //    }
                //}));
                try
                {
                    if (isConnectedScanner3 == "Connected" && elapsedTime % SCANNER_3_TRIGGER_TIME == 0)
                    {
                        _tcpClientScanner3.WriteToPLC("TRG\r");
                    }
                }
                catch
                {


                }

                //lblSC3Message.Invoke(new Action(() =>
                //{
                //    if (!isConnectedScanner3)
                //    {
                //        lblShowMessage(lblSC3Message, $"Conveyor {lblSC3Conveyor.Text.Trim()} Scanner Not Connected", 2);
                //    }
                //    else
                //    {
                //        lblShowMessage(lblSC3Message, $"", -1);
                //    }
                //}));
                if (elapsedTime >= RESET_TIME)
                {
                    elapsedTime = 0;
                }
                IsPingComplete = true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception Occurred");
            }


        }
        private bool CheckPinging(string IpAddress)
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send(IpAddress, 30);
                return reply.Status == IPStatus.Success;
            }
            catch (Exception ex)
            {
                Log.Error($"Exception Occured::CheckPinging::Message-{ex.Message}");
                return false;
            }
        }
        void RestoreThirdPanel()
        {
            splitContainer2.Panel2Collapsed = false; // Show the third panel

            int totalWidth = splitContainer1.Width; // Get total width
            int newWidth = totalWidth / 3; // Divide equally among three sections

            splitContainer1.SplitterDistance = newWidth * 1; // First section width
            //splitContainer2.SplitterDistance = newWidth * 1; // Second section width
        }

        private void BindAllScreen()
        {
            try
            {
                _blObj = new BL_LINE_ASSY_DASH();
                _plObj = new PL_LINE_ASSY_DASH();
                _plObj.DbType = "GET_DATA";
                _plObj.LinePc = GlobalVariable.mPCName;
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count == 3)
                    {
                        RestoreThirdPanel();
                        lblSC1Conveyor.Text = dt.Rows[0]["ConveryorCode"].ToString();
                        GlobalVariable.SC1ScannerIP = dt.Rows[0]["CamIP"].ToString();
                        GlobalVariable.SC1ScannerPort = int.Parse(dt.Rows[0]["Port"].ToString());

                        lblSC2Conveyor.Text = dt.Rows[1]["ConveryorCode"].ToString();
                        GlobalVariable.SC2ScannerIP = dt.Rows[1]["CamIP"].ToString();
                        GlobalVariable.SC2ScannerPort = int.Parse(dt.Rows[1]["Port"].ToString());

                        lblSC3Conveyor.Text = dt.Rows[2]["ConveryorCode"].ToString();
                        GlobalVariable.SC3ScannerIP = dt.Rows[2]["CamIP"].ToString();
                        GlobalVariable.SC3ScannerPort = int.Parse(dt.Rows[2]["Port"].ToString());
                        btnClose2.Visible = false;
                    }
                    else if (dt.Rows.Count == 2)
                    {
                        CollapseThirdPanel();
                        lblSC1Conveyor.Text = dt.Rows[0]["ConveryorCode"].ToString();
                        GlobalVariable.SC1ScannerIP = dt.Rows[0]["CamIP"].ToString();
                        GlobalVariable.SC1ScannerPort = int.Parse(dt.Rows[0]["Port"].ToString());

                        lblSC2Conveyor.Text = dt.Rows[1]["ConveryorCode"].ToString();
                        GlobalVariable.SC2ScannerIP = dt.Rows[1]["CamIP"].ToString();
                        GlobalVariable.SC2ScannerPort = int.Parse(dt.Rows[1]["Port"].ToString());
                        btnClose2.Visible = true;
                    }
                    else
                    {
                        CollapseThirdPanel();
                        lblSC1Conveyor.Text = dt.Rows[0]["ConveryorCode"].ToString();
                        GlobalVariable.SC1ScannerIP = dt.Rows[0]["CamIP"].ToString();
                        GlobalVariable.SC1ScannerPort = int.Parse(dt.Rows[0]["Port"].ToString());

                        lblSC2Conveyor.Text = dt.Rows[1]["ConveryorCode"].ToString();
                        GlobalVariable.SC2ScannerIP = dt.Rows[1]["CamIP"].ToString();
                        GlobalVariable.SC2ScannerPort = int.Parse(dt.Rows[1]["Port"].ToString());
                        btnClose2.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #region Socket Client Connection
        private async Task StartSocketClientAsync()
        {
            try
            {
                await Task.Run(() => ConnectToSocketClient());
                //Start timer for Check TcpClient connection for Server Type Controller
                timerTcpClient.Enabled = true;
                //* enable ping timer and start 
                timerPing.Enabled = true;

            }
            catch (Exception ex) { Log.Error(ex, $"Exception Occured"); }
        }

        private void dgvSC1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSC1Export_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVariable.mConveyor = "";
                GlobalVariable.mConveyor = lblSC1Conveyor.Text.Trim();
                frmConveyorAssyReport frm = new frmConveyorAssyReport();
                frm.Show();
                frm.FormClosing += OFrm_FormClosing;
                this.Hide();
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void btnSC2Export_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVariable.mConveyor = "";
                GlobalVariable.mConveyor = lblSC2Conveyor.Text.Trim();
                frmConveyorAssyReport frm = new frmConveyorAssyReport();
                frm.Show();
                frm.FormClosing += OFrm_FormClosing;
                this.Hide();
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }

        }

        private void btnSC3Export_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVariable.mConveyor = "";
                GlobalVariable.mConveyor = lblSC3Conveyor.Text.Trim();
                frmConveyorAssyReport frm = new frmConveyorAssyReport();
                frm.Show();
                frm.FormClosing += OFrm_FormClosing;
                this.Hide();
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMainDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //oServer.StopService();
                //oServer = null;
                timerTcpClient.Enabled = false;
                timerPing.Enabled = false;
                if (_tcpClientScanner1 != null)
                    _tcpClientScanner1.Dispose();

                if (_tcpClientScanner2 != null)
                    _tcpClientScanner2.Dispose();

                if (_tcpClientScanner3 != null)
                    _tcpClientScanner3.Dispose();



                GC.Collect();
            }
            catch (Exception ex) { Log.Error(ex, $"Exception Occured"); }
        }

        private void ConnectToSocketClient()
        {
            try
            {
                //Start for the station 1 IR
                //now station 1 IR having 4 more tool will be added //modified by dipak 07-12-21
                /* dispose previous object if having any reference*/
                if (_tcpClientScanner1 != null)
                {
                    _tcpClientScanner1.Dispose();
                    _tcpClientScanner1 = null;
                }
                _tcpClientScanner1 = new clsPLC_Update(GlobalVariable.SC1ScannerIP, (GlobalVariable.SC1ScannerPort));

                if (_tcpClientScanner2 != null)
                {
                    _tcpClientScanner2.Dispose();
                    _tcpClientScanner2 = null;
                }
                _tcpClientScanner2 = new clsPLC_Update(GlobalVariable.SC2ScannerIP, GlobalVariable.SC2ScannerPort);

                if (_tcpClientScanner3 != null)
                {
                    _tcpClientScanner3.Dispose();
                    _tcpClientScanner3 = null;
                }
                _tcpClientScanner3 = new clsPLC_Update(GlobalVariable.SC3ScannerIP, GlobalVariable.SC3ScannerPort);


            }
            catch (Exception ex) { Log.Error(ex, $"Exception Occured"); }
        }


        #endregion
        #endregion




        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMainDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                //  this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                BindAllScreen();
                StartSocketClientAsync();
                BindViewConveyor1();
                BindViewConveyor2();
                BindViewConveyor3();
                BindLabelConveyor1();
                BindLabelConveyor2();
                BindLabelConveyor3();
                BindViewConveyor1TriggerTime();
                BindViewConveyor2TriggerTime();
                BindViewConveyor3TriggerTime();
                RESET_TIME = SCANNER_1_TRIGGER_TIME + SCANNER_2_TRIGGER_TIME + SCANNER_3_TRIGGER_TIME;

                /*
                * ConnectSocketServer()-This will enable the socket server but we are not using currently socket server but we will keep commented,
                * in case of future requirement.
                */
                // ConnectSocketServer();

                //Start the socket client connection to access data from the socket serer

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }
    }
}
