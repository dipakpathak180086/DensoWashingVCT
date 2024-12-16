using DENSO_VCT_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_VCT_PL
{
    public class PL_TRAY_MASTER : Common
    {
        public string TrayCode { get; set; }
        public string TrayName { get; set; }
        public  int PackSize { get; set; }
        public bool IsBlock { get; set; }
        public bool Active { get; set; }

    }
}
