using DENSO_VCT_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_VCT_PL
{
    public class PL_LINE_ASSY : Common
    {
        public string ModelNo { get; set; } = null;
        public string ChildPartNo { get; set; } = null;
        public string LotNo { get; set; } = null;
        public string TrayBarcode { get; set; } = null;
        public string Conveyor { get; set; }
        public string  PcName { get; set; }
        public string LogMSG { get; set; }

    }
}