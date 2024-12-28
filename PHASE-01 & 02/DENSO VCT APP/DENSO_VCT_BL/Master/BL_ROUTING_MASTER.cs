

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
    public class BL_ROUTING_MASTER
    {
        public DataTable BL_ExecuteTask(PL_ROUTING_MASTER objPl)
        {
            DL_ROUTING_MASTER objDl = new DL_ROUTING_MASTER();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
