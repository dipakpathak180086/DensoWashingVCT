using SUM_DL;
using SUM_PL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUM_BL
{
    public class BL_VCT_SpecialReport
    {
        public DataTable BindBlankdt(PL_VCT_SpecialReport obj)
        {
            DL_VCT_SpecialReport dlobj = new DL_VCT_SpecialReport();
            return dlobj.BindBlankdt(obj);
        }
        public DataTable BindDataDt(PL_VCT_SpecialReport obj)
        {
            DL_VCT_SpecialReport dlobj = new DL_VCT_SpecialReport();
            return dlobj.BindDataDt(obj);
        }
    }
}
