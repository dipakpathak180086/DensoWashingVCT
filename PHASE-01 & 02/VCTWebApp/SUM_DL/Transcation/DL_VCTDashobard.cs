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
  public  class DL_VCTDashobard
    {
        DataTable DT = new DataTable();
        Datautility DU = new Datautility();
        public DataTable ShowDetails(PL_VCTDashboard obj)
        {
            try
            {
                if (obj.DbType == "GET_DASHBOARD_SERIAL")
                {
                    SqlParameter[] parma = {
                                        new SqlParameter("@TYPE",obj.DbType),
                                        new SqlParameter("@MODEL",obj.Model),
                                        new SqlParameter("@PART",obj.Part),
                                        new SqlParameter("@DATE",obj.Date),
                                        new SqlParameter("@LOT",obj.LotNo),
                                        new SqlParameter("@LOT_DATE",obj.LotDate),
                                         new SqlParameter("@SERIAL",obj.Serai),
                                   };
                    DT = DU.GetDataUsingProcedure("[PRC_DASHBOARD_SERIAL_SERIES]", parma);
                }
                else
                {
                    SqlParameter[] parma = {
                                        new SqlParameter("@TYPE",obj.DbType),
                                        new SqlParameter("@MODEL",obj.Model),
                                        new SqlParameter("@PART",obj.Part),
                                        new SqlParameter("@DATE",obj.Date),
                                        new SqlParameter("@SERIAL",obj.Serai),
                                        new SqlParameter("@REJECTION",obj.Rejection),
                                        new SqlParameter("@LOT",obj.LotNo),
                                   };
                    DT = DU.GetDataUsingProcedure("[PRC_DASHBOARD_SUSPECTED_LOT]", parma);
                }
              
            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_VCTDashobard ShowDetails() []:" , ex.Message);
                throw ex;
            }
            
            return DT;
        }
        public DataTable AfterSubpectedLotDataDetails(PL_VCTDashboard obj)
        {
            try
            {
                SqlParameter[] parma = {
                                        new SqlParameter("@MODEL",obj.Model),
                                        new SqlParameter("@PART",obj.Part),
                                        new SqlParameter("@LOT",obj.LotNo),
                                   };
                DT = DU.GetDataUsingProcedure("[PRC_AFTER_SUP_LOT_DATA]", parma);

            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_VCTDashobard AfterSubpectedLotDataDetails() [PRC_AFTER_SUP_LOT_DATA]:", ex.Message);
                throw ex;
            }

            return DT;
        }
        public DataTable AfterSubpectedLotDataDetailsForStep03(PL_VCTDashboard obj)
        {
            try
            {
                SqlParameter[] parma = {
                                        new SqlParameter("@MODEL",obj.Model),
                                        new SqlParameter("@PART",obj.Part),
                                        new SqlParameter("@LOT",obj.LotNo),
                                   };
                DT = DU.GetDataUsingProcedure("[PRC_AFTER_SUP_LOT_DATA_STEP3]", parma);

            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_VCTDashobard AfterSubpectedLotDataDetails() [PRC_AFTER_SUP_LOT_DATA]:", ex.Message);
                throw ex;
            }

            return DT;
        }


    }
}
