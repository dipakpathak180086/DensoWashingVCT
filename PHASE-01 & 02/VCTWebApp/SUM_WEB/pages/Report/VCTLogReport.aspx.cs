using COMMON;
using SUM_BL;
using SUM_PL;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCTWebApp
{
    public partial class VCTLogReport : System.Web.UI.Page
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
                    _PopulateLine();
                    _PopulateSation();
                    _PopulateProcess();

                    UpdatePanel1.Update();
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTLOG _Page_Load() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }


        private void _PopulateLine()
        {
            try
            {
                PL_REPORT_LOG plObj = new PL_REPORT_LOG();
                BL_REPORT_LOG blObj = new BL_REPORT_LOG();
                plObj.DbType = "BIND_LINE";
                DataTable DT = blObj.ShowDetails(plObj);
                ddlLine.DataSource = DT;
                ddlLine.DataValueField = "LINE";
                ddlLine.DataTextField = "LINE1";
                ddlLine.DataBind();
                ddlLine.Items.Insert(0, "--SELECT--");
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
            }
        }
        private void _PopulateSation()
        {
            try
            {
                PL_REPORT_LOG plObj = new PL_REPORT_LOG();
                BL_REPORT_LOG blObj = new BL_REPORT_LOG();
                plObj.DbType = "BIND_STATION";
                DataTable DT = blObj.ShowDetails(plObj);
                ddlStation.DataSource = DT;
                ddlStation.DataValueField = "Station";
                ddlStation.DataTextField = "Station";
                ddlStation.DataBind();
                ddlStation.Items.Insert(0, "--SELECT--");
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
            }
        }
        private void _PopulateProcess()
        {
            try
            {
                PL_REPORT_LOG plObj = new PL_REPORT_LOG();
                BL_REPORT_LOG blObj = new BL_REPORT_LOG();
                plObj.DbType = "BIND_PROCESS";
                DataTable DT = blObj.ShowDetails(plObj);
                ddlPorcess.DataSource = DT;
                ddlPorcess.DataValueField = "Process";
                ddlPorcess.DataTextField = "Process";
                ddlPorcess.DataBind();
                ddlPorcess.Items.Insert(0, "--SELECT--");
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
            }
        }


        private void _SHOWDETIALS()
        {
            try
            {
                BL_REPORT_LOG blobj = new BL_REPORT_LOG();
                PL_REPORT_LOG plobj = new PL_REPORT_LOG();
                plobj.DbType = "SELECT";
                plobj.Line = ddlLine.Text;
                plobj.Station = ddlStation.Text;
                plobj.Process = ddlPorcess.Text.Trim();
                plobj.FromDate = txtFromDate.Text;
                plobj.ToDate = txtToDate.Text;
                DataTable DT = blobj.ShowDetails(plobj);
                if (DT.Rows.Count > 0)
                {
                    DivShow.Visible = true;
                    Session["VCTLog"] = DT;
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
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTLOG _SHOWDETIALS() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }


        private void Reset()
        {
            try
            {

                ddlLine.SelectedIndex = 0;
                ddlPorcess.SelectedIndex = 0;
                ddlStation.SelectedIndex = 0;
                txtFromDate.Text = "";
                txtToDate.Text = "";
                DivShow.Visible = false;
                CommonHelper.BindGrid(gvUserMaster, null);
                lblRecords.Text = "No. of Records: ";
              //  UpdatePanel1.Update();

            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTLOG _Reset() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }




        private bool _ValidateInput()
        {
            bool result = true;
            ValidateResult _result;
            try
            {

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
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTLOG _ValidateInput() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
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
        //        CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTLOG BtnBack_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
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
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTLOG btnReset_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }





        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvUserMaster.Rows.Count > 0)
                {
                    Response.Clear();
                    DataTable dt = (DataTable)Session["VCTLOG"];
                    if (dt.Rows.Count > 0)
                        objclsExportToCSV.ExportTOCSV(dt, "VCTLogReport.csv");
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
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTLOG gvVCTDashboard_PageIndexChanging() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
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
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTLOG gvVCTDashboard_RowCommand ", " User-  " + Session["UserName"] + " " + ex.Message);
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

    }
}