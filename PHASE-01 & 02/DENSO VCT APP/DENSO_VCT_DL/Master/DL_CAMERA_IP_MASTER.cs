
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

    public class DL_CAMERA_IP_MASTER
    {
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_CAMERA_IP_MASTER obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[6];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@CAM_ID", SqlDbType.VarChar, 50);
                param[1].Value = obj.CamId;
                param[2] = new SqlParameter("@CAM_IP", SqlDbType.VarChar, 50);
                param[2].Value = obj.CamIP;
                param[3] = new SqlParameter("@CAM_DESC", SqlDbType.VarChar, 50);
                param[3].Value = obj.CamDesc;
                param[4] = new SqlParameter("@ACTIVE", SqlDbType.VarChar, 50);
                param[4].Value = obj.Active;
                param[5] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 50);
                param[5].Value = obj.CreatedBy;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_CAMERA_IP_MASTER]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      

    }
}
