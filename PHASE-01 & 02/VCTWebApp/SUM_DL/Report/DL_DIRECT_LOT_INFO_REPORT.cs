
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
  public  class DL_DIRECT_LOT_INFO_REPORT
    {
        DataTable DT = new DataTable();
        Datautility DU = new Datautility();
        public DataTable ShowDetails(PL_DIRECT_LOT_INFO_REPORT obj)
        {
            try
            {
                SqlParameter[] parma = {
                                        new SqlParameter("@TYPE",obj.DbType),
                                        new SqlParameter("@LINE",obj.Line),
                                        new SqlParameter("@MODEL",obj.ModelNo),
                                        new SqlParameter("@CHILD_PART_NO",obj.PartNo),
                                        new SqlParameter("@LOT_NO",obj.LotNo),
                                   };
                DT = DU.GetDataUsingProcedure("[PRC_REPORT_DIRCT_LOT_INFO]", parma);

            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_DIRECT_LOT_INFO_REPORT ShowDetails() [PRC_REPORT_DIRCT_LOT_INFO]:", ex.Message);
                throw ex;
            }
            
            return DT;
        }

    }
}
