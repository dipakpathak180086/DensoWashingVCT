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
    public class DL_LOT_ENTRY
    {
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_LOT_ENTRY obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[20];

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
                param[5] = new SqlParameter("@LOT_NO", SqlDbType.VarChar, 50);
                param[5].Value = obj.LotNo;
                param[6] = new SqlParameter("@LOT_QTY", SqlDbType.VarChar, 50);
                param[6].Value = obj.LotQty;
                param[7] = new SqlParameter("@TM_NAME", SqlDbType.VarChar, 50);
                param[7].Value = obj.TMName;
                param[8] = new SqlParameter("@TL_NAME", SqlDbType.VarChar, 50);
                param[8].Value = obj.TLName;
                param[9] = new SqlParameter("@ROW_ID", SqlDbType.VarChar, 50);
                param[9].Value = obj.RowId;
                param[10] = new SqlParameter("@SHIFT", SqlDbType.VarChar, 50);
                param[10].Value = obj.Shift;
                param[11] = new SqlParameter("@CHK_MANUAL_DATE", SqlDbType.VarChar, 50);
                param[11].Value = obj.Manual_Date;
                param[12] = new SqlParameter("@M_DATE", SqlDbType.VarChar, 50);
                param[12].Value = obj.Date;
                param[13] = new SqlParameter("@M_TIME", SqlDbType.VarChar, 50);
                param[13].Value = obj.Time;
                param[14] = new SqlParameter("@TRAY_NO", SqlDbType.VarChar, 50);
                param[14].Value = obj.TrayNo;
                param[15] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 50);
                param[15].Value = obj.CreatedBy;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_LOT_ENTRY]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      
    }
}
