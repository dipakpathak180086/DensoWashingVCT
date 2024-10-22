using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Net.NetworkInformation;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Web.Routing;

namespace VCTWebApp
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            string strMac = nics[0].GetPhysicalAddress().ToString();
           

            string sLogPath = ConfigurationManager.AppSettings["LogFilePath"].ToString();
            string sPath = HttpContext.Current.Server.MapPath(sLogPath);
            DirectoryInfo _dir = null;
            _dir = new DirectoryInfo(sPath);
            if (_dir.Exists == false)
            {
                _dir.Create();
                Directory.CreateDirectory(_dir.ToString() + "log\\");
            }
            SatoLib.SatoLogger _obj = new SatoLib.SatoLogger();
            _obj.ChangeInterval = SatoLib.SatoLogger.ChangeIntervals.ciHourly;
            _obj.EnableLogFiles = true;
            _obj.LogDays = 10;
            _obj.LogFilesExt = "Log";
            _obj.LogFilesPath = sPath;
            _obj.LogFilesPrefix = "Denso";
            _obj.StartLogging();
            _obj.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "SatoAppsInitialize" + "  ::  Main", "Initializing Application.......on " + strMac);
            CommonHelper.mSatoLogger = _obj;
            _obj.StopLogging();
            _obj = null;
            CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtData, Assembly.GetExecutingAssembly().GetName() + "::" + MethodBase.GetCurrentMethod().Name + "  " + strMac, "AppInitialize");
            CommonHelper.mSatoLogger.StartLogging();
            
        }

        void RegisterRoutes(RouteCollection routes)
        {
          RouteTable.Routes.MapPageRoute(
         "CustomerOrder",
         "Customer/{id}/Order",
         "~/HeijunkaWebApp/pages/Master/CustomerOrderMaster.aspx");
            //RouteTable.Routes.MapPageRoute(
            //    "CustomerBill",
            //    "Customer/{id}/Bill",
            //    "~/Bill/CustomerBill.aspx");

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}