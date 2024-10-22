
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

    public class DL_MODEL_MASTER
    {
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_MODEL_MASTER obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[14];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@MODEL_NO", SqlDbType.VarChar, 50);
                param[1].Value = obj.ModelNo;
                param[2] = new SqlParameter("@MODEL_NAME", SqlDbType.VarChar, 50);
                param[2].Value = obj.ModelName;
                param[3] = new SqlParameter("@CHILD_PART_NO", SqlDbType.VarChar, 50);
                param[3].Value = obj.ChildPartNo;
                param[4] = new SqlParameter("@CHILD_PART_NAME", SqlDbType.VarChar, 50);
                param[4].Value = obj.ChildPartName;
                param[5] = new SqlParameter("@LOT_LEN", SqlDbType.VarChar, 50);
                param[5].Value = obj.LotLength;
                param[6] = new SqlParameter("@WASHING_QTY", SqlDbType.VarChar, 50);
                param[6].Value = obj.WashingQty;
                param[7] = new SqlParameter("@STATUS", SqlDbType.VarChar, 50);
                param[7].Value = obj.Active;
                param[8] = new SqlParameter("@ROW_ID", SqlDbType.VarChar, 50);
                param[8].Value = obj.RowId;
                param[9] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 50);
                param[9].Value = obj.CreatedBy;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_MODEL_MASTER]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      

    }
}
