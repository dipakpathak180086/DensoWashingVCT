using COMMON;
using SUM_BL;
using SUM_PL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCTWebApp
{
    public partial class VCTDashboardBackwardTrace : System.Web.UI.Page
    {
        clsExportToCSV objclsExportToCSV = new clsExportToCSV();
        private string getLotNo = string.Empty;
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
                    _PopulateModel();
                    _PopulateModelName();
                    _PopulatePart();
                    _PopulatePartName();
                    lblDate.Text = Request.QueryString["Date"];
                    lblSerial.Text = Request.QueryString["Serial"];
                    // lblSuspectedLot.Text = Request.QueryString["Lot"];
                    if (_ValidateInput())
                    {
                        _GetSerialSummaryDataFinal();
                    }

                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard _Page_Load() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }
        private DataTable GetSerialSummaryData()
        {
            DataTable dt = null;
            try
            {
                BL_VCTDashboard blobj = new BL_VCTDashboard();
                PL_VCTDashboard plobj = new PL_VCTDashboard();
                plobj.DbType = "GET_DASHBOARD_SERIAL";
                plobj.Model = lblModel.Text;
                plobj.Part = lblChildPart.Text;
                plobj.Serai = lblSerial.Text.Trim();
                plobj.Date = lblDate.Text;
                plobj.LotNo = Request.QueryString["Lot"];
                dt = blobj.ShowDetails(plobj);


            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard _Page_Load() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
            return dt;
        }
        private void _GetSerialSummaryDataFinal()
        {
            try
            {
                DataTable dtLine1 = new DataTable();
                DataTable dtLine2 = new DataTable();
                DataTable DTFinal = new DataTable();
                string lastConstr = CommonHelper.connString;

                if (lblSerial.Text.Trim().StartsWith("1"))
                {
                    CommonHelper.connString = ConfigurationManager.ConnectionStrings["CONN_LINE_01"].ConnectionString;
                    dtLine1 = GetSerialSummaryData();
                    CommonHelper.connString = ConfigurationManager.ConnectionStrings["CONN_LINE_02"].ConnectionString;
                    dtLine2 = GetSerialSummaryData();
                    if (dtLine2 != null)
                    {
                        if (dtLine2.Rows.Count >0)
                            dtLine1.Merge(dtLine2);
                    }
                    else
                    {
                        CommonHelper.connString = ConfigurationManager.ConnectionStrings["CONN_LINE_01"].ConnectionString;
                    }
                    DTFinal = dtLine1;
                }
                else
                {
                    CommonHelper.connString = ConfigurationManager.ConnectionStrings["CONN_LINE_02"].ConnectionString;
                    dtLine2 = GetSerialSummaryData();
                    CommonHelper.connString = ConfigurationManager.ConnectionStrings["CONN_LINE_01"].ConnectionString;
                    dtLine1 = GetSerialSummaryData();
                    if (dtLine1 != null)
                    {
                        if (dtLine1.Rows.Count > 0)
                            dtLine2.Merge(dtLine1);
                    }
                    else
                    {
                        CommonHelper.connString = ConfigurationManager.ConnectionStrings["CONN_LINE_02"].ConnectionString;
                    }
                    DTFinal = dtLine2;
                }
                CommonHelper.connString = lastConstr;
                if (DTFinal.Rows.Count > 0)
                {

                    DivShow.Visible = true;
                    //  Session["LotNo"] = lblSuspectedLot.Text.Trim();
                    CommonHelper.BindGrid(dgvDtl, DTFinal);
                    Session["VCTDashboard2"] = DTFinal;

                }
                else
                {
                    DivShow.Visible = true;
                    CommonHelper.BindGrid(dgvDtl, null);
                    ShowMessageWithUpdatePanel("No Data Found!!!", MessageType.Info);
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
            }
        }

        private void _PopulateModel()
        {
            try
            {
                lblModel.Text = Request.QueryString["Model"];
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
                lblModelName.Text = Request.QueryString["ModelName"];
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
            }
        }

        private void _PopulatePart()
        {
            try
            {
                lblChildPart.Text = Request.QueryString["Part"];
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
            }
        }
        private void _PopulatePartName()
        {
            try
            {
                lblChildPartName.Text = Request.QueryString["PartName"];
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
            }
        }
        private void _GetLot()
        {
            try
            {
                // lblSuspectedLot.Text = Request.QueryString["Lot"];

            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard _SHOWDETIALS() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }





        private void Reset()
        {
            try
            {
                getLotNo = "";
                lblModel.Text = lblChildPart.Text = lblDate.Text = lblChildPartName.Text = lblSerial.Text = lblModelName.Text = "XXXXXXXXXXXX";

                hidID.Value = string.Empty;
                UpdatePanel1.Update();
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard _Reset() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }




        private bool _ValidateInput()
        {
            bool result = true;
            ValidateResult _result;
            try
            {
                //if (ddlModel.SelectedIndex == 0)
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Model');", true);
                //   // ShowMessageWithUpdatePanel("Please Select Model", MessageType.Error);

                //    return result = false;
                //}
                //if (ddlChildPart.SelectedIndex == 0)
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Child');", true);
                //    //ShowMessageWithUpdatePanel("Please Select Child", MessageType.Error);

                //    return result = false;
                //}
                //if (string.IsNullOrEmpty(txtDate.Text.Trim()))
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Date');", true);
                //    //ShowMessageWithUpdatePanel("Please Select Date", MessageType.Error);

                //    return result = false;
                //}
                //if (string.IsNullOrEmpty(txtSerial.Text.Trim()))
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Serial.');", true);
                //   // ShowMessageWithUpdatePanel("Please Serial.", MessageType.Error);

                //    return result = false;
                //}

            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard _ValidateInput() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
            return result;
        }

        //protected void BtnBack_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Response.Redirect("~/Default.aspx");
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
        //        CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard BtnBack_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
        //    }
        //}

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


        protected void BtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/pages/Transaction/VCTDashboard.aspx");
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  GroupRights _BtnBack_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }

        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDtl.Rows.Count > 0)
                {
                    Response.Clear();
                    DataTable dt = (DataTable)Session["VCTDashboard2"];
                    DataTable dtFinal = dt.AsDataView().ToTable(true, "Line", "Station", "Date", "Lot", "Serial");
                    objclsExportToCSV.ExportTOCSV(dtFinal, "SerialListData.csv");
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
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard btnExport_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }


        protected void dgvDtl_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dgvDtl.PageIndex = e.NewPageIndex;
                _GetSerialSummaryDataFinal();
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard gvVCTDashboard_PageIndexChanging() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
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


        protected void btnShowBackTrace_Click(object sender, EventArgs e)
        {

        }
    }
}