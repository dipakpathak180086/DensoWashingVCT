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
    public class BL_CONVEYOR_ASSY_REPORT
    {
        public DataTable BL_ExecuteTask(PL_CONVEYOR_ASSY_REPORT objPl)
        {
            DL_CONVEYOR_ASSY_REPORT objDl = new DL_CONVEYOR_ASSY_REPORT();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
