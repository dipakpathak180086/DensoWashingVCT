using COMMON;
using SUM_BL;
using SUM_PL;
using System;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCTWebApp
{
    public partial class VCTDashboardStep3 : System.Web.UI.Page
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
                plObj.Model = ddlModel.SelectedValue;
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
                plObj.Model = ddlModel.SelectedValue;
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
                plObj.Model = ddlModel.SelectedValue;
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
        private void _GetLot()
        {
            try
            {
                DataTable dtLine1 = new DataTable();
                DataTable dtLine2 = new DataTable();
                DataTable DTFinal = new DataTable();
                string lastConstr = CommonHelper.connString;
                BL_VCTDashboard blobj = new BL_VCTDashboard();
                PL_VCTDashboard plobj = new PL_VCTDashboard();
                plobj.DbType = "GET_DASHBOARD_STEP3";
                plobj.Model = ddlModel.SelectedValue;
                plobj.Part = ddlChildPart.SelectedValue;
                plobj.Serai = txtSerial.Text.Trim();
                plobj.Date = txtDate.Text;
                DataTable DT = blobj.ShowDetails(plobj);
                if (DT.Rows.Count > 0)
                {


                    if (DT.Rows[0]["LotNo"].ToString() != "")
                    {
                        Session["GetLot"] = "";
                        Session["GetLot"] = DT.Rows[0]["LotNo"].ToString();
                        if (txtSerial.Text.Trim().StartsWith("1"))
                        {
                            string strLots = "";
                            string[] aArr = new string[DT.Rows.Count];
                            for (int i = 0; i < DT.Rows.Count; i++)
                            {
                                aArr[i] = DT.Rows[i]["LotNo"].ToString();
                                
                            }
                            strLots = string.Join(",", aArr);
                            CommonHelper.connString = ConfigurationManager.ConnectionStrings["CONN_LINE_01"].ConnectionString;
                            dtLine1 = _AfterGettingSuppectedLotData(strLots);
                            //CommonHelper.connString = ConfigurationManager.ConnectionStrings["CONN_LINE_02"].ConnectionString;
                            //dtLine2 = _AfterGettingSuppectedLotData(strLots);
                            //if (dtLine2!=null)
                            //{
                            //    if (dtLine2.Rows.Count > 0)
                            //        dtLine1.Merge(dtLine2);
                            //}
                            //else
                            //{
                            //    CommonHelper.connString = ConfigurationManager.ConnectionStrings["CONN_LINE_01"].ConnectionString;
                            //}
                            DTFinal = dtLine1;
                        }
                        else
                        {
                            string strLots = "";
                            string[] aArr = new string[DT.Rows.Count];
                            for (int i = 0; i < DT.Rows.Count; i++)
                            {
                                aArr[i] =DT.Rows[i]["LotNo"].ToString();

                            }
                            strLots = string.Join(",", aArr);
                            CommonHelper.connString = ConfigurationManager.ConnectionStrings["CONN_LINE_02"].ConnectionString;
                            dtLine2 = _AfterGettingSuppectedLotData(strLots);
                            //CommonHelper.connString = ConfigurationManager.ConnectionStrings["CONN_LINE_01"].ConnectionString;
                            //dtLine1 = _AfterGettingSuppectedLotData(strLots);
                            //if (dtLine1!=null)
                            //{
                            //    if (dtLine1.Rows.Count > 0)
                            //        dtLine2.Merge(dtLine1);
                            //}
                            //else
                            //{
                            //    CommonHelper.connString = ConfigurationManager.ConnectionStrings["CONN_LINE_02"].ConnectionString;
                            //}
                             DTFinal = dtLine2;
                        }
                        CommonHelper.connString = lastConstr;
                    
                        if (DTFinal.Rows.Count > 0)
                        {
                            DivShow.Visible = true;
                            Session["LotNo"] = DTFinal.Rows[0]["LotNo"].ToString();
                            CommonHelper.BindGrid(gvUserMaster, DTFinal);
                            Session["VCTDashboardStep3"] = DTFinal;
                            lblRecords.Text = "No. of Records: " + DTFinal.Rows.Count.ToString();
                        }
                        else
                        {
                            DivShow.Visible = false;
                            CommonHelper.BindGrid(gvUserMaster, null);
                            lblRecords.Text = "No. of Records: " + DTFinal.Rows.Count.ToString();
                            ShowMessageWithUpdatePanel("No Data Found!!!", MessageType.Info);
                        }

                        UpdatePanel1.Update();

                    }
                    else
                    {
                        ShowMessageWithUpdatePanel("No Data Found!!!", MessageType.Info);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No Data Found!!!');", true);
                    }
                }
                else
                {
                    UpdatePanel1.Update();

                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No Data Found!!!');", true);
                    ShowMessageWithUpdatePanel("No Data Found!!!", MessageType.Info);
                    DivShow.Visible = false;
                    CommonHelper.BindGrid(gvUserMaster, null);
                }

            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard _SHOWDETIALS() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
            finally
            {
                // loadingImg.Visible = false;
            }
        }
        private void _SHOWDETIALS()
        {
            try
            {
                BL_VCTDashboard blobj = new BL_VCTDashboard();
                PL_VCTDashboard plobj = new PL_VCTDashboard();
                plobj.DbType = "GET_DASHBOARD";
                plobj.Model = ddlModel.SelectedValue;
                plobj.Part = ddlChildPart.SelectedValue;
                plobj.Serai = txtSerial.Text.Trim();
                plobj.Date = txtDate.Text;
                DataTable DT = blobj.ShowDetails(plobj);
                if (DT.Rows.Count > 0)
                {
                    DivShow.Visible = true;
                    Session["LotNo"] = DT.Rows[0]["LotNo"].ToString();
                    CommonHelper.BindGrid(gvUserMaster, DT);
                    Session["VCTDashboardStep3"] = DT;
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

        private DataTable _AfterGettingSuppectedLotData(string supLotNo)
        {
            DataTable dt = null;
            try
            {
                BL_VCTDashboard blobj = new BL_VCTDashboard();
                PL_VCTDashboard plobj = new PL_VCTDashboard();
                plobj.Model = ddlModel.SelectedValue;
                plobj.Part = ddlChildPart.SelectedValue;
                plobj.LotNo = supLotNo;
                dt = blobj.AfterSubpectedLotDataDetailsForStep3(plobj);

            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard _SHOWDETIALS() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
            return dt;
        }


        private void Reset()
        {
            try
            {
                //lblChildPartName.Text = lblModelName.Text = "XXXXXXXXXXXX";
                getLotNo = "";
                ddlChildPart.SelectedIndex = 0;
                ddlModel.SelectedIndex = 0;
                txtSerial.Text = string.Empty;
                txtDate.Text = "";
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
                if (!txtSerial.Text.Trim().StartsWith(ddlLine.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Entered Serial No not belong to this Line.');", true);
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





        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvUserMaster.Rows.Count > 0)
                {
                    Response.Clear();
                    DataTable dt = (DataTable)Session["VCTDashboardStep3"];

                    objclsExportToCSV.ExportTOCSV(dt, "VCTTraceabilityDataStep3.csv");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert(There is no data for being exported');", true);
                    //ShowMessageWithUpdatePanel("", MessageType.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard btnExport_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        protected void gvVCTDashboard_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvUserMaster.PageIndex = e.NewPageIndex;
                //_SHOWDETIALS();
                _GetLot();
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

                if (e.CommandName == "ShowRow")
                {
                    // Null / empty check + safe parsing
                    if (!string.IsNullOrEmpty(e.CommandArgument?.ToString()))
                    {
                        if (int.TryParse(e.CommandArgument.ToString(), out int index))
                        {
                            if (index >= 0 && index < gvUserMaster.Rows.Count)
                            {
                                // Get the row
                                GridViewRow row = gvUserMaster.Rows[index];

                                // Example: Access cell values
                                string line = row.Cells[0].Text;
                                string shift = row.Cells[1].Text;
                                string modelNo = row.Cells[2].Text;
                                string modelName = row.Cells[3].Text;
                                Session["SelectedLotDate"]=Convert.ToDateTime( row.Cells[9].Text).ToString("yyyy-MM-dd");

                                string strModelName = ddlModel.SelectedItem.Text.Substring(ddlModel.SelectedItem.Text.IndexOf('('));
                                string strChildName = ddlChildPart.SelectedItem.Text.Substring(ddlChildPart.SelectedItem.Text.IndexOf('('));
                                Response.Redirect("~/pages/Transaction/VCTDashboardBackwardTrace.aspx?" +
                                    "Model=" + ddlModel.Text + "&ModelName=" + strModelName
                                    + "&Part=" + ddlChildPart.SelectedValue + "&PartName=" + strChildName
                                   + "&Date=" + txtDate.Text.Trim() + "&Lot=" + Session["GetLot"].ToString()
                                    + "&Serial=" + txtSerial.Text.Trim()
                                    + "&LotDate=" + Session["SelectedLotDate"]);
                            }
                        }
                    }
                    else
                    {
                        // Handle case when CommandArgument is null/blank
                        //lblMessage.Text = "⚠ No row index passed.";
                    }
                }
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
                    //lblModelName.Text = ddlModel.SelectedValue;
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
                    string lastConstr = CommonHelper.connString;

                    //_SHOWDETIALS();
                    //UpdatePanel1.Update();
                    _GetLot();




                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  Default btnReset_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }

        }
        protected void btnShowNG_Click(object sender, EventArgs e)
        {
            try
            {

                if (Session["GetLot"] != null)
                {
                    string strModelName = ddlModel.SelectedItem.Text.Substring(ddlModel.SelectedItem.Text.IndexOf('('));
                    string strChildName = ddlChildPart.SelectedItem.Text.Substring(ddlChildPart.SelectedItem.Text.IndexOf('('));
                    Response.Redirect("~/pages/Transaction/VCTDashboardBackwardTrace.aspx?" +
                        "Model=" + ddlModel.Text + "&ModelName=" + strModelName
                        + "&Part=" + ddlChildPart.SelectedValue + "&PartName=" + strChildName
                       + "&Date=" + txtDate.Text.Trim() + "&Lot=" + Session["GetLot"].ToString()
                        + "&Serial=" + txtSerial.Text.Trim()
                        + "&LotDate=" + Session["SelectedLotDate"]);

                    //Response.Write("<script>window.open('~/pages/Transaction/VCTDashboardForwardTrace.aspx?" +
                    //    "Model=" + ddlModel.Text + "&ModelName=" + lblModelName.Text
                    //    + "&Part=" + ddlChildPart.SelectedValue + "&PartName=" + lblChildPartName.Text
                    //   + "&Date=" + txtDate.Text.Trim() + "&Lot=" + Session["GetLot"].ToString()
                    //    + "&Serial=" + txtSerial.Text.Trim()+"');</script>");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No Data Found!!!');", true);
                }

            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Show NG Lot", ex.Message);
            }
        }

        protected void ddlLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLine.SelectedIndex > 0)
            {
                if (ddlLine.SelectedItem.Selected)
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
}