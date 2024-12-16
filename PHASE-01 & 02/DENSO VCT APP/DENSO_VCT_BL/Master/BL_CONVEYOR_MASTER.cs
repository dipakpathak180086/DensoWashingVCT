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
    public class BL_CONVEYOR_MASTER
    {
        public DataTable BL_ExecuteTask(PL_CONVEYOR_MASTER objPl)
        {
            DL_CONVEYOR_MASTER objDl = new DL_CONVEYOR_MASTER();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
