using DENSO_VCT_PL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENSO_VCT_DL;


namespace DENSO_VCT_BL
{
    public class BL_TRAY_LOG_REPORT
    {
        public DataTable BL_ExecuteTask(PL_TRAY_LOG_REPORT objPl)
        {
            DL_TRAY_LOG_REPORT objDl = new DL_TRAY_LOG_REPORT();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
