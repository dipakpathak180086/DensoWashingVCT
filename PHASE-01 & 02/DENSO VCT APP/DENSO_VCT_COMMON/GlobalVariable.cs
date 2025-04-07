using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SatoLib;

namespace DENSO_VCT_COMMON
{
    public class GlobalVariable
    {
        public static SatoCustomFunction mStoCustomFunction = new SatoCustomFunction();
        public static string mSatoApps = "SatoApps";
        public static string mMainSqlConString = "";
        public static string mSatoDbServer = "";
        public static string mSatoDb = "";
        public static string mSatoDbUser = "";
        public static string mSatoDbPassword = "";
        public static string mSatoAppsLoginUser = "ADMIN";
        public static string mUserType = "";
        public static SatoLogger AppLog;
        public static string UserName = "";
        public static string UserGroup = "";
        public static string mAccessUser = "";
        public static string mParentPart = "";
        public static string mParentPartName = "";
        public static string mChildPart = "";
        public static string mChildPartName = "";
        public static string mShift = "";
        public static string mParentLabelTextEvent = "";
        public static string mChildLabelTextEvent = "";
        public static Dictionary<string, string> mdicChildPart = new Dictionary<string, string>();
        public static int mIRunningIndex = 0;

        public static string mKitScannerPort = "COM1";
        public static string mKitScannerBaudRate = "9600";
        public static string mKitScannerDataBits = "One";
        public static string mKitScannerParity = "None";
        public static string mKitScannerStopBits = "One";

        public static int mWashingQty = 0;
        public static bool mWashingQtyAlert = false;

        public static bool mIsTrayScanning = false;
        public static string mTray01 = "";
        public static string mTray02 = "";
        public static string mTray03 = "";
        public static string mTray04 = "";
        public static string mConveyor = "";
        public static bool mIsDelete = false;
        public static bool mIsTrayEnable = false;
        public static bool mIsTrayBarcode = false;
        public static bool mIsLotBarcode = false;
        public static string mScannedBarcode = "";
        private static System.Timers.Timer _timer;
        public static event Action Elapsed; // Simple event
        public static string mLineNo = "";
        public static string mPCName = "";
        public static string mDashboardMode = "";
        public static string SC1ScannerIP = "";
        public static int SC1ScannerPort = 1024;
        public static string SC2ScannerIP = "";
        public static int SC2ScannerPort = 1024;
        public static string SC3ScannerIP = "";
        public static int SC3ScannerPort = 1024;
        public static void Start(double interval)
        {
            if (_timer == null)
            {
                _timer = new System.Timers.Timer(interval);
                // _timer.Elapsed += (sender, e) => Elapsed?.Invoke();
                _timer.Elapsed += _timer_Elapsed;
                _timer.AutoReset = true;
            }
            _timer.Start();
        }

        private static void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (GlobalVariable.mScannedBarcode.StartsWith("TR"))
            {

            }
        }

        public static void Stop()
        {
            if (_timer != null)
            {
                _timer.Stop();
            }
        }
        public static void MesseageInfo(Label label, string sMessage, int icnt)
        {
            if (icnt == 1)
            {
                label.BackColor = Color.Yellow;
                label.ForeColor = Color.Black;
                label.Text = sMessage;
            }
            else
            {
                label.BackColor = Color.Red;
                label.ForeColor = Color.WhiteSmoke;
                label.Text = sMessage;
            }
        }
        public static void allowOnlyNumeric(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        public static void allowOnlyAlpha(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        public static void BindCombo(ComboBox comboBox, DataTable dataTable)
        {
            try
            {
                DataRow Drw;
                Drw = dataTable.NewRow();
                Drw.ItemArray = new object[] { 0, "--Select--" };
                dataTable.Rows.InsertAt(Drw, 0);
                comboBox.DataSource = dataTable.DefaultView;
                comboBox.ValueMember = dataTable.Columns[0].ColumnName;
                comboBox.DisplayMember = dataTable.Columns[1].ColumnName;

            }
            catch (Exception ex)
            {
                if (ex.Message == "ComboBox that has a DataSource set cannot be sorted") { return; }
                throw;
            }
        }
        public static void allowOnlyIP(object sender, KeyPressEventArgs e)
        {
            // Allow only digits, the dot (.), and control keys (like Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Prevent the character from being entered
            }

            // Allow only one dot between numbers
            TextBox textBox = sender as TextBox;
            if (e.KeyChar == '.' && (textBox.Text.EndsWith(".") || textBox.Text.Count(c => c == '.') >= 3))
            {
                e.Handled = true; // Prevent extra dots
            }
        }
        public static string strRight(string strValue, int intLength)
        {
            string strRet = string.Empty;
            try
            {
                strRet = strValue.Substring(strValue.Length - intLength);
            }
            catch (Exception ex)
            {
                strRet = strValue;
            }
            return strRet;
        }
        public static string strLeft(string strValue, int intLength)
        {
            string strRet = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(strValue)) strRet = strValue;
                intLength = Math.Abs(intLength);
                strRet = strValue.Length <= intLength ? strValue : strValue.Substring(0, intLength);
            }
            catch (Exception ex)
            {
                strRet = strValue;
            }
            return strRet;
        }
        public static void allowOnlyForLandline(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '-'))
            {
                e.Handled = false;
            }

        }
        public static void allowOnlyNumericAndDecimal(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^[0-9]{10}$").Success;
        }
        public static bool IsEmailId(string email)
        {
            return Regex.Match(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success;
        }
        public static string DataTableToCsv(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();

            var columnNames = dt.Columns.Cast<DataColumn>().Select(column => "\"" + column.ColumnName.Replace("\"", "\"\"") + "\"").ToArray();
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                var fields = row.ItemArray.Select(field => "\"" + field.ToString().Replace("\"", "\"\"") + "\"").ToArray();
                sb.AppendLine(string.Join(",", fields));
            }

            return sb.ToString().Replace("" + '"' + "", "");
        }
        public static void ExportDataInCSV(DataTable _dt)
        {
            string _FileName = string.Empty;
            SaveFileDialog sdb = new SaveFileDialog();
            sdb.InitialDirectory = @"C:\";
            sdb.Title = "Save text Files";
            if (sdb.ShowDialog() == DialogResult.OK)
                _FileName = sdb.FileName;
            else
                return;
            StreamWriter _sWriter = new StreamWriter(_FileName + ".csv");
            string _sData = "";
            try
            {

                for (int i = 0; i < _dt.Columns.Count; i++)
                {
                    if (_sData == "")
                        _sData = _dt.Columns[i].ColumnName.ToString().ToUpper();
                    else
                        _sData = _sData + "," + _dt.Columns[i].ColumnName.ToString().ToUpper();
                }
                _sWriter.WriteLine(_sData);

                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    _sData = "";
                    for (int j = 0; j < _dt.Columns.Count; j++)
                    {
                        if (_sData == "")
                            _sData = _dt.Rows[i][j].ToString().ToUpper().Replace(",", "").Replace("\t", "").Replace("\n", "").Trim();
                        else
                            _sData = _sData + "," + _dt.Rows[i][j].ToString().ToUpper().Replace(",", "").Replace("\t", "").Replace("\n", "").Trim();
                    }
                    _sWriter.WriteLine(_sData);
                }
                MessageBox.Show("Data exported successfully at " + _FileName + ".csv", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _sWriter.Close();
                _sWriter.Dispose();
            }
        }
        public static void ExportInCSV(DataGridView _dg)
        {
            string _FileName = string.Empty;
            SaveFileDialog sdb = new SaveFileDialog();
            sdb.InitialDirectory = @"C:\";
            sdb.Title = "Save text Files";
            if (sdb.ShowDialog() == DialogResult.OK)
                _FileName = sdb.FileName;
            else
                return;
            StreamWriter _sWriter = new StreamWriter(_FileName + ".csv");
            string _sData = "";
            try
            {

                for (int i = 0; i < _dg.ColumnCount; i++)
                {
                    if (_sData == "")
                        _sData = _dg.Columns[i].HeaderText.ToString().ToUpper().Replace(",", "").Replace("\t", "").Replace("\n", "").Trim();
                    else
                        _sData = _sData + "," + _dg.Columns[i].HeaderText.ToString().ToUpper().Replace(",", "").Replace("\t", "").Replace("\n", "").Trim();
                }
                _sWriter.WriteLine(_sData);
                int iout = 0;
                for (int i = 0; i < _dg.Rows.Count; i++)
                {
                    _sData = "";

                    for (int j = 0; j < _dg.ColumnCount; j++)
                    {
                        if (_dg.Rows[i].Cells[j].Value == null)
                            _dg.Rows[i].Cells[j].Value = "";
                        if (_sData == "")
                        {
                            if (int.TryParse(_dg.Rows[i].Cells[j].Value.ToString().ToUpper().Replace(",", "~").Replace("\t", "").Replace("\n", "").Trim(), out iout))
                                _sData = "'" + _dg.Rows[i].Cells[j].Value.ToString().ToUpper().Replace(",", "~").Replace("\t", "").Replace("\n", "").Trim();
                            else
                                _sData = _dg.Rows[i].Cells[j].Value.ToString().ToUpper().Replace(",", "~").Replace("\t", "").Replace("\n", "").Trim();

                        }
                        else
                        {
                            if (int.TryParse(_dg.Rows[i].Cells[j].Value.ToString().ToUpper().Replace(",", "~").Replace("\t", "").Replace("\n", "").Trim(), out iout))
                                _sData = _sData + ",'" + _dg.Rows[i].Cells[j].Value.ToString().ToUpper().Replace(",", "~").Replace("\t", "").Replace("\n", "").Trim();
                            else
                                _sData = _sData + "," + _dg.Rows[i].Cells[j].Value.ToString().ToUpper().Replace(",", "~").Replace("\t", "").Replace("\n", "").Trim();
                        }
                    }
                    _sWriter.WriteLine(_sData);
                }
                MessageBox.Show("Data exported successfully at " + _FileName + ".csv", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _sWriter.Close();
                _sWriter.Dispose();
            }
        }

        public static void ExportExcel(DataTable dt, string FileName)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application obj = new Microsoft.Office.Interop.Excel.Application();
                obj.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                Microsoft.Office.Interop.Excel.Range FormatRange;
                object misValue = System.Reflection.Missing.Value;
                FormatRange = obj.Worksheets[1].Cells;
                FormatRange.NumberFormat = "@";
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                xlWorkBook = obj.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                //AddColumn
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    obj.Cells[1, j + 1] = dt.Columns[j].ColumnName;
                }
                //Add Row
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (int.TryParse(dt.Rows[i][j].ToString(), out _) && !dt.Columns[j].ToString().Contains("LotNo"))
                        {
                            obj.Cells[i + 2, j + 1] = Convert.ToInt64(dt.Rows[i][j].ToString());
                        }
                        else if (DateTime.TryParse(dt.Rows[i][j].ToString(), out _) && !dt.Columns[j].ToString().Contains("LotNo"))
                        {
                            obj.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString();
                            xlWorkSheet.Rows.Cells.Range["B2"].NumberFormat = "dd-MM-yyyy";
                        }

                        else if (dt.Columns[j].ToString().Contains("LotNo"))
                        {
                            obj.Cells[i + 2, j + 1] = "'" + dt.Rows[i][j].ToString();
                        }
                        else
                        {
                            obj.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString();
                        }


                    }
                }
                ////xlWorkBook.FileFormat = Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel3
                ////xlWorkBook.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                ////xlWorkBook.Close(true, misValue, misValue);
                ////obj.Quit();
                obj.ActiveWorkbook.SaveAs(FileName);
                obj.ActiveWorkbook.Close(true);
                obj.ActiveWorkbook.Saved = true;

                obj.Quit();
                releaseObject(obj);
                releaseObject(xlWorkBook);
                releaseObject(xlWorkSheet);
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "File export successfully", 1);
            }
            catch (Exception fex)
            { throw fex; }
        }
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        public static void ShowCustomMessageBox(Form parent, string message)
        {
            CustomMessageBox msgBox = new CustomMessageBox(message);
           // parent.Focus();
            msgBox.ShowDialog(parent);
        }
    }
}
