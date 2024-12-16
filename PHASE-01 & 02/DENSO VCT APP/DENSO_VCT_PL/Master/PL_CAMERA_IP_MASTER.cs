using DENSO_VCT_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_VCT_PL
{
    public class PL_CAMERA_IP_MASTER : Common
    {
        public string CamId { get; set; }
        public string CamIP { get; set; }
        public string CamDesc { get; set; }
        public bool Active { get; set; }

    }
}
