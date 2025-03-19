using DENSO_VCT_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_VCT_PL
{
    public class PL_CONVEYOR_LINE_PC_MAPPING_MASTER : Common
    {
        public long RowId { get; set; }
        public string  LinePc { get; set; }
        public string Conveyor { get; set; }
        public bool Active { get; set; }

    }
}
