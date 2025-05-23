﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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
        public static string mSatoAppsLoginUser = "";
        public static string mUserType = "";
        public static SatoLogger AppLog;
        public static string UserName = "";
        public static string UserGroup = "";
        public static string mAccessUser = "";
        public static string mLine = "";
        public static string mLineName = "";
        public static string mParentPart = "";
        public static string mParentPartName = "";
        public static string mChildPart = "";
        public static string mChildPartName = "";
        public static string mShift = "";
        public static string mParentLabelTextEvent = "";
        public static string mChildLabelTextEvent = "";
        public static string mScannerIP = "";
        public static string mPLCIP = "";
        public static int mPLCPort = 0;
        public static int mScannerPort = 1024;
        public static TcpClient mCaseTcpClient;
        public static TcpClient mCaseRejectTcpClient;
        public static TcpClient mPLCTcpClient;
        public static Dictionary<string, string> mdicChildPart = new Dictionary<string, string>();
        public static int mIRunningIndex = 0;
        public static void MesseageInfo(Label label, string sMessage, int icnt)
        {
            if (icnt == 1)
            {
                label.BackColor = Color.Green;
                label.ForeColor = Color.WhiteSmoke;
                label.Text = sMessage;
            }
            else if(icnt==2)
            {
                label.BackColor = Color.Red;
                label.ForeColor = Color.WhiteSmoke;
                label.Text = sMessage;
            }
            else
            {
                label.BackColor = Color.Ivory;
                label.ForeColor = Color.Black;
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
    }
}
