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
    public class BL_ENABLE_DISABLE_ASSY
    {
        public DataTable BL_ExecuteTask(PL_ENABLE_DISABLE_ASSY objPl)
        {
            DL_ENABLE_DISABLE_ASSY objDl = new DL_ENABLE_DISABLE_ASSY();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
