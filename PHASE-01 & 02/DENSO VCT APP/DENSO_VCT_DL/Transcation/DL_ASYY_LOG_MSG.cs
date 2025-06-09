
using DENSO_VCT_COMMON;
using DENSO_VCT_PL;
using SatoLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_VCT_DL
{

    public class DL_ASYY_LOG_MSG
    {
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_ASYY_LOG_MSG obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[11];

                param[0] = new SqlParameter("@LINE", SqlDbType.VarChar, 100);
                param[0].Value = obj.Line;
                param[1] = new SqlParameter("@CONVEYOR", SqlDbType.VarChar, 50);
                param[1].Value = obj.Conveyor;
                param[2] = new SqlParameter("@PC", SqlDbType.VarChar, 50);
                param[2].Value = obj.PC;
                param[3] = new SqlParameter("@SCANNER_IP", SqlDbType.VarChar, 500);
                param[3].Value = obj.ScannerIp;
                param[4] = new SqlParameter("@SCANNER_DATA", SqlDbType.VarChar, 50);
                param[4].Value = obj.ScannerData;
                param[5] = new SqlParameter("@LOG_MSG", SqlDbType.VarChar, 500);
                param[5].Value = obj.LogMsg;
                param[6] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 50);
                param[6].Value = obj.CreatedBy;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_ASSY_LINE_LOG_MSG]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      

    }
}
