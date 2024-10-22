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
    public class BL_PC_MENU
    {
        public DataTable BL_ExecuteTask(PL_PC_MENU objPl)
        {
            DL_PC_MENU objDl = new DL_PC_MENU();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
