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
    public partial class VCTDashboardForwardTrace : System.Web.UI.Page
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
                    lblSuspectedLot.Text = Request.QueryString["Lot"];
                    if (_ValidateInput())
                    {
                        _GetLotSummaryData();
                    }

                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  VCTDashboard _Page_Load() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        private void _GetLotSummaryData()
        {
            try
            {
                BL_VCTDashboard blobj = new BL_VCTDashboard();
                PL_VCTDashboard plobj = new PL_VCTDashboard();
                plobj.DbType = "GET_SUMMARY";
                plobj.Model = lblModel.Text;
                plobj.Part = lblChildPart.Text;
                plobj.Serai = lblSerial.Text.Trim();
                plobj.Date = lblDate.Text;
                plobj.LotNo = lblSuspectedLot.Text.Trim();
                DataTable DT = blobj.ShowDetails(plobj);
                if (DT.Rows.Count > 0)
                {
                    DivShow.Visible = true;
                    Session["LotNo"] = lblSuspectedLot.Text.Trim();
                    CommonHelper.BindGrid(dgvDtl, DT);
                    Session["LotSummary"] = DT;
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
                lblSuspectedLot.Text = Request.QueryString["Lot"];

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
                lblModel.Text = lblChildPart.Text = lblDate.Text = lblChildPartName.Text = lblSerial.Text = lblSuspectedLot.Text = lblModelName.Text = "XXXXXXXXXXXX";

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


        protected void dgvDtl_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dgvDtl.PageIndex = e.NewPageIndex;
                _GetLotSummaryData();
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
            try
            {
                if (dgvDtl.Rows.Count > 0)
                {
                    DataTable dataTable = (DataTable)Session["LotSummary"];
                    bool isValidate = false;
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        int iTotalQty = Convert.ToInt32(dataTable.Rows[i][2].ToString());
                        TextBox myTextBox = (TextBox)(dgvDtl.Rows[i].Cells[3].FindControl("txtRejection"));
                        if (!string.IsNullOrEmpty(myTextBox.Text))
                        {
                            if (Convert.ToInt32(myTextBox.Text) > iTotalQty )
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Rejection Qty is greater then actual qty');", true);
                                break;
                            }
                            else
                            {
                                isValidate = true;
                            }

                        }
                        else
                        {
                            isValidate = false;
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Rejection Qty can't be balnk');", true);
                            break;
                        }
                    }
                    if (isValidate)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            int iTotalQty = Convert.ToInt32(dataTable.Rows[i][2].ToString());
                            TextBox myTextBox = (TextBox)(dgvDtl.Rows[i].Cells[3].FindControl("txtRejection"));
                            if (!string.IsNullOrEmpty(myTextBox.Text))
                            {

                                dataTable.Rows[i]["RejectionQty"] = myTextBox.Text;
                                dataTable.AcceptChanges();
                            }

                        }
                        Session["LotSummary"] = dataTable;
                        Response.Redirect("~/pages/Transaction/VCTDashboardBackwardTrace.aspx?" +
                            "Model=" + lblModel.Text + "&ModelName=" + lblModelName.Text
                            + "&Part=" + lblChildPart.Text + "&PartName=" + lblChildPartName.Text
                           + "&Date=" + lblDate.Text.Trim() + "&Lot=" + lblSuspectedLot.Text.Trim()
                            + "&Serial=" + lblSerial.Text.Trim());

                        //Response.Write("<script>window.open('~/pages/Transaction/VCTDashboardForwardTrace.aspx?" +
                        //    "Model=" + ddlModel.Text + "&ModelName=" + lblModelName.Text
                        //    + "&Part=" + ddlChildPart.Text + "&PartName=" + lblChildPartName.Text
                        //   + "&Date=" + txtDate.Text.Trim() + "&Lot=" + Session["GetLot"].ToString()
                        //    + "&Serial=" + txtSerial.Text.Trim()+"');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Show NG Lot", ex.Message);
            }
        }

        protected void dgvDtl_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  UserMaster gvUserMaster_RowCommand ", " User-  " + Session["UserName"] + " " + ex.Message);
            }
        }
    }
}