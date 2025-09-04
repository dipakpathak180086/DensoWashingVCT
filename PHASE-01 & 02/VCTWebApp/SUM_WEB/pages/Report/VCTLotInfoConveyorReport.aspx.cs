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
    public partial class VCTLotInfoConveyorReport : System.Web.UI.Page
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


        //private void _PopulateModel()
        //{
        //    try
        //    {
        //        PL_LOT_INFO_CONVEYOR_ASSY_REPORT plObj = new PL_LOT_INFO_CONVEYOR_ASSY_REPORT();
        //        BL_LOT_INFO_CONVEYOR_ASSY_REPORT blObj = new BL_LOT_INFO_CONVEYOR_ASSY_REPORT();
        //        plObj.DbType = "BIND_MODEL";
        //        DataTable DT = blObj.ShowDetails(plObj);
        //        ddlStation.DataSource = DT;
        //        ddlStation.DataValueField = "ModelNo";
        //        ddlStation.DataTextField = "ModelName";
        //        ddlStation.DataBind();
        //        ddlStation.Items.Insert(0, "--SELECT--");
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
        //    }
        //}

        //private void _PopulateModelName()
        //{
        //    try
        //    {
        //        PL_LOT_INFO_CONVEYOR_ASSY_REPORT plObj = new PL_LOT_INFO_CONVEYOR_ASSY_REPORT();
        //        BL_LOT_INFO_CONVEYOR_ASSY_REPORT blObj = new BL_LOT_INFO_CONVEYOR_ASSY_REPORT();
        //        plObj.DbType = "BIND_MODEL_NAME";
        //        plObj.ModelNo = ddlStation.SelectedValue;
        //        DataTable DT = blObj.ShowDetails(plObj);
        //        if (DT.Rows.Count > 0)
        //        {
        //            //lblModelName.Text = DT.Rows[0][0].ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
        //    }
        //}

        //private void _PopulatePart()
        //{
        //    try
        //    {
        //        PL_LOT_ENTRY_REPORT plObj = new PL_LOT_ENTRY_REPORT();
        //        BL_LOT_ENTRY_REPORT blObj = new BL_LOT_ENTRY_REPORT();
        //        plObj.DbType = "BIND_PART";
        //        plObj.Model = ddlStation.SelectedValue;
        //        DataTable DT = blObj.ShowDetails(plObj);
        //        ddlChildPart.DataSource = DT;
        //        ddlChildPart.DataValueField = "ChildPartNo";
        //        ddlChildPart.DataTextField = "ChildPartName";
        //        ddlChildPart.DataBind();
        //        ddlChildPart.Items.Insert(0, "--SELECT--");
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
        //    }
        //}
        private void _GetReportData()
        {
            try
            {
                DataTable dtLine1 = new DataTable();
                DataTable dtLine2 = new DataTable();
                DataTable DTFinal = new DataTable();
                string lastConstr = CommonHelper.connString;
                BL_LOT_INFO_CONVEYOR_ASSY_REPORT blobj = new BL_LOT_INFO_CONVEYOR_ASSY_REPORT();
                PL_LOT_INFO_CONVEYOR_ASSY_REPORT plobj = new PL_LOT_INFO_CONVEYOR_ASSY_REPORT();
                plobj.DbType = "REPORT";
                plobj.Line = ddlLine.SelectedValue.Trim();
                plobj.Station = lstConveyor.DataTextField;
                plobj.FromDate = txtFromDate.Text;
                plobj.ToDate = txtToDate.Text;
                DataTable DT = blobj.ShowDetails(plobj);
                if (DT.Rows.Count > 0)
                {

                    DivShow.Visible = true;
                    CommonHelper.BindGrid(gvUserMaster, DT);
                    Session["VCTLotInfoChildReport"] = DT;
                    lblRecords.Text = "No. of Records: " + DT.Rows.Count.ToString();
                    UpdatePanel1.Update();
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
    

    


        private void Reset()
        {
            try
            {
                //lblChildPartName.Text = lblModelName.Text = "XXXXXXXXXXXX";
                getLotNo = "";
               // ddlStation.SelectedIndex=ddlChildPart.SelectedIndex = 0;
                
                txtFromDate.Text=txtToDate.Text = "";
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
                if (ddlLine.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Line');", true);
                    // ShowMessageWithUpdatePanel("Please Select Model", MessageType.Error);

                    return result = false;
                }
                //if (ddlStation.SelectedIndex == 0)
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Model');", true);
                //    // ShowMessageWithUpdatePanel("Please Select Model", MessageType.Error);

                //    return result = false;
                //}
                //if (ddlChildPart.SelectedIndex == 0)
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Child Part');", true);
                //    // ShowMessageWithUpdatePanel("Please Select Model", MessageType.Error);

                //    return result = false;
                //}
                if (string.IsNullOrEmpty(txtFromDate.Text.Trim()))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please From Date');", true);
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
                    DataTable dt = (DataTable)Session["VCTChildPartAssy"];

                    objclsExportToCSV.ExportTOCSV(dt, "VCTChildPartAssyStep3.csv");
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
                _GetReportData();
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

        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        
       
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                if (_ValidateInput())
                {
                    string lastConstr = CommonHelper.connString;
                    
                    _GetReportData();




                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  Default btnReset_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
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
                        //_PopulateModel();

                        UpdatePanel1.Update();
                    }
                    else
                    {
                        CommonHelper.connString = ConfigurationManager.ConnectionStrings["CONN_LINE_02"].ConnectionString;
                        CommonHelper.connStringLine02 = CommonHelper.connString;
                       // _PopulateModel();

                        UpdatePanel1.Update();
                    }
                }

            }
        }
    }
}