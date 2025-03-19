using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENSO_VCT_DL;
using DENSO_VCT_PL;

namespace DENSO_VCT_BL
{
    public class BL_TRAY_SCANNING
    {
        public DataTable BL_ExecuteTask(PL_TRAY_SCANNING objPl)
        {
            DL_TRAY_SCANNING objDl = new DL_TRAY_SCANNING();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
