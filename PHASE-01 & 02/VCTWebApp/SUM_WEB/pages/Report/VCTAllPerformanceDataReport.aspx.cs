using COMMON;
using SUM_BL;
using SUM_PL;
using System;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCTWebApp
{
    public partial class VCTAllPerformanceDataReport : System.Web.UI.Page
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


                    UpdatePanel1.Update();
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTPerformanceReport _Page_Load() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }


       




        private void _SHOWDETIALS()
        {
            try
            {
                BL_REPORBL_REPORT_ALL_PERFORMANCET_LOG blobj = new BL_REPORBL_REPORT_ALL_PERFORMANCET_LOG();
                PL_REPORT_ALL_PERFORMANCE_DATA plobj = new PL_REPORT_ALL_PERFORMANCE_DATA();
                plobj.DbType = "SELECT_ALL_PERFORMANCE_DATA";
                plobj.Line = ddlLine.Text;
                plobj.FromDate = txtFromDate.Text.Trim();
                plobj.ToDate = txtToDate.Text.Trim();
                plobj.Station = ddlStation.Text.Trim();
                DataTable DT = blobj.ShowDetails(plobj);
                if (DT.Rows.Count > 0)
                {
                    DivShow.Visible = true;
                    Session["VCTPer"] = DT;
                    CommonHelper.BindGrid(gvUserMaster, DT);
                    UpdatePanel1.Update();
                    lblRecords.Text = "No. of Records: " + DT.Rows.Count.ToString();
                }
                else
                {
                    DivShow.Visible = false;
                    CommonHelper.BindGrid(gvUserMaster, null);
                    lblRecords.Text = "No. of Records: " + DT.Rows.Count.ToString();
                    ShowMessageWithUpdatePanel("No Data Found!!!", MessageType.Info);
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTPerformanceReport _SHOWDETIALS() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }


        private void Reset()
        {
            try
            {

                ddlLine.SelectedIndex = 0;
                txtFromDate.Text = "";
                txtToDate.Text = "";
                DivShow.Visible = false;
                CommonHelper.BindGrid(gvUserMaster, null);
                lblRecords.Text = "No. of Records: ";
                //UpdatePanel1.Update();

            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTPerformanceReport _Reset() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }




        private bool _ValidateInput()
        {
            bool result = true;
            ValidateResult _result;
            try
            {

               
                if (ddlLine.SelectedIndex <= 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Line');", true);
                    //ShowMessageWithUpdatePanel("Please Select Date", MessageType.Error);

                    return result = false;
                }
                if (string.IsNullOrEmpty(txtFromDate.Text.Trim()))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select From Date');", true);
                    //ShowMessageWithUpdatePanel("Please Select Date", MessageType.Error);

                    return result = false;
                }
                if (string.IsNullOrEmpty(txtToDate.Text.Trim()))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select To Date');", true);
                    //ShowMessageWithUpdatePanel("Please Select Date", MessageType.Error);

                    return result = false;
                }



            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTPerformanceReport _ValidateInput() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
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
        //        CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTPerformanceReport BtnBack_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
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
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTPerformanceReport btnReset_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }





        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)Session["VCTPer"];
                if (dt.Rows.Count > 0)
                {
                    objclsExportToCSV.ExportTOCSV(dt, "AllPermormanceData.csv");
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
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTPerformanceReport btnExport_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        protected void gvVCTDashboard_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvUserMaster.PageIndex = e.NewPageIndex;
                _SHOWDETIALS();
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTPerformanceReport gvVCTDashboard_PageIndexChanging() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        protected void gvVCTDashboard_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTPerformanceReport gvVCTDashboard_RowCommand ", " User-  " + Session["UserName"] + " " + ex.Message);
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



            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::   ddlModel_SelectedIndexChanged() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }
        protected void ddlChildPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::   ddlChildPart_SelectedIndexChanged() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ValidateInput())
                {
                    _SHOWDETIALS();

                }

            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  Default btnReset_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }

        }

        protected void txtFromDate_TextChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::   ddlChildPart_SelectedIndexChanged() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
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
                    UpdatePanel1.Update();
                }
                else
                {
                    CommonHelper.connString = ConfigurationManager.ConnectionStrings["CONN_LINE_02"].ConnectionString;
                    CommonHelper.connStringLine02 = CommonHelper.connString;
                    UpdatePanel1.Update();
                }

            }
        }
    }
}