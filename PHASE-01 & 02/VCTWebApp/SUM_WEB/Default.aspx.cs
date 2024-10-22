using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using SUM_BL;
using SUM_PL;
using System.Data;
using VCTWebApp;
using System.Drawing;
using VCTWebApp.pages.Master.UserManagment;

public partial class _Default : System.Web.UI.Page
{
   
    

    clsExportToCSV objclsExportToCSV = new clsExportToCSV();
    public static DataRow[] dr;
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
        {
            Response.Redirect("~/Login.aspx?Session=Null");
        }
    }
    protected void grdDispaly_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
           
        }
        catch (Exception ex)
        {
        }
    }
   
   
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //_PopulateProduct();
                //_PopulateLocation();
                //_PopulateLine();
                //_SHOWDETIALS();
            }
        }
        catch (Exception ex)
        {
            CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  :: Default Pages_Load() ", " User-  " + Session["UserName"].ToString() + " " + ex.Message);
        }
    }

   
   
    public string PutIntoQuotes( string value)
    {
        StringBuilder sOut = new StringBuilder();
        string[] sdata = value.Split(',');
        foreach (string s in sdata)
        {
            sOut.Append("'" + s + "',");
        }
        return sOut.ToString();
    }
  
  

}