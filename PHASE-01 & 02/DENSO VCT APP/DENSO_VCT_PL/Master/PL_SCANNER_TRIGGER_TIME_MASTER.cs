using DENSO_VCT_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_VCT_PL
{
    public class PL_SCANNER_TRIGGER_TIME_MASTER : Common
    {
        public string ConveyorNo { get; set; }
        public int TriggerTime { get; set; }
        public bool Active { get; set; }

    }
}
