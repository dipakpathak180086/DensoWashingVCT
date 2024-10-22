using DENSO_VCT_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_VCT_PL
{
    public class PL_NG_MASTER : Common
    {
        public string ModelNo { get; set; }
        public string ChildPartNo { get; set; }
        public string Lot { get; set; }
        public bool Active { get; set; }

    }
}
