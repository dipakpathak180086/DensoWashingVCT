using COMMON;
using SUM_BL;
using SUM_PL;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCTWebApp.pages.Master.UserManagment
{
    public partial class GroupMaster : System.Web.UI.Page
    {
        clsExportToCSV objclsExportToCSV = new clsExportToCSV();
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
                    txtGroupName.Focus();
                    _SHOWDETIALS();
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  GroupMaster Page_Load() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        #region Page Functions

        private void _SHOWDETIALS()
        {
            try
            {
                BL_GroupMaster blobj = new BL_GroupMaster();
                PL_GroupMaster plobj = new PL_GroupMaster();
                DataTable DT = blobj.ShowDetails(plobj);
                Session["GroupMaster"] = DT;
                CommonHelper.BindGrid(grdDispaly, DT);
                UpdatePanel1.Update();
                lblRecords.Text = "No. of Records: " + DT.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  GroupMaster _SHOWDETIALS() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        private void Reset()
        {
            try
            {
  
                txtGroupName.Text = string.Empty;
                btnsave.Text = "Save";

                hidID.Value = string.Empty;
                txtGroupName.Focus();
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  GroupMaster Reset() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        private void _DeleteRecords(string sGroupID)
        {
            try
            {
                try
                {
                    if ((Session["Group"].ToString().ToUpper()) == "ADMIN")
                    {
                        Reset();
                        BL_GroupMaster oBL = new BL_GroupMaster();
                        PL_GroupMaster oPL = new PL_GroupMaster();
                        oPL.GroupID = sGroupID;
                        DataTable dt = oBL.CheckTransation(oPL);
                        if (dt.Rows.Count == 0)
                        {
                            OperationResult oResult = oBL.Delete(oPL);
                            if (oResult == OperationResult.DeleteSuccess)
                            {
                                _SHOWDETIALS();
                                ShowMessageWithUpdatePanel("Record Deleted Successfully.", MessageType.Success);
                            }
                            else if (oResult == OperationResult.DeleteError)
                            {
                                ShowMessageWithUpdatePanel("Error On Delete", MessageType.Error);
                            }
                            else if (oResult == OperationResult.DeleteRefference)
                            {
                                ShowMessageWithUpdatePanel("Record used in transaction, Can't be deleted.", MessageType.Error);
                            }
                        }
                        else
                        {
                            ShowMessageWithUpdatePanel(dt.Rows[0]["RESULT"].ToString(), MessageType.Error);
                        }
                    }
                    else
                    {
                        ShowMessageWithUpdatePanel("You Can't be delete this transaction ,So please contact to admin for this transaction.", MessageType.Error);
                    }
                }
                catch (Exception ex)
                {
                    ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                    CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  GroupMaster _BindForEditUser ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  GroupMaster _BindForEditUser ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        private void _BindForEditUser(string sGroupID)
        {
            try
            {
                Reset();
                BL_GroupMaster oBL = new BL_GroupMaster();
                PL_GroupMaster oPL = new PL_GroupMaster();
                oPL.GroupID = sGroupID;
                oPL.GroupName = txtGroupName.Text.Trim();

                if (oBL.ShowDetailsEdit(oPL, txtGroupName))
                {
                    hidID.Value = sGroupID.ToString();
                    btnsave.Text = "Update";
                }
                else
                {
                    ShowMessageWithUpdatePanel("There are some Error Found on this row", MessageType.Error);
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  GroupMaster _BindForEditUser ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        private bool _ValidateInput()
        {
            bool result = true;
            ValidateResult _result;
            try
            {
                _result = new BL_GroupMaster().ValidateData(txtGroupName.Text, ValidateType.IsString);
                if (_result == ValidateResult.EMPTY || _result == ValidateResult.INVALID)
                {
                    ShowMessageWithUpdatePanel("Please Enter Group Name", MessageType.Error);
                    return result = false;
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  GroupMaster _ValidateInput() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
            return result;
        }
        #endregion

        #region Button Events

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (_ValidateInput())
                {
                    PL_GroupMaster oPL = new PL_GroupMaster();
                    oPL.GroupName = txtGroupName.Text.Trim();
                    oPL.CreatedBy = Session["UserCode"].ToString();
                    oPL.PlantCode = Session["PlantCode"].ToString();

                    BL_GroupMaster oBL = new BL_GroupMaster();
                    OperationResult oResutl = OperationResult.Error;

                    if (!string.IsNullOrEmpty(hidID.Value))   // Update
                    {
                        oPL.GroupID = hidID.Value.ToString();
                        oResutl = oBL.Update(oPL);
                    }
                    else
                    {
                        oResutl = oBL.Save(oPL);   // Insert
                    }

                    if (oResutl == OperationResult.SaveSuccess)
                    {
                        Reset();
                        _SHOWDETIALS();
                        ShowMessageWithUpdatePanel("Record Saved Successfully.", MessageType.Success);
                    }
                    if (oResutl == OperationResult.UpdateSuccess)
                    {
                        Reset();
                        _SHOWDETIALS();
                        ShowMessageWithUpdatePanel("Record Updated Successfully.", MessageType.Success);
                    }
                    if (oResutl == OperationResult.Duplicate)
                    {
                        ShowMessageWithUpdatePanel("Record Already Exists.", MessageType.Error);
                    }
                    else if (oResutl == OperationResult.SaveError)
                    {
                        ShowMessageWithUpdatePanel("Error on Save", MessageType.Error);
                    }
                    else if (oResutl == OperationResult.UpdateError)
                    {
                        ShowMessageWithUpdatePanel("Error on Update", MessageType.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of PRIMARY KEY"))
                {
                    ShowMessageWithUpdatePanel("Group already exist!!", MessageType.Error);
                    CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  GroupMaster btnsave_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
                  
                }
                else
                {
                    ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                    CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  GroupMaster btnsave_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);

                }
               
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Default.aspx");
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  GroupMaster btnsave_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

    

        #endregion

        protected void grdDispaly_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdDispaly.PageIndex = e.NewPageIndex;
                _SHOWDETIALS();
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  GroupMaster grdDispaly_PageIndexChanging() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        protected void grdDispaly_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DeleteRecords")
                {
                    _DeleteRecords(e.CommandArgument.ToString());
                }
                else if (e.CommandName == "EditRecords")
                {
                    _BindForEditUser(e.CommandArgument.ToString());
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  GroupMaster grdDispaly_RowCommand ", " User-  " + Session["UserName"] + " " + ex.Message);
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

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdDispaly.Rows.Count > 0)
                {
                    Response.Clear();
                    DataTable dt = (DataTable)Session["GroupMaster"];

                    objclsExportToCSV.ExportTOCSV(dt, "GroupMaster.csv");
                }
                else
                {
                    ShowMessageWithUpdatePanel("There is no data for being exported.", MessageType.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  GroupMaster btnExport_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }
    }
}