
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SUM_PL;
using COMMON; 

namespace SUM_DL
{
  public  class DL_TRAY_REPORT
    {
        DataTable DT = new DataTable();
        Datautility DU = new Datautility();
        public DataTable ShowDetails(PL_TRAY_REPORT obj)
        {
            try
            {
                SqlParameter[] parma = {
                                        new SqlParameter("@LINE",obj.Line),
                                        new SqlParameter("@TRAY",obj.Tray),
                                        new SqlParameter("@FROM_DATE",obj.FromDate),
                                        new SqlParameter("@TO_DATE",obj.ToDate),
                                   };
                DT = DU.GetDataUsingProcedure("[PRC_REPORT_TRAY]", parma);

            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_TRAY_REPORT ShowDetails() [PRC_REPORT_TRAY]:", ex.Message);
                throw ex;
            }
            
            return DT;
        }

    }
}
