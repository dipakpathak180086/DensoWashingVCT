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
    public partial class VCTDashboard : System.Web.UI.Page
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
                   
                    UpdatePanel1.Update();
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
                ddlModel.DataTextField = "ModelNo";
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
                    lblModelName.Text = DT.Rows[0][0].ToString();
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
                ddlChildPart.DataTextField = "ChildPartNo";
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
                plObj.Part = ddlChildPart.Text;
                DataTable DT = blObj.ShowDetails(plObj);
                if (DT.Rows.Count > 0)
                {
                    lblChildPartName.Text = DT.Rows[0][0].ToString();
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
                BL_VCTDashboard blobj = new BL_VCTDashboard();
                PL_VCTDashboard plobj = new PL_VCTDashboard();
                plobj.DbType = "GET_DASHBOARD";
                plobj.Model = ddlModel.Text;
                plobj.Part = ddlChildPart.Text;
                plobj.Serai = txtSerial.Text.Trim();
                plobj.Date = txtDate.Text;
                plobj.Rejection = txtRejection.Text == "" ? 0 : Convert.ToInt32(txtRejection.Text.Trim());
                DataTable DT = blobj.ShowDetails(plobj);
                if (DT.Rows.Count > 0)
                {
                    Session["GetLot"] = "";
                    Session["GetLot"] = DT.Rows[0]["LotNo"].ToString();
                }
                
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard _SHOWDETIALS() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }
        private void _SHOWDETIALS()
        {
            try
            {
                BL_VCTDashboard blobj = new BL_VCTDashboard();
                PL_VCTDashboard plobj = new PL_VCTDashboard();
                plobj.DbType = "GET_DASHBOARD";
                plobj.Model = ddlModel.Text;
                plobj.Part = ddlChildPart.Text;
                plobj.Serai = txtSerial.Text.Trim();
                plobj.Date = txtDate.Text;
                plobj.Rejection = txtRejection.Text == "" ? 0 : Convert.ToInt32(txtRejection.Text.Trim());
                DataTable DT = blobj.ShowDetails(plobj);
                if (DT.Rows.Count > 0)
                {
                    DivShow.Visible = true;
                    Session["LotNo"] = DT.Rows[0]["LotNo"].ToString();
                    CommonHelper.BindGrid(gvUserMaster, DT);
                    Session["VCTDashboard"] = DT;
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
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard _SHOWDETIALS() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        private void _GetSerial()
        {
            try
            {
                BL_VCTDashboard blobj = new BL_VCTDashboard();
                PL_VCTDashboard plobj = new PL_VCTDashboard();
                plobj.DbType = "GET_DASHBOARD_SERIAL";
                plobj.Model = ddlModel.Text;
                plobj.Part = ddlChildPart.Text;
                plobj.LotNo = Session["GetLot"].ToString();
                plobj.Date = txtDate.Text;
                plobj.Serai = txtSerial.Text.Trim();
                plobj.Rejection = txtRejection.Text == "" ? 0 : Convert.ToInt32(txtRejection.Text.Trim());
                DataTable DT = blobj.ShowDetails(plobj);
                if (DT.Rows.Count > 0)
                {
                    _SHOWDETIALS();
                    _SHOWDETIALS_2();
                }
                else
                {
                  
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard _SHOWDETIALS() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }
        private void _SHOWDETIALS_2()
        {
            try
            {
                BL_VCTDashboard blobj = new BL_VCTDashboard();
                PL_VCTDashboard plobj = new PL_VCTDashboard();
                plobj.DbType = "GET_DASHBOARD_SERIAL";
                plobj.Model = ddlModel.Text;
                plobj.Part = ddlChildPart.Text;
                plobj.LotNo = Session["LotNo"].ToString();
                plobj.Date = txtDate.Text;
                plobj.Serai = txtSerial.Text.Trim();
                plobj.Rejection = txtRejection.Text == "" ? 0 : Convert.ToInt32(txtRejection.Text.Trim());
                DataTable DT = blobj.ShowDetails(plobj);
                if (DT.Rows.Count > 0)
                {
                    DivShow.Visible = true;
                    CommonHelper.BindGrid(dgvDtl, DT);
                    Session["VCTDashboard2"] = DT;
                }
                else
                {
                    DivShow.Visible = false;
                    CommonHelper.BindGrid(dgvDtl, null);
                }
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
                ddlChildPart.SelectedIndex = 0;
                ddlModel.SelectedIndex = 0;
                txtSerial.Text = string.Empty;
                txtDate.Text = "";
                hidID.Value = string.Empty;
                UpdatePanel1.Update();
                Response.Redirect("~/pages/Transaction/VCTDashboard.aspx");
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
                if (string.IsNullOrEmpty(txtDate.Text.Trim()))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Date');", true);
                    //ShowMessageWithUpdatePanel("Please Select Date", MessageType.Error);

                    return result = false;
                }
                if (string.IsNullOrEmpty(txtSerial.Text.Trim()))
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



        protected void btnExport2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDtl.Rows.Count > 0)
                {
                    Response.Clear();
                    DataTable dt = (DataTable)Session["VCTDashboard2"];

                    objclsExportToCSV.ExportTOCSV(dt, "VCTTraceabilitySerialListData.csv");
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

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvUserMaster.Rows.Count > 0)
                {
                    Response.Clear();
                    DataTable dt = (DataTable)Session["VCTDashboard"];

                    objclsExportToCSV.ExportTOCSV(dt, "VCTTraceabilityLotData.csv");
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
                _SHOWDETIALS_2();
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard gvVCTDashboard_PageIndexChanging() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
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
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard gvVCTDashboard_PageIndexChanging() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
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
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard gvVCTDashboard_RowCommand ", " User-  " + Session["UserName"] + " " + ex.Message);
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
                    lblModelName.Text = ddlModel.SelectedValue;
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
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ValidateInput())
                {
                    _GetLot();
                    if (Session["GetLot"].ToString() != "")
                    {
                        _GetSerial();
                      
                       
                    }
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