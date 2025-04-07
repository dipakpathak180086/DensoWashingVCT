
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

    public class DL_LINE_ASSY
    {
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_LINE_ASSY obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[11];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@PC_NAME", SqlDbType.VarChar, 50);
                param[1].Value = obj.PcName;
                param[2] = new SqlParameter("@CONVEYOR", SqlDbType.VarChar, 50);
                param[2].Value = obj.Conveyor;
                param[3] = new SqlParameter("@MODEL_NO", SqlDbType.VarChar, 50);
                param[3].Value = obj.ModelNo;
                param[4] = new SqlParameter("@CHILD_PART_NO", SqlDbType.VarChar, 50);
                param[4].Value = obj.ChildPartNo;
                param[5] = new SqlParameter("@LOT_NO", SqlDbType.VarChar, 50);
                param[5].Value = obj.LotNo;
                param[6] = new SqlParameter("@TRY_BARCODE", SqlDbType.VarChar, 50);
                param[6].Value = obj.TrayBarcode;
                param[7] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 50);
                param[7].Value = obj.CreatedBy;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_TRAY_ASSY_SCANNING]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion      

    }
}
