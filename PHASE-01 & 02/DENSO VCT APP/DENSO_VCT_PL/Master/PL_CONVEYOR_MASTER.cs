using DENSO_VCT_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_VCT_PL
{
    public class PL_CONVEYOR_MASTER : Common
    {
        public string ConveyorNo { get; set; }
        public string ConveyorName { get; set; }
        public string SeqNo { get; set; }
        public bool Active { get; set; }

    }
}
