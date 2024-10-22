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
    public partial class VCTPerformanceReport : System.Web.UI.Page
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

                    //_PopulateLine();
                    UpdatePanel1.Update();
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTPerformanceReport _Page_Load() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }


        private void _PopulateLine()
        {
            try
            {
                PL_REPORT_PERFORMANCE plObj = new PL_REPORT_PERFORMANCE();
                BL_REPORT_PERFORMANCE blObj = new BL_REPORT_PERFORMANCE();
                plObj.DbType = "BIND_LINE";
                plObj.FileDate = txtFileDate.Text.Trim();
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
                PL_REPORT_PERFORMANCE plObj = new PL_REPORT_PERFORMANCE();
                BL_REPORT_PERFORMANCE blObj = new BL_REPORT_PERFORMANCE();
                plObj.DbType = "BIND_STATION";
                plObj.FileDate = txtFileDate.Text.Trim();
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
        private void _PopulatePart()
        {
            try
            {
                PL_REPORT_PERFORMANCE plObj = new PL_REPORT_PERFORMANCE();
                BL_REPORT_PERFORMANCE blObj = new BL_REPORT_PERFORMANCE();
                plObj.DbType = "BIND_PART";
                plObj.FileDate = txtFileDate.Text.Trim();
                plObj.Line = ddlLine.Text.Trim();
                plObj.Station = ddlStation.Text.Trim();
                DataTable DT = blObj.ShowDetails(plObj);
                ddlPart.DataSource = DT;
                ddlPart.DataValueField = "Model";
                ddlPart.DataTextField = "Model";
                ddlPart.DataBind();
                ddlPart.Items.Insert(0, "--SELECT--");
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
                BL_REPORT_PERFORMANCE blobj = new BL_REPORT_PERFORMANCE();
                PL_REPORT_PERFORMANCE plobj = new PL_REPORT_PERFORMANCE();
                plobj.DbType = "SELECT";
                plobj.Line = ddlLine.Text;
                plobj.Station = ddlStation.Text;
                plobj.FileDate = txtFileDate.Text.Trim();
                plobj.Part = ddlPart.Text;
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
                ddlPart.SelectedIndex = 0;
                ddlStation.SelectedIndex = 0;
                txtFileDate.Text = "";
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
                
                if (string.IsNullOrEmpty(txtFileDate.Text.Trim()))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select File Date');", true);
                    //ShowMessageWithUpdatePanel("Please Select Date", MessageType.Error);

                    return result = false;
                }
                if (ddlLine.SelectedIndex<=0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Line');", true);
                    //ShowMessageWithUpdatePanel("Please Select Date", MessageType.Error);

                    return result = false;
                }
                if (ddlStation.SelectedIndex <= 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Station');", true);
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
                if (gvUserMaster.Rows.Count > 0)
                {
                    Response.Clear();
                    //DataTable dt = (DataTable)Session["VCTPer"];

                    BL_REPORT_PERFORMANCE blobj = new BL_REPORT_PERFORMANCE();
                    PL_REPORT_PERFORMANCE plobj = new PL_REPORT_PERFORMANCE();
                    plobj.DbType = "SELECT_EXPORT";
                    plobj.Line = ddlLine.Text;
                    plobj.Station = ddlStation.Text;
                    plobj.FileDate = txtFileDate.Text.Trim();
                    plobj.Part = ddlPart.Text;
                    DataTable DT = blobj.ShowDetails(plobj);
                    if (DT.Rows.Count > 0)
                    {
                        objclsExportToCSV.ExportTOCSV(DT, "VCTPermormanceData.csv");

                    }

                  
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

        protected void txtFileDate_TextChanged(object sender, EventArgs e)
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

        protected void ddlStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlStation.SelectedIndex > 0)
                {
                    _PopulatePart();
                }

            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::   ddlChildPart_SelectedIndexChanged() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }

        }

        protected void ddlLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlLine.SelectedIndex > 0)
                {
                    if (ddlLine.SelectedItem.Value.Equals("1"))
                    {
                        CommonHelper.connString = ConfigurationManager.ConnectionStrings["CONN_LINE_01"].ConnectionString;
                        CommonHelper.connStringLine01 = CommonHelper.connString;
                        _PopulateSation();

                        UpdatePanel1.Update();
                    }
                    else
                    {
                        CommonHelper.connString = ConfigurationManager.ConnectionStrings["CONN_LINE_02"].ConnectionString;
                        CommonHelper.connStringLine02 = CommonHelper.connString;
                        _PopulateSation();

                        UpdatePanel1.Update();
                    }
                   
                }

            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::   ddlChildPart_SelectedIndexChanged() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
          
        }
    }
}