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

    public class DL_LINE_ASSY_DASH
    {
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTaskDashBoard(PL_LINE_ASSY_DASH obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[11];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@LINE_PC", SqlDbType.VarChar, 50);
                param[1].Value = obj.LinePc;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_GET_DASHBOARD_DATA]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion      

    }
}
