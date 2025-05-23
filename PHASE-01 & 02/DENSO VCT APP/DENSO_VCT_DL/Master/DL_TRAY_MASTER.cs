﻿
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

    public class DL_TRAY_MASTER
    {
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_TRAY_MASTER obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[10];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@TRAY_CODE", SqlDbType.VarChar, 50);
                param[1].Value = obj.TrayCode;
                param[2] = new SqlParameter("@TRAY_NAME", SqlDbType.VarChar, 50);
                param[2].Value = obj.TrayName;
                param[3] = new SqlParameter("@PACK_SIZE", SqlDbType.VarChar, 50);
                param[3].Value = obj.PackSize;
                param[4] = new SqlParameter("@IS_BLOCK", SqlDbType.VarChar, 50);
                param[4].Value = obj.IsBlock;
                param[5] = new SqlParameter("@ACTIVE", SqlDbType.VarChar, 50);
                param[5].Value = obj.Active;
                param[6] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 50);
                param[6].Value = obj.CreatedBy;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_TRAY_MASTER]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      

    }
}
