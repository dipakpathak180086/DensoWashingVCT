using SUM_BL;
using SUM_PL;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace VCTWebApp.pages.Master.UserManagment
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        #region Global Variable

        #endregion End Global Variable

        #region Page Events

        protected void Page_Init(object sender, EventArgs e)
        {
            txtCurrentPassword.Focus();
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/Login.aspx?Session=Null");
            }

        }
        public enum MessageType { Success, Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                lblUserName.Text = Session["UserCode"].ToString();

            }
        }

        #endregion End Page Events


        #region Button Events

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Default.aspx");
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  ChangePassword _BtnBack_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }

        }

        private bool ValidatePassword(string password)
        {
            var input = password;
            string ErrorMessage = "";

           

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            //if (string.IsNullOrEmpty(hidID.Value) && !hasLowerChar.IsMatch(input))
            //{
            //    ErrorMessage = "Password should contain at least one lower case letter.";
            //    ShowMessageWithUpdatePanel(ErrorMessage, MessageType.Error);
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{ErrorMessage}');", true);
            //    return false;
            //}
            //else if (string.IsNullOrEmpty(hidID.Value) && !hasUpperChar.IsMatch(input))
            //{
            //    ErrorMessage = "Password should contain at least one upper case letter.";
            //    ShowMessageWithUpdatePanel(ErrorMessage, MessageType.Error);
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{ErrorMessage}');", true);
            //    return false;
            //}
            //else if (string.IsNullOrEmpty(hidID.Value) && !hasMiniMaxChars.IsMatch(input))
            //{
            //    ErrorMessage = "Password should not be lesser than 8 or greater than 15 characters.";
            //    ShowMessageWithUpdatePanel(ErrorMessage, MessageType.Error);
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{ErrorMessage}');", true);
            //    return false;
            //}
            //else if (string.IsNullOrEmpty(hidID.Value) && !hasNumber.IsMatch(input))
            //{
            //    ErrorMessage = "Password should contain at least one numeric value.";
            //    ShowMessageWithUpdatePanel(ErrorMessage, MessageType.Error);
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{ErrorMessage}');", true);
            //    return false;
            //}

            //else if (string.IsNullOrEmpty(hidID.Value) && !hasSymbols.IsMatch(input))
            //{
            //    ErrorMessage = "Password should contain at least one special case character.";
            //    ShowMessageWithUpdatePanel(ErrorMessage, MessageType.Error);
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{ErrorMessage}');", true);
            //    return false;
            //}
            if (string.IsNullOrEmpty(hidID.Value) && string.IsNullOrWhiteSpace(input))
            {
                // throw new Exception("Password should not be empty");
                ShowMessageWithUpdatePanel("Password should not be empty", MessageType.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                DataTable dtoResutl = new DataTable();
                if (ValidatePassword(txtPassword.Text.Trim()))
                {
                    if (_ValidateInput())
                    {
                        PL_UserMaster oPL = new PL_UserMaster();
                        oPL.UserID = Session["UserID"].ToString();
                        oPL.Password = txtCurrentPassword.Text.ToString();
                        oPL.NewPswd = txtPassword.Text.ToString();
                        // oPL.Password = CommonHelper.Encryp(txtCurrentPassword.Text.ToString());
                        // oPL.NewPswd = CommonHelper.Encryp(txtPassword.Text.ToString());

                        BL_UserMaster oBL = new BL_UserMaster();

                        dtoResutl = oBL.UpdatePassword(oPL);


                        if (dtoResutl.Rows[0]["RESULT"].ToString() == "Y")
                        {
                            Reset();
                            ShowMessageWithUpdatePanel("Password Updated Successfully", MessageType.Success);
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Password Updated Successfully');", true);
                            Session["IsLogoutReq"] = true;
                        }

                        else
                        {
                            ShowMessageWithUpdatePanel(dtoResutl.Rows[0]["RESULT"].ToString(), MessageType.Error);
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{dtoResutl.Rows[0]["RESULT"].ToString()}');", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageWithUpdatePanel(ex.ToString(), MessageType.Error);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  ChangePassword _BtnSave_Click() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
            }
        }

        private bool _ValidateInput()
        {
            bool _Flag = true;
            if (string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                ShowMessageWithUpdatePanel("Please Enter Current Password", MessageType.Error);
                _Flag = false;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                ShowMessageWithUpdatePanel("Please Enter New Password", MessageType.Error);
                _Flag = false;
            }
            else if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                ShowMessageWithUpdatePanel("Please Enter Confirm Password", MessageType.Error);
                _Flag = false;
            }
            else if (txtPassword.Text.ToString() != txtConfirmPassword.Text.ToString())
            {
                ShowMessageWithUpdatePanel("New Password and Confirm Password Not Matched", MessageType.Error);
                _Flag = false;
            }
           
            if (txtPassword.Text.Length < 8 || txtPassword.Text.Length > 12)
            {
                ShowMessageWithUpdatePanel("Password must be at least 8 characters", MessageType.Error);
                _Flag = false;
            }
            
            return _Flag;
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            txtConfirmPassword.Text = "";
            txtPassword.Text = "";
            txtCurrentPassword.Text = "";
        }

        #endregion
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
    }
}