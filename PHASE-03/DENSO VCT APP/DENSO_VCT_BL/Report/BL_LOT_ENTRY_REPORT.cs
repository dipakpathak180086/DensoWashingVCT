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
    public class BL_LOT_ENTRY_REPORT
    {
        public DataTable BL_ExecuteTask(PL_LOT_ENTRY_REPORT objPl)
        {
            DL_LOT_ENTRY_REPORT objDl = new DL_LOT_ENTRY_REPORT();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
