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
  public  class DL_REPORT_LOG
    {
        DataTable DT = new DataTable();
        Datautility DU = new Datautility();
        public DataTable ShowDetails(PL_REPORT_LOG obj)
        {
            try
            {
                SqlParameter[] parma = {
                                        new SqlParameter("@TYPE",obj.DbType),
                                        new SqlParameter("@LINE",obj.Line),
                                        new SqlParameter("@STATION",obj.Station),
                                        new SqlParameter("@PROCESS",obj.Process),
                                        new SqlParameter("@FROM_DATE",obj.FromDate),
                                        new SqlParameter("@TO_DATE",obj.ToDate),
                                   };
                DT = DU.GetDataUsingProcedure("[PRC_REPORT_LOG]", parma);

            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_REPORT_LOG ShowDetails() [PRC_REPORT_LOG]:", ex.Message);
                throw ex;
            }
            
            return DT;
        }

    }
}
