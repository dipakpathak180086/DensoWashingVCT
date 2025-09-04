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
  public  class DL_CHILD_PART_ASSY_REPORT
    {
        DataTable DT = new DataTable();
        Datautility DU = new Datautility();
        public DataTable ShowDetails(PL_CHILD_PART_ASSY_REPORT obj)
        {
            try
            {
                SqlParameter[] parma = {
                                        new SqlParameter("@TYPE",obj.DbType),
                                        new SqlParameter("@LINE",obj.Line),
                                        new SqlParameter("@MODEL",obj.Model),
                                        new SqlParameter("@FG_DATE",obj.FGDate),
                                        new SqlParameter("@FG_SERIAL",obj.FGSerial),

                                   };
                DT = DU.GetDataUsingProcedure("[PRC_REPORT_USED_CHILD_PART_ASSY]", parma);

            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_CHILD_PART_ASSY_REPORT ShowDetails() [PRC_REPORT_USED_CHILD_PART_ASSY]:", ex.Message);
                throw ex;
            }
            
            return DT;
        }

    }
}
