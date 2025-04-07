using DENSO_VCT_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_VCT_PL
{
    public class PL_LINE_ASSY_DASH : Common
    {
        public string LinePc { get; set; }

        /// <summary>
        /// Screen 1 Variables
        /// </summary>
        public string SC1Conveyor { get; set; }
        public string SC1ModelNo { get; set; }
        public string SC1ModelName { get; set; }
        public string SC1ChildPartNo { get; set; }
        public string SC1ChildPartName { get; set; }
        public string SC1LotNo  { get; set; }
        public string SC1TrayBarcode { get; set; }

        /// <summary>
        /// Scrren2 Variables
        /// </summary>
        public string SC2Conveyor { get; set; }
        public string SC2ModelNo { get; set; }
        public string SC2ModelName { get; set; }
        public string SC2ChildPartNo { get; set; }
        public string SC2ChildPartName { get; set; }
        public string SC2LotNo { get; set; }
        public string SC2TrayBarcode { get; set; }

        /// <summary>
        /// Scrren3 Variables
        /// </summary>
        public string SC3Conveyor { get; set; }
        public string SC3ModelNo { get; set; }
        public string SC3ModelName { get; set; }
        public string SC3ChildPartNo { get; set; }
        public string SC3ChildPartName { get; set; }
        public string SC3LotNo { get; set; }
        public string SC3TrayBarcode { get; set; }
    }
}