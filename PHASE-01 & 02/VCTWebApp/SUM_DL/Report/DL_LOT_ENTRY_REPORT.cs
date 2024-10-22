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
  public  class DL_LOT_ENTRY_REPORT
    {
        DataTable DT = new DataTable();
        Datautility DU = new Datautility();
        public DataTable ShowDetails(PL_LOT_ENTRY_REPORT obj)
        {
            try
            {
                SqlParameter[] parma = {
                                        new SqlParameter("@TYPE",obj.DbType),
                                        new SqlParameter("@MODEL_NO",obj.Model),
                                        new SqlParameter("@CHILD_PART",obj.Child),
                                        new SqlParameter("@FROM_DATE",obj.FromDate),
                                        new SqlParameter("@TO_DATE",obj.ToDate),
                                        new SqlParameter("@LOT",obj.Lot),
                                   };
                DT = DU.GetDataUsingProcedure("[PRC_REPORT]", parma);

            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_LOT_ENTRY_REPORT ShowDetails() [PRC_REPORT_LOG]:", ex.Message);
                throw ex;
            }
            
            return DT;
        }

    }
}
