using DENSO_VCT_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_VCT_PL
{
    public class PL_MODEL_MASTER : Common
    {
        public string ModelNo { get; set; }
        public string ModelName { get; set; }
        public string ChildPartNo { get; set; }
        public string ChildPartName { get; set; }
        public int LotLength { get; set; }
        public int LotQtyLength { get; set; }
        public int RowId { get; set; }
        public bool Active { get; set; }

    }
}
