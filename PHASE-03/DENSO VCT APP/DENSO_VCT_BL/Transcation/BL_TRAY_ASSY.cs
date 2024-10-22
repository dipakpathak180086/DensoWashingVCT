
using DENSO_VCT_DL;
using DENSO_VCT_PL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DENSO_VCT_BL
{
    public class BL_TRAY_ASSY
    {
        public DataTable BL_ExecuteTask(PL_TRAY_ASSY objPl)
        {
            DL_TRAY_ASSY objDl = new DL_TRAY_ASSY();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
