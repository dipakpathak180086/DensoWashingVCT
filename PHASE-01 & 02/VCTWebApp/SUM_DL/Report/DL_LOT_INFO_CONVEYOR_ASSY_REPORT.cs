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
  public  class DL_LOT_INFO_CONVEYOR_ASSY_REPORT
    {
        DataTable DT = new DataTable();
        Datautility DU = new Datautility();
        public DataTable ShowDetails(PL_LOT_INFO_CONVEYOR_ASSY_REPORT obj)
        {
            try
            {
                SqlParameter[] parma = {
                                        new SqlParameter("@LINE",obj.Line),
                                        new SqlParameter("@STATION",obj.Station),
                                        new SqlParameter("@FROM_DATE",obj.FromDate),
                                        new SqlParameter("@TO_DATE",obj.ToDate),
                                   };
                DT = DU.GetDataUsingProcedure("[PRC_REPORT_CONVEYOR_LOT_INFO]", parma);

            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_LOT_INFO_CONVEYOR_ASSY_REPORT ShowDetails() [PRC_REPORT_CONVEYOR_LOT_INFO]:", ex.Message);
                throw ex;
            }
            
            return DT;
        }

    }
}
