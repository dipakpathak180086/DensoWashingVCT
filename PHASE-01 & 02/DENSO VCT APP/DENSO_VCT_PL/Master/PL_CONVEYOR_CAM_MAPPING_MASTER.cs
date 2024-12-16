using DENSO_VCT_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_VCT_PL
{
    public class PL_CONVEYOR_CAM_MAPPING_MASTER : Common
    {
        public long RowId { get; set; }
        public string CamId { get; set; }
        public string CamIP { get; set; }
        public string Conveyor { get; set; }
        public bool Active { get; set; }

    }
}
