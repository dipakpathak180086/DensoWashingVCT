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
    public class BL_MODEL_MASTER
    {
        public DataTable BL_ExecuteTask(PL_MODEL_MASTER objPl)
        {
            DL_MODEL_MASTER objDl = new DL_MODEL_MASTER();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
