using COMMON;
using SUM_BL;
using SUM_PL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using VCTWebApp.pages.Master.UserManagment;

namespace VCTWebApp
{
    public partial class VCTSpecialReport : System.Web.UI.Page
    {
        clsExportToCSV objclsExportToCSV = new clsExportToCSV();
        private string getLotNo = string.Empty;
        private BL_VCT_SpecialReport blObj = null;
        private PL_VCT_SpecialReport plObj = null;
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/Login.aspx?Session=Null");
            }
        }
        public enum MessageType { Success, Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    loadingImg.Visible = false;

                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard _Page_Load() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }


        private void _PopulateModel()
        {
            try
            {
                PL_LOT_ENTRY_REPORT plObj = new PL_LOT_ENTRY_REPORT();
                BL_LOT_ENTRY_REPORT blObj = new BL_LOT_ENTRY_REPORT();
                plObj.DbType = "BIND_MODEL";
                DataTable DT = blObj.ShowDetails(plObj);
                ddlModel.DataSource = DT;
                ddlModel.DataValueField = "ModelNo";
                ddlModel.DataTextField = "ModelName";
                ddlModel.DataBind();
                ddlModel.Items.Insert(0, "--SELECT--");
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
            }
        }

        private void _PopulateModelName()
        {
            try
            {
                PL_LOT_ENTRY_REPORT plObj = new PL_LOT_ENTRY_REPORT();
                BL_LOT_ENTRY_REPORT blObj = new BL_LOT_ENTRY_REPORT();
                plObj.DbType = "BIND_MODEL_NAME";
                plObj.Model = ddlModel.Text;
                DataTable DT = blObj.ShowDetails(plObj);
                if (DT.Rows.Count > 0)
                {
                    // lblModelName.Text = DT.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
            }
        }


        private DataTable _DtBlank()
        {
            DataTable dt = new DataTable();
            try
            {
                PL_VCT_SpecialReport plObj = new PL_VCT_SpecialReport();
                BL_VCT_SpecialReport blObj = new BL_VCT_SpecialReport();

                // plObj.DbType = "GET_LINE_DESTINATION_HIJUNKA_SLOT";
                plObj.FromDate = txtFromDate.Text;
                plObj.ToDate = txtToDate.Text;
                plObj.ModelNo = ddlModel.SelectedValue.ToString();
                dt = blObj.BindBlankdt(plObj);

            }
            catch (Exception ex)
            {

                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  Default _SHOWDETIALS() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
            return dt;
        }
        private DataTable _DtData(DateTime FromDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                PL_VCT_SpecialReport plObj = new PL_VCT_SpecialReport();
                BL_VCT_SpecialReport blObj = new BL_VCT_SpecialReport();
                //  plObj.DbType = "GET_LINE_DESTINATION_HIJUNKA_SLOT";
                plObj.FromDate = FromDate.ToString("yyyy-MM-dd");
                plObj.ModelNo = ddlModel.SelectedValue.ToString();

                dataTable = blObj.BindDataDt(plObj);

            }
            catch (Exception ex)
            {

                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  Default _SHOWDETIALS() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
            return dataTable;
        }



        private void Reset()
        {
            try
            {
                //lblChildPartName.Text = lblModelName.Text = "XXXXXXXXXXXX";
                getLotNo = "";
                ddlLine.SelectedIndex = 0;
                ddlModel.SelectedIndex = 0;
                txtFromDate.Text = txtToDate.Text = string.Empty;
                UpdatePanel1.Update();
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard _Reset() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }


        private bool _ValidateInputLotWise()
        {
            bool result = true;
            ValidateResult _result;
            try
            {
                if (ddlModel.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Model');", true);
                    // ShowMessageWithUpdatePanel("Please Select Model", MessageType.Error);

                    return result = false;
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard _ValidateInput() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
            return result;
        }

        private bool _ValidateInput()
        {
            bool result = true;
            ValidateResult _result;
            try
            {
                if (ddlModel.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Model');", true);
                    // ShowMessageWithUpdatePanel("Please Select Model", MessageType.Error);

                    return result = false;
                }

                if (string.IsNullOrEmpty(txtFromDate.Text.Trim()))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select FromDate');", true);
                    //ShowMessageWithUpdatePanel("Please Select Date", MessageType.Error);

                    return result = false;
                }
                if (string.IsNullOrEmpty(txtToDate.Text.Trim()))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please To Date.');", true);
                    // ShowMessageWithUpdatePanel("Please Serial.", MessageType.Error);

                    return result = false;
                }


            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard _ValidateInput() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
            return result;
        }



        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                Reset();
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard btnReset_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }


        private void ExportGridViewToCSV()
        {
            // Set the response content type and attachment header
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=VCTSpecialReport.csv");
            Response.Charset = "";
            Response.ContentType = "text/csv";

            // Using a StringBuilder to create the CSV data
            StringBuilder sb = new StringBuilder();

            // Loop through GridView columns for header row
            for (int i = 0; i < GridView1.Columns.Count; i++)
            {
                sb.Append(GridView1.Columns[i].HeaderText + ',');
            }
            sb.AppendLine();

            // Loop through each row of the GridView
            foreach (GridViewRow row in GridView1.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    // Append the cell value, use double quotes to handle commas in values
                    sb.Append("\"" + row.Cells[i].Text.Replace("&nbsp;", " ") + "\",");
                }
                sb.AppendLine();
            }

            // Write the CSV data to the response
            Response.Output.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridView1.Rows.Count > 0)
                {
                    Response.Clear();
                    DataTable dt = (DataTable)Session["VCTSpecialReport"];
                    if (dt.Rows.Count > 0)
                        objclsExportToCSV.ExportTOCSV(dt, "VCTSpecialReport.csv");
                }
                else
                {
                    ShowMessageWithUpdatePanel("There is no data for being exported", MessageType.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTLOG btnExport_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }

        }


        protected void ShowMessageWithUpdatePanel(string Message, MessageType type)
        {
            if ((!ClientScript.IsStartupScriptRegistered("JSScript")))
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type.ToString() + "');", true);
        }
        protected void ShowMessage(string Message, MessageType type)
        {
            if ((!ClientScript.IsStartupScriptRegistered("JSScript")))
                ClientScript.RegisterStartupScript(this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type.ToString() + "');", true);
        }

        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlModel.SelectedIndex != 0)
                {
                    //lblModelName.Text = ddlModel.SelectedValue;

                    _PopulateModelName();
                }

            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::   ddlModel_SelectedIndexChanged() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ValidateInputLotWise())
                {

                    int gmaxvalue = 0;
                    DataTable dt0 = new DataTable();
                    DataTable dt2 = new DataTable();

                    dt0 = _DtBlank();


                    DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
                    DateTime toDate = Convert.ToDateTime(txtToDate.Text);

                    //DataColumn newColumn = new DataColumn("SerialNo", typeof(string));

                    //// Add the new column to the DataTable
                    //dt0.Columns.Add(newColumn);

                    DataTable dt = new DataTable();
                    dt = dt0.Copy();
                    dt0.Rows.RemoveAt(0);

                    

                    // Set the new column's position before the first 3 columns (i.e., at index 0)
                    //newColumn.SetOrdinal(2);

                    for (DateTime date = fromDate; date <= toDate; date = date.AddDays(1))
                    {
                        dt2 = _DtData(date);

                        int dtRowsCount = 0;
                        foreach (DataRow row in dt2.Rows)
                        {
                            dtRowsCount++;
                            // Access values by column name or index
                            string ChildPart = (string)row["Child"];
                            string LOT = (string)row["LOT"];
                            string Model = (string)row["Model"];
                            string Date = (string)row["Date"];
                            int LotQty = (int)row["LotQty"];

                            // Value to match
                            string valueToMatch = ChildPart;

                            // Call the method to find the header
                            int matchingHeaderIndex = FindHeaderForValue(dt0, valueToMatch);

                            var results = GetRowMinMaxValueWithIndex(dt);
                            int minIndex = results[0];
                            int minValue = results[1];

                            int maxIndex = results[2];
                            int maxValue = results[3];
                            gmaxvalue = maxValue;

                            int value = GetValueFromDataTable(dt, 0, matchingHeaderIndex, LotQty);
                            results = GetRowMinMaxValueWithIndex(dt);
                            gmaxvalue = results[3];
                            //gmaxvalue = maxValue;
                            string InsertOrUpdate = "";
                            if (dt0.Rows.Count == 0 || (dt0.Rows.Count - 1 < value))
                            {
                                InsertOrUpdate = "Insert";
                            }
                            else if (value <= maxValue)
                            {
                                InsertOrUpdate = "Update";
                            }
                            InsertUpdateRowColumnValue(dt0, value, matchingHeaderIndex, InsertOrUpdate, ChildPart, LOT, Date, Model, LotQty);
                            //if (dt2.Rows.Count == dtRowsCount)
                            //{
                            //    UpdateMaxValue(gmaxvalue, dt);
                            //}
                        }
                        UpdateMaxValue(gmaxvalue, dt);
                        //LoadData();
                    }

                    //DataColumn newColumn = new DataColumn("SerialNo", typeof(string));

                    //// Add the new column to the DataTable
                    //dt0.Columns.Add(newColumn);

                    //// Set the new column's position before the first 3 columns (i.e., at index 0)
                    //newColumn.SetOrdinal(2);

                    //dt0.Columns.Add("SerialNo", typeof(string));
                    //newColumn.SetOrdinal(0);

                    //var serialGeneratorLine2MC1 = new SerialNumberGenerator(21001);
                    //if (ddlLine.SelectedItem.Value.Equals("1"))
                    //{
                    //    serialGeneratorLine2MC1= new SerialNumberGenerator(21001);
                    //}
                    //if (ddlLine.SelectedItem.Value.Equals("2"))
                    //{
                    //    serialGeneratorLine2MC1 = new SerialNumberGenerator(22001);
                    //}

                    //foreach (DataRow row in dt0.Rows)
                    //{
                    //    string Model = row["Model"].ToString();

                    //    string Date = row["Date"].ToString();

                    //    string serial1 = "";

                    //    if (Model != "" && Date != "")
                    //    {
                    //        serial1 = serialGeneratorLine2MC1.GenerateSerialNumber(Model, Convert.ToDateTime(Date), 21, 1);

                    //        row["SerialNo"] = serial1;
                    //        // dt0.Rows[1]["Name"] = "Sara";
                    //    }

                    //}

                   DataTable dtFinal= ChangeColumnIndex(dt0, "SerialNo", 2);

                    Session["VCTSpecialReport"] = dtFinal;
                    lblRecords.Text = "Total Records : " + dtFinal.Rows.Count;
                    CommonHelper.BindGrid(GridView1, dtFinal);
                    //GridView1.DataSource = dt0;
                    //GridView1.DataBind();

                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  Default btnReset_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }

        }
        static DataTable ChangeColumnIndex(DataTable dt, string columnName, int newIndex)
        {
            DataTable newTable = new DataTable();

            // Add columns in the desired order to the new DataTable
            foreach (DataColumn col in dt.Columns)
            {
                if (col.ColumnName == columnName)
                    continue;
                newTable.Columns.Add(col.ColumnName, col.DataType);
            }

            // Add the specific column at the desired new index
            newTable.Columns.Add(columnName, dt.Columns[columnName].DataType);
            newTable.Columns[columnName].SetOrdinal(newIndex);

            // Copy data row by row from the original DataTable to the new one
            foreach (DataRow row in dt.Rows)
            {
                DataRow newRow = newTable.NewRow();
                foreach (DataColumn col in dt.Columns)
                {
                    newRow[col.ColumnName] = row[col.ColumnName];
                }
                newTable.Rows.Add(newRow);
            }

            return newTable;
        }
        //static void ChangeColumnIndex(DataTable dt, string columnName, int newIndex)
        //{
        //    DataColumn column = dt.Columns[columnName];
        //    dt.Columns.Remove(column);  // Remove the column
        //    dt.Columns.Add(column);     // Add it back, which moves it to the end
        //    column.SetOrdinal(newIndex); // Change its ordinal (index)
        //}



        public class RunningNumberGenerator
        {
            private Dictionary<string, int> counters = new Dictionary<string, int>();

            // Generate running number based on model, date, and lot number
            public string GetNextNumber(string model, DateTime date, string lotNo)
            {
                string key = $"{model}-{date.ToString("yyyyMMdd")}-{lotNo}";
                int counter = 0;

                // Check if the key exists, if so, increment the counter
                if (counters.ContainsKey(key))
                {
                    counter = counters[key] + 1;
                }
                else
                {
                    // If the key does not exist, start from 1
                    counter = 1;
                }

                // Store the updated counter
                counters[key] = counter;

                // Generate the running number
                string prefix = (counter % 2 == 1) ? "21" : "22"; // Odd numbers get 21, even get 22
                return $"{prefix}{counter:D4}"; // Example: 210001, 220001
            }
        }

        public class SerialNumberGenerator
        {
            private readonly Dictionary<string, int> _serialNumbers;
            private readonly int _baseSerialNumber;

            public SerialNumberGenerator(int baseSerialNumber)
            {
                _serialNumbers = new Dictionary<string, int>();
                _baseSerialNumber = baseSerialNumber;
            }

            public string GenerateSerialNumber(string model, DateTime date, int line, int machine, string Lot)
            {
                string keyValue = $"{model}_{date:yyyyMMdd}_{line}_{machine}_{Lot}";
                string key = $"{model}_{date:yyyyMMdd}_{line}_{machine}";

                if (!_serialNumbers.ContainsKey(key))
                {
                    // Initialize serial number for a new model-date combination
                    _serialNumbers[key] = _baseSerialNumber;
                }
                else
                {
                    // Increment serial number for the existing model-date combination
                    _serialNumbers[key]++;
                }

                // Format the serial number
                return $"{line}{machine:00}{_serialNumbers[key]:0000}";
            }
        }

        private void UpdateMaxValue(int maxValue, DataTable dt)
        {
            DataRow row = dt.Rows[0];
            for (int columnIndex = 0; columnIndex < dt.Columns.Count; columnIndex++)
            {
                row[columnIndex] = maxValue;
            }
        }

        static int GetValueFromDataTable(DataTable dataTable, int rowIndex, int columnIndex, int LotQty)
        {
            // Ensure the indices are within the bounds of the DataTable
            // Ensure the indices are within the bounds of the DataTable
            if (rowIndex < dataTable.Rows.Count && columnIndex < dataTable.Columns.Count)
            {
                object currentValue = dataTable.Rows[rowIndex][columnIndex];
                currentValue = Convert.ToInt32(currentValue.ToString());
                if (currentValue is int)
                {
                    // Increment the value by 1
                    // dataTable.Rows[rowIndex][columnIndex] = (int)currentValue + 1;
                    dataTable.Rows[rowIndex][columnIndex] = (int)currentValue + LotQty;
                }
                return Convert.ToInt32(currentValue);
                //return Convert.ToInt32(dataTable.Rows[rowIndex][columnIndex]);
            }
            else
            {
                return -1;
            }
        }
        static int FindHeaderForValue(DataTable dataTable, string valueToMatch)
        {
            int columnIndex = -1;
            foreach (DataColumn column in dataTable.Columns)
            {
                columnIndex = columnIndex + 1;
                if (column.ColumnName == valueToMatch)
                {
                    break;
                }
            }
            return columnIndex;
        }
        private static int[] GetRowMinMaxValueWithIndex(DataTable dt)
        {
            int minValue = int.MaxValue;
            int maxValue = int.MinValue;
            int minIndex = -1;
            int maxIndex = -1;
            foreach (DataRow row in dt.Rows)
            {
                int[] numbers = new int[row.ItemArray.Length];

                // Copy values, assuming the relevant columns contain integers
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    numbers[i] = Convert.ToInt32(row.ItemArray[i]);
                }
                // Loop through the array
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] < minValue)
                    {
                        minValue = numbers[i];
                        minIndex = i;
                    }
                    if (numbers[i] > maxValue)
                    {
                        maxValue = numbers[i];
                        maxIndex = i;
                    }
                }
            }
            int[] result = { minIndex, minValue, maxIndex, maxValue };
            return result;
        }

        private static void InsertUpdateRowColumnValue(DataTable table, int row, int index, string InsertUpdate, string ChildPart, string LotValue, string sDate, string sModel, int lotQty)
        {
           // var serialGeneratorLine2MC1 = new SerialNumberGenerator(21001);
            RunningNumberGenerator generator = new RunningNumberGenerator();

            for (int i = 0; i < lotQty; i++)
            {
                // Create a new row
                if (InsertUpdate == "Insert")
                {
                    DataRow newRow = table.NewRow();

                    foreach (DataColumn column in table.Columns)
                    {
                        newRow[column] = DBNull.Value;
                    }
                    // Add the new row to the DataTable
                    table.Rows.Add(newRow);
                    DataRow rowToUpdates = null;
                    if (i == 0)
                    {
                        rowToUpdates = table.Rows[row];
                    }
                    else
                    {
                        rowToUpdates = table.Rows[row + i];
                    }
                    //DataRow rowToUpdates = table.Rows[row+i];
                    rowToUpdates[ChildPart] = LotValue;
                    rowToUpdates["Date"] = sDate;
                    rowToUpdates["Model"] = sModel;

                    string serial1 = generator.GetNextNumber(sModel, Convert.ToDateTime(sDate), LotValue);// serialGeneratorLine2MC1.GenerateSerialNumber(sModel, Convert.ToDateTime(sDate), 21, 1, LotValue);
                    rowToUpdates["SerialNo"] = serial1;

                }
                else if (InsertUpdate == "Update")
                {
                    DataRow rowToUpdates = null;
                    if (i == 0)
                    {
                        rowToUpdates = table.Rows[row];
                    }
                    else
                    {
                        rowToUpdates = table.Rows[row + i];
                    }
                    rowToUpdates[ChildPart] = LotValue;
                    // rowToUpdates["Date"] = "12-10-2024";
                    //rowToUpdates["Model"] = "XXX";
                }
            }
        }
        string previousLastCategoryDate = "";
        string previousLastCategoryModel = "";

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Get the current row's category
                string currentCategoryDate = e.Row.Cells[1].Text;
                string currentCategoryModel = e.Row.Cells[0].Text;
                // Check if this is the first data row
                if (e.Row.RowIndex > 0)
                {
                    // Get the previous row's category
                    string previousCategoryDate = GridView1.Rows[e.Row.RowIndex - 1].Cells[1].Text;
                    string previousCategoryModel = GridView1.Rows[e.Row.RowIndex - 1].Cells[0].Text;
                    // If the categories match, hide the current category cell
                    if (currentCategoryDate == previousCategoryDate || previousLastCategoryDate == currentCategoryDate)
                    {
                        previousLastCategoryDate = currentCategoryDate;
                        //e.Row.Cells[0].Visible = false;
                        e.Row.Cells[1].Text = "";
                    }
                    else
                    {
                        // Otherwise, set the rowspan for the previous row's cell
                        //GridView2.Rows[e.Row.RowIndex - 1].Cells[0].Attributes["rowspan"] =
                        //  (Convert.ToInt32(GridView1.Rows[e.Row.RowIndex - 1].Cells[0].Attributes["rowspan"] ?? "1") + 1).ToString();
                    }
                    if (currentCategoryModel == previousCategoryModel || previousLastCategoryModel == currentCategoryModel)
                    {
                        previousLastCategoryModel = currentCategoryModel;
                        //e.Row.Cells[0].Visible = false;
                        e.Row.Cells[0].Text = "";
                    }
                    else { }
                }
                else
                {
                    // First row; initialize rowspan
                    //e.Row.Cells[0].Attributes["rowspan"] = "1";
                }
            }
        }


        protected void ddlLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLine.SelectedIndex > 0)
            {
                if (ddlLine.SelectedItem.Value.Equals("1"))
                {
                    CommonHelper.connString = ConfigurationManager.ConnectionStrings["CONN_LINE_01"].ConnectionString;
                    CommonHelper.connStringLine01 = CommonHelper.connString;
                    _PopulateModel();

                    UpdatePanel1.Update();
                }
                else
                {
                    CommonHelper.connString = ConfigurationManager.ConnectionStrings["CONN_LINE_02"].ConnectionString;
                    CommonHelper.connStringLine02 = CommonHelper.connString;
                    _PopulateModel();

                    UpdatePanel1.Update();
                }

            }
        }


    }
}