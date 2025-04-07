using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENSO_VCT_COMMON;
using DENSO_VCT_PL;

using SatoLib;


namespace DENSO_VCT_DL
{
    public class DL_CONVEYOR_ASSY_REPORT
    {

        
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_CONVEYOR_ASSY_REPORT obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[20];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@FROM_DATE", SqlDbType.VarChar, 50);
                param[1].Value = obj.FromDate;
                param[2] = new SqlParameter("@TO_DATE", SqlDbType.VarChar, 500);
                param[2].Value = obj.ToDate;
                param[3] = new SqlParameter("@MODEL_NO", SqlDbType.VarChar, 500);
                param[3].Value = obj.Model_No;
                param[4] = new SqlParameter("@CHILD_PART", SqlDbType.VarChar, 500);
                param[4].Value = obj.Child_No;
                param[5] = new SqlParameter("@LOT", SqlDbType.VarChar, 500);
                param[5].Value = obj.Lot_No;
                param[6] = new SqlParameter("@CONVEYOR", SqlDbType.VarChar, 500);
                param[6].Value = obj.ConveyorNo;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_CONVEYOR_TRAY_ASSY_REPORT]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      
    }
}
