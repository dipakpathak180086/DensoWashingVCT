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
    public class BL_SCANNER_TRIGGER_TIME_MASTER
    {
        public DataTable BL_ExecuteTask(PL_SCANNER_TRIGGER_TIME_MASTER objPl)
        {
            DL_SCANNER_TRIGGER_TIME_MASTER objDl = new DL_SCANNER_TRIGGER_TIME_MASTER();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
