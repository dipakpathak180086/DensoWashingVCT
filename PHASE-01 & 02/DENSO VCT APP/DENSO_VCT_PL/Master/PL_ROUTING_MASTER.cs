using DENSO_VCT_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_VCT_PL
{
    public class PL_ROUTING_MASTER : Common
    {
        public long RowId { get; set; }
        public string ModelNo { get; set; }
        public string ChildPartNo { get; set; }
        public string ConveyorNo { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int Avg { get; set; }
        public bool Active { get; set; }

    }
}
