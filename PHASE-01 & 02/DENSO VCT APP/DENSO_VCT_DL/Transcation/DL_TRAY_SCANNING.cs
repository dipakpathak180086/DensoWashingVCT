
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

    public class DL_TRAY_SCANNING
    {
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_TRAY_SCANNING obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[11];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@MODEL_NO", SqlDbType.VarChar, 50);
                param[1].Value = obj.ModelNo;
                param[2] = new SqlParameter("@CHILD_PART_NO", SqlDbType.VarChar, 50);
                param[2].Value = obj.ChildPartNo;
                param[3] = new SqlParameter("@BARCODE", SqlDbType.VarChar, 500);
                param[3].Value = obj.Barcode;
                param[4] = new SqlParameter("@LOT_NO", SqlDbType.VarChar, 50);
                param[4].Value = obj.LotNo;
                param[5] = new SqlParameter("@TRAY_BARCODE", SqlDbType.VarChar, 500);
                param[5].Value = obj.TrayBarcode;
                param[6] = new SqlParameter("@QTY", SqlDbType.VarChar, 50);
                param[6].Value = obj.Qty;
                param[7] = new SqlParameter("@ROW_ID", SqlDbType.VarChar, 500);
                param[7].Value = obj.RowId;
                param[8] = new SqlParameter("@REF_NO", SqlDbType.VarChar, 500);
                param[8].Value = obj.RefNo;
                param[9] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 50);
                param[9].Value = obj.CreatedBy;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_TRAY_SCANNING]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      

    }
}
