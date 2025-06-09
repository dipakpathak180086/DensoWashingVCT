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
    public class BL_ASYY_LOG_MSG
    {
        public DataTable BL_ExecuteTask(PL_ASYY_LOG_MSG objPl)
        {
            DL_ASYY_LOG_MSG objDl = new DL_ASYY_LOG_MSG();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
