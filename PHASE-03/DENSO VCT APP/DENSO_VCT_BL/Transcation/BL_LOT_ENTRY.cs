
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
    public class BL_LOT_ENTRY
    {
        public DataTable BL_ExecuteTask(PL_LOT_ENTRY objPl)
        {
            DL_LOT_ENTRY objDl = new DL_LOT_ENTRY();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
