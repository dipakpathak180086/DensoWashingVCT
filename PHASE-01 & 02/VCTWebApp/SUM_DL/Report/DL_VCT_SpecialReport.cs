using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUM_PL;

namespace SUM_DL
{
    public class DL_VCT_SpecialReport
    {
        public DataTable BindBlankdt(PL_VCT_SpecialReport obj)
        {
            DataTable DT = new DataTable();
            try
            {
                Datautility DU = new Datautility();
                SqlParameter[] parma = {
                                       new SqlParameter("@FROM_DATE",obj.FromDate ),
                                        new SqlParameter("@TO_DATE",obj.ToDate ),
                                         new SqlParameter("@ModelNo",obj.ModelNo ),
                                   };

                DT = DU.GetDataUsingProcedure("[PRC_VCT_SPECIAL_REPORT_Blank]", parma);
            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "PRC_VCT_SPECIAL_REPORT_Blank", ex.Message);
                throw ex;
            }
            finally
            {
            }
            return DT;
        }


        public DataTable BindDataDt(PL_VCT_SpecialReport obj)
        {
            DataTable DT = new DataTable();
            try
            {
                Datautility DU = new Datautility();
                SqlParameter[] parma = {
                                        new SqlParameter("@FROM_DATE",obj.FromDate),
                                        new SqlParameter("@TO_DATE",obj.ToDate),
                                        new SqlParameter("@ModelNo",obj.ModelNo),
                                   };

                DT = DU.GetDataUsingProcedure("[PRC_VCT_SPECIAL_REPORT_DTL]", parma);
            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "PRC_VCT_SPECIAL_REPORT_DTL", ex.Message);
                throw ex;
            }
            finally
            {
            }
            return DT;
        }
    }
}
