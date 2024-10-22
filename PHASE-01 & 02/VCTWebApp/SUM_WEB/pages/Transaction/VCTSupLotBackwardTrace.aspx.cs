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
using VCTWebApp.pages.Master.UserManagment;

namespace VCTWebApp
{
    public partial class VCTSupLotBackwardTrace : System.Web.UI.Page
    {
        clsExportToCSV objclsExportToCSV = new clsExportToCSV();
        private string getLotNo = string.Empty;
        DataTable DTFinal = new DataTable();
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

                    // lblSuspectedLot.Text = Request.QueryString["Lot"];
                   

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
                PL_VCTDashboard plObj = new PL_VCTDashboard();
                BL_VCTDashboard blObj = new BL_VCTDashboard();
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
                PL_VCTDashboard plObj = new PL_VCTDashboard();
                BL_VCTDashboard blObj = new BL_VCTDashboard();
                plObj.DbType = "BIND_MODEL_NAME";
                plObj.Model = ddlModel.Text;
                DataTable DT = blObj.ShowDetails(plObj);
                if (DT.Rows.Count > 0)
                {
                    //lblModelName.Text = DT.Rows[0][0].ToString();
                }
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
                PL_VCTDashboard plObj = new PL_VCTDashboard();
                BL_VCTDashboard blObj = new BL_VCTDashboard();
                plObj.DbType = "BIND_PART";
                plObj.Model = ddlModel.Text;
                DataTable DT = blObj.ShowDetails(plObj);
                ddlChildPart.DataSource = DT;
                ddlChildPart.DataValueField = "ChildPartNo";
                ddlChildPart.DataTextField = "ChildPartName";
                ddlChildPart.DataBind();
                ddlChildPart.Items.Insert(0, "--SELECT--");
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
                PL_VCTDashboard plObj = new PL_VCTDashboard();
                BL_VCTDashboard blObj = new BL_VCTDashboard();
                plObj.DbType = "BIND_PART_NAME";
                plObj.Model = ddlModel.Text;
                plObj.Part = ddlChildPart.SelectedValue;
                DataTable DT = blObj.ShowDetails(plObj);
                if (DT.Rows.Count > 0)
                {
                    //lblChildPartName.Text = DT.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
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
                plobj.Model = ddlModel.Text;
                plobj.Part = ddlChildPart.SelectedValue;
                plobj.Serai = "";
                plobj.Date = "";
                plobj.LotNo = txtEnterLot.Text.Trim();
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
               
                string lastConstr = CommonHelper.connString;

                if (ddlLine.Text.Trim().StartsWith("1"))
                {
                    CommonHelper.connString = ConfigurationManager.ConnectionStrings["CONN_LINE_01"].ConnectionString;
                    DTFinal = GetSerialSummaryData();
                   
                }
                else
                {
                    CommonHelper.connString = ConfigurationManager.ConnectionStrings["CONN_LINE_02"].ConnectionString;
                    DTFinal = GetSerialSummaryData();
                    
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
                if (ddlChildPart.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Child');", true);
                    //ShowMessageWithUpdatePanel("Please Select Child", MessageType.Error);

                    return result = false;
                }

                if (string.IsNullOrEmpty(txtEnterLot.Text.Trim()))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Serial.');", true);
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


        private void Reset()
        {
            try
            {
                //lblChildPartName.Text = lblModelName.Text = "XXXXXXXXXXXX";
                getLotNo = "";
                ddlChildPart.SelectedIndex = 0;
                ddlModel.SelectedIndex = 0;
                txtEnterLot.Text = string.Empty;
                UpdatePanel1.Update();

                hidID.Value = string.Empty;
                UpdatePanel1.Update();
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard _Reset() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlModel.SelectedIndex != 0)
                {
                   // lblModelName.Text = ddlModel.SelectedValue;
                    _PopulatePart();
                    _PopulateModelName();
                }

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

                if (ddlChildPart.SelectedIndex != 0)
                {
                    _PopulatePartName();
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


        protected void btnShowNG_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ValidateInput())
                {
                    _GetSerialSummaryDataFinal();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}