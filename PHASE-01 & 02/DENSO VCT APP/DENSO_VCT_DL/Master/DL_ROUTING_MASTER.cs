
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

    public class DL_ROUTING_MASTER
    {
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_ROUTING_MASTER obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[15];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@ROW_ID", SqlDbType.VarChar, 50);
                param[1].Value = obj.RowId;
                param[2] = new SqlParameter("@MODEL_NO", SqlDbType.VarChar, 50);
                param[2].Value = obj.ModelNo;
                param[3] = new SqlParameter("@CHILD_PART_NO", SqlDbType.VarChar, 50);
                param[3].Value = obj.ChildPartNo;
                param[4] = new SqlParameter("@CONVEYOR_NO", SqlDbType.VarChar, 50);
                param[4].Value = obj.ConveyorNo;
                param[5] = new SqlParameter("@MIN", SqlDbType.VarChar, 50);
                param[5].Value = obj.Min;
                param[6] = new SqlParameter("@MAX", SqlDbType.VarChar, 50);
                param[6].Value = obj.Max;
                param[7] = new SqlParameter("@AVG", SqlDbType.VarChar, 50);
                param[7].Value = obj.Avg;
                param[8] = new SqlParameter("@ACTIVE", SqlDbType.VarChar, 50);
                param[8].Value = obj.Active;
                param[9] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 50);
                param[9].Value = obj.CreatedBy;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_ROUTING_MASTER]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      

    }
}
