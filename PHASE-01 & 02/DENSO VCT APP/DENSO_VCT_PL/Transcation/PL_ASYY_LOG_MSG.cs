using DENSO_VCT_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_VCT_PL
{
    public class PL_ASYY_LOG_MSG : Common
    {
        public string Line { get; set; }
        public string Conveyor { get; set; }
        public string PC { get; set; }
        public string ScannerIp { get; set; }
        public string ScannerData { get; set; }
        public string LogMsg { get; set; }
    }
}
