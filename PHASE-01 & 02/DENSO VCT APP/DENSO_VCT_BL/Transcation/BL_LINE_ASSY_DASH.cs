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
    public class BL_LINE_ASSY_DASH
    {
        public DataTable BL_ExecuteTask(PL_LINE_ASSY_DASH objPl)
        {
            DL_LINE_ASSY_DASH objDl = new DL_LINE_ASSY_DASH();
            return objDl.DL_ExecuteTaskDashBoard(objPl);
        }


    }
}
