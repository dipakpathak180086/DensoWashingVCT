using DENSO_VCT_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_VCT_PL
{
    public class PL_CONVEYOR_ASSY_REPORT : Common
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Model_No { get; set; }
        public string Child_No { get; set; }
        public string Lot_No { get; set; }
        public string ConveyorNo { get; set; }
    }
}
