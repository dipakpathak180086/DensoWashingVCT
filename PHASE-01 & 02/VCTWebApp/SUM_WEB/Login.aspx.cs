using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COMMON;
using System.Data;
using SUM_BL;
using SUM_PL;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Configuration;

namespace VCTWebApp
{

    public partial class Login : System.Web.UI.Page
    {
        BL_UserMaster blObj = new BL_UserMaster();
        PL_UserMaster plobj = new PL_UserMaster();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUserId.Focus();
            CommonHelper.connString = ConfigurationManager.ConnectionStrings["CONN_LINE_01"].ConnectionString;
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserId.Text == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Login ID');", true);
                    txtUserId.Focus();
                    return;
                }
                else if (txtPassword.Text == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Password');", true);
                    txtPassword.Focus();

                    return;
                }
                
                BL_UserMaster blObj = new BL_UserMaster();
                PL_UserMaster plobj = new PL_UserMaster();
                plobj.UserCode = txtUserId.Text.ToString();

                plobj.Password = txtPassword.Text.ToString();//CommonHelper.EncryptPassword(txtPassword.Value.ToString(), "E");
                DataTable DT = blObj.ValidateUser(plobj);
                if (DT.Rows.Count > 0)
                {
                    //string s= CommonHelper.Decryptdata(DT.Rows[0]["Password"].ToString());
                    Session["UserName"] = DT.Rows[0]["UserName"].ToString();
                    Session["UserID"] = DT.Rows[0]["UserID"].ToString();
                    Session["Group"] = DT.Rows[0]["GroupName"].ToString();

                    Session["GroupName"] = DT.Rows[0]["GroupID"].ToString();
                    Session["UserCode"] = plobj.UserCode;
                    Session["IsChangePassword"] = DT.Rows[0]["IsChangePassword"].ToString();
                    HttpCookie cookie = Request.Cookies["UserInfo_" + Session["UserName"].ToString().ToUpper() + "con"];
                    if (cookie != null)
                    {
                        if (cookie["UserName"] != null && cookie["path"] != null)
                        {
                            Session["UserName"] = cookie["UserName"].ToString();
                            string pageName = Path.GetFileName(Request.Path);
                            //if (Session["IsChangePassword"].ToString() == "False")
                            //{
                            //    if (!(Path.GetFileName(Request.Path) == "ChangePassword.aspx"))
                            //        Response.Redirect("~/Pages/Master/UserManagment/ChangePassword.aspx", false);
                            //}
                            //else
                            //{
                            Response.Redirect("~/Default.aspx", false);
                            //Response.Redirect("" + cookie["path"].ToString().Replace("##", "&") + "",false);
                            //}
                        }
                        else
                        {
                            Response.Redirect("~/Default.aspx", false);
                        }
                    }
                    else
                    {
                        string pageName = Path.GetFileName(Request.Path);
                        //if (Session["IsChangePassword"].ToString() == "False")
                        //{
                        //    if (!(Path.GetFileName(Request.Path) == "ChangePassword.aspx"))
                        //        Response.Redirect("~/Pages/Master/UserManagment/ChangePassword.aspx", false);
                        //}
                        //else
                        //{
                        Response.Redirect("~/Default.aspx", false);
                        //}
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid username or password, please try again');", true);
                    txtUserId.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    txtUserId.Focus();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.ToString() + "');", true);
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  Login btnLogin_Click() [USP_M_User]:", ex.Message);
            }
        }
        public bool sendmail1(string UserID)
        {
            bool sendmail = false;
            try
            {
                DataTable getmailcredential = new DataTable();
                DataTable UserDetails = new DataTable();
                BL_UserMaster blObj = new BL_UserMaster();
                PL_UserMaster plobj = new PL_UserMaster();
                string UserName = "", UserPassword = "", UserMailI = "";
                plobj.DbType = "GetMailSetting";
                plobj.UserCode = txtUserId.Text.ToString();
                getmailcredential = blObj.GetMailSetting(plobj);

                if (getmailcredential.Rows.Count <= 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('mail credential setting not registered');", true);
                    return sendmail;
                }
                BL_UserMaster blObj1 = new BL_UserMaster();
                PL_UserMaster plobj1 = new PL_UserMaster();
                plobj1.DbType = "GetPassword";
                plobj1.UserCode = txtUserId.Text.ToString();
                UserDetails = blObj1.GetMailSetting(plobj1);

                if (UserDetails.Rows.Count <= 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('mail registered of login user');", true);
                    return sendmail;
                }
                UserName = UserDetails.Rows[0]["UserName"].ToString();
                UserPassword = CommonHelper.DecodeFrom64(UserDetails.Rows[0]["Password"].ToString());
                UserMailI = UserDetails.Rows[0]["EmailId"].ToString();

                string subject = "WMS Forgot Password";
                string body = "";

                body += "Dear Sir, <br/><br/>";

                body += "Good Day <br/><br/>";
                body += "Kindly find Request Password:-  <br/><br/>";
                body += subject + " <br/><br/>";

                body += "User Name" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + ":&nbsp;" + "<b>" + UserName + "</b>" + " <br/><br/>";

                body += "Password " + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + ":&nbsp;" + "<b>" + UserPassword + "</b>" + " <br/><br/>";

                body += "User ID  " + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + ":&nbsp;" + "<b>" + txtUserId.Text + "</b>" + " <br/><br/>";

                body += " <br/><br/>";

                body += "Thanks and Regards:";

                body += " <br/><br/>";

                body += "This is an auto generated mail please don not reply";

                // var fromAddress = new MailAddress("xrsys_support@denso.co.in".Trim());
                var fromAddress = new MailAddress(getmailcredential.Rows[0]["NETWORK_ID"].ToString().Trim());
                var fromPassword = getmailcredential.Rows[0]["NETWORK_PASSWORD"].ToString().Trim();
                // var fromPassword = "";
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
                {
                    Host = getmailcredential.Rows[0]["HOST"].ToString(),
                    Port = Convert.ToInt32(getmailcredential.Rows[0]["PORT"].ToString()),
                    EnableSsl = Convert.ToBoolean(getmailcredential.Rows[0]["SSL"].ToString()),
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(getmailcredential.Rows[0]["NETWORK_ID"].ToString().Trim());
                mail.IsBodyHtml = true;
                mail.To.Add(UserMailI.ToString());
                mail.Body = body;
                mail.Subject = subject;
                smtp.Send(mail);
                sendmail = true;
            }
            catch (Exception ex)
            {
                sendmail = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.ToString() + "');", true);
            }
            return sendmail;
        }
        protected void LinkButtonForgotPass_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserId.Text == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Login ID');", true);
                    txtUserId.Focus();
                    return;
                }
                bool checkStatus = sendmail1(txtUserId.Text);
                if (checkStatus == true)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Password send to you register mail');", true);
                    txtUserId.Text = "";
                    txtUserId.Focus();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error in send mail');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.ToString() + "');", true);
            }
        }

        protected void dllLine_SelectedIndexChanged(object sender, EventArgs e)
        {

           

        }
    }
}