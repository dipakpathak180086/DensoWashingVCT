using COMMON;
using SUM_BL;
using SUM_PL;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCTWebApp.pages.Master.UserManagment
{
    public partial class UserMaster : System.Web.UI.Page
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
                    txtUserName.Focus();
                    _SHOWDETIALS();
                    _PopulateUserType();

                   // txtPinNo.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  UserMaster _Page_Load() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }
       

        private void _PopulateUserType()
        {
            try
            {
                PL_UserMaster plObj = new PL_UserMaster();
                BL_UserMaster blObj = new BL_UserMaster();
                DataTable DT = blObj.BindGroup(plObj);
                ddlUserType.DataSource = DT;
                ddlUserType.DataValueField = "GroupID";
                ddlUserType.DataTextField = "GroupName";
                ddlUserType.DataBind();
                ddlUserType.Items.Insert(0, "--SELECT--");
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
                BL_UserMaster blobj = new BL_UserMaster();
                PL_UserMaster plobj = new PL_UserMaster();
                DataTable DT = blobj.ShowUserDetails(plobj);
                CommonHelper.BindGrid(gvUserMaster, DT);
                Session["UserMaster"] = DT;
                UpdatePanel1.Update();
                lblRecords.Text = "No. of Records: " + DT.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  UserMaster _SHOWDETIALS() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        private void Reset()
        {
            try
            {
                ddlUserType.SelectedIndex = 0;
                txtUserID.Text = string.Empty;
                txtEmailID.Text = string.Empty;
                txtUserID.ReadOnly = false;
                txtPassword.ReadOnly=false;
                txtUserName.Text = string.Empty;
                txtPassword.Text = string.Empty;
               // txtPinNo.Enabled = false;
                txtPinNo.Text = "";
                //txtPassword.ReadOnly = false;
                btnSave.Text = "Save";
                hidID.Value = string.Empty;
                txtUserName.Focus();
                //UpdatePanel1.Update();
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  UserMaster _Reset() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        private void _DeleteRecords(string sUserID)
        {
            try
            {
                try
                {
                    Reset();
                    BL_UserMaster oBL = new BL_UserMaster();
                    PL_UserMaster oPL = new PL_UserMaster();
                    oPL.UserCode = sUserID;
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
                catch (Exception ex)
                {
                    ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                    CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  UserMaster _BindForEditUser ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  UserMaster _BindForEditUser ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        private void _BindForEditUser(string sUserID)
        {
            try
            {
                Reset();
                BL_UserMaster oBL = new BL_UserMaster();
                PL_UserMaster oPL = new PL_UserMaster();
                oPL.UserID = sUserID;
                if (oBL.ShowDetailsEdit(oPL, ddlUserType, txtUserName, txtUserID, txtPassword, null, null, txtEmailID,txtPinNo))
                {
                    hidID.Value = sUserID.ToString();
                    txtUserID.Text = sUserID.ToString();
                    txtUserID.ReadOnly = true;
                    txtPassword.ReadOnly = true;
                   
                   
                    string s = txtPassword.Text;
                  
                    //txtUserID.Attributes["class"] = "form-control";
                    //txtUserID.Attributes.Add("class", "form-control");
                    //txtUserID.Width=200;
                    btnSave.Text = "Update";
                    UpdatePanel1.Update();
                }
                else
                {
                    ShowMessageWithUpdatePanel("There are some Error Found on this row", MessageType.Error);
                   
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  UserMaster _BindForEditUser ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        private bool _ValidateInput()
        {
            bool result = true;
            ValidateResult _result;
            try
            {
                if (txtUserName.Text == string.Empty)
                {
                  
                    ShowMessageWithUpdatePanel("Please Enter User Name", MessageType.Error);
                   
                    return result = false;
                }
                if (txtUserID.Text == string.Empty)
                {
                   
                    ShowMessageWithUpdatePanel("Please Enter User ID.", MessageType.Error);
                    
                    return result = false;
                }
                else if (ddlUserType.SelectedIndex == 0)
                {
                    ShowMessageWithUpdatePanel("Please Select User Type.", MessageType.Error);
                   
                    return result = false;
                }
                //if (string.IsNullOrEmpty(hidID.Value) && txtPassword.Text == string.Empty)
                //{
                //    ShowMessageWithUpdatePanel("Please Enter Password.", MessageType.Error);
                   
                //    return result = false;
                //}
                //if (string.IsNullOrEmpty(hidID.Value) &&(txtPassword.Text.Length < 8 || txtPassword.Text.Length > 12))
                //{
                //    ShowMessageWithUpdatePanel("Password must be at least 8 characters Or Not should not exceed 12 characters.", MessageType.Error);
                //    return result = false;
                //}
                //if (string.IsNullOrEmpty(hidID.Value) && txtPinNo.Text == string.Empty)
                //{
                //    ShowMessageWithUpdatePanel("Please Enter Pin No.", MessageType.Error);

                //    return result = false;
                //}
               
                //if (txtPassword.Text == string.Empty)
                //{
                //    ShowMessageWithUpdatePanel("Please enter password", MessageType.Error);
                //    return result = false;
                //}

               
                if (txtEmailID.Text == string.Empty)
                {
                    ShowMessageWithUpdatePanel("Please Enter Email ID.", MessageType.Error);

                    return result = false;
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  UserMaster _ValidateInput() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
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
        //        CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  UserMaster BtnBack_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
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
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  UserMaster btnReset_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        private bool ValidatePassword(string password)
        {
            var input = password;
            string ErrorMessage = "";

            if (string.IsNullOrEmpty(hidID.Value) && string.IsNullOrWhiteSpace(input))
            {
               // throw new Exception("Password should not be empty");
                ShowMessageWithUpdatePanel("Password should not be empty", MessageType.Error);
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (string.IsNullOrEmpty(hidID.Value) && !hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one lower case letter.";
                ShowMessageWithUpdatePanel(ErrorMessage, MessageType.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(hidID.Value) && !hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one upper case letter.";
                ShowMessageWithUpdatePanel(ErrorMessage, MessageType.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(hidID.Value) && !hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = "Password should not be lesser than 8 or greater than 15 characters.";
                ShowMessageWithUpdatePanel(ErrorMessage, MessageType.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(hidID.Value) && !hasNumber.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one numeric value.";
                ShowMessageWithUpdatePanel(ErrorMessage, MessageType.Error);
                return false;
            }

            else if (string.IsNullOrEmpty(hidID.Value) && !hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one special case character.";
                ShowMessageWithUpdatePanel(ErrorMessage, MessageType.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidatePassword(txtPassword.Text.Trim()))
                {
                    if (_ValidateInput())
                    {
                        PL_UserMaster oPL = new PL_UserMaster();

                        oPL.GroupName = ddlUserType.SelectedValue.ToString();
                        oPL.PlantCode ="";
                        oPL.DepartmentCode ="";
                        oPL.UserCode = txtUserID.Text.Trim();
                        oPL.EmailID = txtEmailID.Text.Trim();
                        oPL.PinNo = CommonHelper.EncodePasswordToBase64(txtPinNo.Text.Trim());//txtPinNo.Text.Trim();
                        oPL.Password = CommonHelper.EncodePasswordToBase64(txtPassword.Text.Trim());
                        oPL.UserName = txtUserName.Text.Trim();
                        oPL.CreatedBy = Convert.ToInt32(Session["UserID"].ToString());
                        BL_UserMaster oBL = new BL_UserMaster();
                        OperationResult oResult = OperationResult.Error;
                        if (!string.IsNullOrEmpty(hidID.Value.ToString()))   // Update
                        {
                            oPL.ModifiedBy = Convert.ToInt32(Session["UserID"].ToString());
                            oPL.UserID = hidID.Value.ToString();

                            oResult = oBL.Update(oPL);
                        }
                        else
                        {
                            bool result = true; ValidateResult _result;
                            _result = new BL_UserMaster().ValidateData(txtPassword.Text, ValidateType.IsString);
                            if (_result == ValidateResult.EMPTY || _result == ValidateResult.INVALID)
                            {
                                ShowMessageWithUpdatePanel("Please Enter Password", MessageType.Error);
                                result = false;
                            }

                            if (result)
                                oResult = oBL.Save(oPL);   // Insert
                        }

                        if (oResult == OperationResult.SaveSuccess)
                        {
                            Reset();
                            _SHOWDETIALS();
                            ShowMessageWithUpdatePanel("Record Saved Successfully.", MessageType.Success);
                        }
                        if (oResult == OperationResult.UpdateSuccess)
                        {
                            Reset();
                            _SHOWDETIALS();
                            ShowMessageWithUpdatePanel("Record Updated Successfully.", MessageType.Success);
                        }
                        if (oResult == OperationResult.Duplicate)
                        {
                            ShowMessageWithUpdatePanel("Record Already Exists", MessageType.Error);
                        }
                        else if (oResult == OperationResult.SaveError)
                        {
                            ShowMessageWithUpdatePanel("Error on Save", MessageType.Error);
                        }
                        else if (oResult == OperationResult.UpdateError)
                        {
                            ShowMessageWithUpdatePanel("Error on Update", MessageType.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of PRIMARY KEY"))
                {
                    ShowMessageWithUpdatePanel("User Id already exist !!", MessageType.Error);
                    CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  UserMaster btnsave_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
                }
                else
                {
                    ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                    CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  UserMaster btnsave_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
                }
                   
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvUserMaster.Rows.Count > 0)
                {
                   // Response.Clear();
                    DataTable dt = (DataTable)Session["UserMaster"];

                    objclsExportToCSV.ExportTOCSV(dt, "UserMaster.csv");
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
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  UserMaster btnExport_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        protected void gvUserMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvUserMaster.PageIndex = e.NewPageIndex;
                _SHOWDETIALS();
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  UserMaster gvUserMaster_PageIndexChanging() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        protected void gvUserMaster_RowCommand(object sender, GridViewCommandEventArgs e)
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
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  UserMaster gvUserMaster_RowCommand ", " User-  " + Session["UserName"] + " " + ex.Message);
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
    }
}