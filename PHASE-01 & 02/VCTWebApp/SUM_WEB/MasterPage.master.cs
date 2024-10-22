using SUM_BL;
using SUM_PL;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using VCTWebApp.pages;

public partial class MasterPage : System.Web.UI.MasterPage
{

    protected void Page_Init(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
        if (Session["UserName"] == null)
        {
            Response.Redirect("~/Login.aspx?Session=Null");
        }
    }
    private void ChangePasswordRequired()
    {

        string pageName = Path.GetFileName(Request.Path);
        
        if (Session["IsChangePassword"].ToString() == "False")
        {
            if (!(Path.GetFileName(Request.Path) == "ChangePassword.aspx"))
                Response.Redirect("~/Pages/Master/UserManagment/ChangePassword.aspx", false);
        }
    }
    private void isLogoutreq()
    {
        if(Convert.ToBoolean(Session["IsLogoutReq"])==true)
        btnLogout_Click(null, null);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        isLogoutreq();
        Label lblUserName = (Label)this.FindControl("lblUserName");
        lblUserName.Text = Session["UserName"].ToString();
        BindMainMenu();
        //if (Session["GroupName"].ToString().ToUpper() != "ADMIN")
        //{
        //    GetGroupRights();
        //    ActiveMenu();
        //    GetMenuChangeColor();
        //}

        HttpCookie userCookie = new HttpCookie("UserInfo_" + Session["UserName"].ToString() + "con");
        userCookie["UserName"] = Session["UserName"].ToString();
        userCookie["FullPath"] = Request.Url.ToString().Replace("&", "##");
        userCookie["Path"] = Request.Url.PathAndQuery.ToString().Replace("&", "##");
        userCookie.Expires = DateTime.Now.AddDays(1);
        Response.Cookies.Add(userCookie);
        ChangePasswordRequired();
        

    }
    private void GetGroupRights()
    {
        BL_GroupMaster blobj = new BL_GroupMaster();
        PL_GroupMaster plobj = new PL_GroupMaster();
        plobj.GroupID = (string)Session["GroupName"];
        DataTable dt = new DataTable();

        dt = blobj.GetGroupRights(plobj);
        if (dt.Rows.Count > 0)
        {
            Session["UserRights"] = dt;
        }
        else
        {

        }
    }    

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Login.aspx");
    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/Pages/Master/UserManagment/ChangePassword.aspx");

    }

    private void BindMainMenu()
    {

    }


    private void GetMenuChangeColor()
    {
       
        string pageName = Path.GetFileName(Request.Path);
        //if (pageName == "CompanyMaster.aspx")
        //{
        //    HypCompanyMaster.ForeColor = System.Drawing.Color.LightGreen;
        //}
        if (pageName == "GroupMaster.aspx")
        {
            hpyGroupMaster.ForeColor = System.Drawing.Color.LightGreen;
        }
        else if (pageName == "UserMaster.aspx")
        {
            hpyUserMaster.ForeColor = System.Drawing.Color.LightGreen;
        }
        else if (pageName == "GroupRights.aspx")
        {
            hpyGroupRights.ForeColor = System.Drawing.Color.LightGreen;
        }
        
        
    }

    private void ActiveMenu()
    {
        //string _strRights = CommonHelper.GetRights("GROUP", (DataTable)Session["UserRights"]);
        //CommonHelper._strRights = _strRights.Split('^');
        //if (CommonHelper._strRights[0] == "0")  //Check view rights
        //{
        //    Response.Redirect("~/UnauthorizedUser.aspx");
        //}
        StringBuilder sb = new StringBuilder();
        HtmlGenericControl liMaster = (HtmlGenericControl)this.FindControl("liMaster");
        liMaster.FindControl("HypCombineStock").Visible = false;
        liMaster.FindControl("HypPlantMaster").Visible = false;
        liMaster.FindControl("HypDepartmentMaster").Visible = false;
        liMaster.FindControl("hpyGroupMaster").Visible = false;
        liMaster.FindControl("hpyUserMaster").Visible = false;

        liMaster.FindControl("hpyGroupRights").Visible = false;
        liMaster.FindControl("HypWarehouseMaster").Visible = false;
        liMaster.FindControl("HypProductMaster").Visible = false;
        liMaster.FindControl("HypLineMaster").Visible = false;
        
        liMaster.FindControl("HypCustomerMaster").Visible = false;
        liMaster.FindControl("HypPartLineMappingMaster").Visible = false;
        //liMaster.FindControl("HypPartLineCustMappingMaster").Visible = false;
        liMaster.FindControl("HypLocationType").Visible = false;
        liMaster.FindControl("HypLocationMaster").Visible = false;
        liMaster.FindControl("HypLocationPartMapping").Visible = false;
        liMaster.FindControl("HypCustomerOrderMaster").Visible = false;

        HtmlGenericControl liTranscation = (HtmlGenericControl)this.FindControl("liTranscation");
        liTranscation.FindControl("hpyPartHoldRequest").Visible = false;
        liTranscation.FindControl("hpyHoldPartApproval").Visible = false;
        liTranscation.FindControl("hpyHoldPartChecker1").Visible = false;
        liTranscation.FindControl("hpyHoldPartChecker2").Visible = false;
        liTranscation.FindControl("hpyHoldPartChecker3").Visible = false;
        liTranscation.FindControl("HypPartScrapRequest").Visible = false;
        liTranscation.FindControl("HypScrapPartApproval").Visible = false;

        HtmlGenericControl liReport = (HtmlGenericControl)this.FindControl("liReport");
        liReport.FindControl("hpyEndLineStock").Visible = false;
        liReport.FindControl("hypPendingPutway").Visible = false;
        liReport.FindControl("HypWHPutway").Visible = false;
        liReport.FindControl("HypStagingAreaPutway").Visible = false;
        liReport.FindControl("HypCombineStock").Visible = false;
        liReport.FindControl("HypPartHoldRequestReport").Visible = false;
        liReport.FindControl("HypPartScrapRequestReport").Visible = false;
        
        foreach (DataRow item in ((DataTable)Session["UserRights"]).Rows)
        {
            foreach (var Childitem in liMaster.Controls)
            {
                if (item[2].ToString() == "False") { continue; }
                //if (((System.Web.UI.Control)Childitem).FindControl("HypCompanyMaster").ClientID.Contains(item[1].ToString()))
                //{
                //    ((System.Web.UI.Control)Childitem).FindControl("HypCompanyMaster").Visible = true;
                //}
                if (((System.Web.UI.Control)Childitem).FindControl("HypPlantMaster").ClientID.Contains(item[1].ToString()))
                {
                    ((System.Web.UI.Control)Childitem).FindControl("HypPlantMaster").Visible = true;
                }
                if (((System.Web.UI.Control)Childitem).FindControl("HypDepartmentMaster").ClientID.Contains(item[1].ToString()))
                {
                    ((System.Web.UI.Control)Childitem).FindControl("HypDepartmentMaster").Visible = true;
                }
                if (((System.Web.UI.Control)Childitem).FindControl("hpyGroupMaster").ClientID.Contains(item[1].ToString()))
                {
                    ((System.Web.UI.Control)Childitem).FindControl("hpyGroupMaster").Visible = true;
                }
                if (((System.Web.UI.Control)Childitem).FindControl("hpyUserMaster").ClientID.Contains(item[1].ToString()))
                {
                    ((System.Web.UI.Control)Childitem).FindControl("hpyUserMaster").Visible = true;
                }

                if (((System.Web.UI.Control)Childitem).FindControl("hpyGroupRights").ClientID.Contains(item[1].ToString()))
                {
                    ((System.Web.UI.Control)Childitem).FindControl("hpyGroupRights").Visible = true;
                }

                if (((System.Web.UI.Control)Childitem).FindControl("HypWarehouseMaster").ClientID.Contains(item[1].ToString()))
                {
                    ((System.Web.UI.Control)Childitem).FindControl("HypWarehouseMaster").Visible = true;
                }
                if (((System.Web.UI.Control)Childitem).FindControl("HypLineMaster").ClientID.Contains(item[1].ToString()))
                {
                    ((System.Web.UI.Control)Childitem).FindControl("HypLineMaster").Visible = true;
                }
                if (((System.Web.UI.Control)Childitem).FindControl("HypProductMaster").ClientID.Contains(item[1].ToString()))
                {
                    ((System.Web.UI.Control)Childitem).FindControl("HypProductMaster").Visible = true;
                }
                if (((System.Web.UI.Control)Childitem).FindControl("HypCustomerMaster").ClientID.Contains(item[1].ToString()))
                {
                    ((System.Web.UI.Control)Childitem).FindControl("HypCustomerMaster").Visible = true;
                }
                if (((System.Web.UI.Control)Childitem).FindControl("HypPartLineMappingMaster").ClientID.Contains(item[1].ToString()))
                {
                    ((System.Web.UI.Control)Childitem).FindControl("HypPartLineMappingMaster").Visible = true;
                }

                //if (((System.Web.UI.Control)Childitem).FindControl("HypPartLineCustMappingMaster").ClientID.Contains(item[1].ToString()))
                //{
                //    ((System.Web.UI.Control)Childitem).FindControl("HypPartLineCustMappingMaster").Visible = true;
                //}
                if (((System.Web.UI.Control)Childitem).FindControl("HypLocationType").ClientID.Contains(item[1].ToString()))
                {
                    ((System.Web.UI.Control)Childitem).FindControl("HypLocationType").Visible = true;
                }
                if (((System.Web.UI.Control)Childitem).FindControl("HypLocationMaster").ClientID.Contains(item[1].ToString()))
                {
                    ((System.Web.UI.Control)Childitem).FindControl("HypLocationMaster").Visible = true;
                }
                if (((System.Web.UI.Control)Childitem).FindControl("HypLocationPartMapping").ClientID.Contains(item[1].ToString()))
                {
                    ((System.Web.UI.Control)Childitem).FindControl("HypLocationPartMapping").Visible = true;
                }
                if (((System.Web.UI.Control)Childitem).FindControl("HypCustomerOrderMaster").ClientID.Contains(item[1].ToString()))
                {
                    ((System.Web.UI.Control)Childitem).FindControl("HypCustomerOrderMaster").Visible = true;
                }
            }
            foreach (var Childitem in liTranscation.Controls)
            {
                if (item[2].ToString() == "False") { continue; }
                if (((System.Web.UI.Control)Childitem).FindControl("hpyPartHoldRequest").ClientID.Contains(item[1].ToString()))
                {
                    ((System.Web.UI.Control)Childitem).FindControl("hpyPartHoldRequest").Visible = true;
                }
                

            }
       
        }
    }

    protected void lnkMozilaBrowsers_Click(object sender, EventArgs e)
    {
        //// Create An instance of the Process class responsible for starting the newly process.

        //System.Diagnostics.Process process1 = new System.Diagnostics.Process();

        //// Set the directory where the file resides

        //process1.StartInfo.WorkingDirectory = Request.MapPath("~/dist/");

        //// Set the filename name of the file you want to open

        //process1.StartInfo.FileName = Request.MapPath("~/dist/FirefoxSetup38.0.exe");
        //// Start the process
        //process1.Start();
    }
    protected void lnkChormeBrowsers_Click(object sender, EventArgs e)
    {
        //// Create An instance of the Process class responsible for starting the newly process.

        //System.Diagnostics.Process process1 = new System.Diagnostics.Process();

        //// Set the directory where the file resides

        //process1.StartInfo.WorkingDirectory = Request.MapPath("~/dist/");

        //// Set the filename name of the file you want to open

        //process1.StartInfo.FileName = Request.MapPath("~/dist/ChromeStandaloneSetup.exe");
        //// Start the process
        //process1.Start();
    }

    protected void aAvtar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Master/UserManagment/ChangePassword.aspx", false);
    }
}
