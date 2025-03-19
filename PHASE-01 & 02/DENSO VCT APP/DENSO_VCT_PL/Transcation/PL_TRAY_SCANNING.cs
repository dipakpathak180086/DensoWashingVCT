using DENSO_VCT_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_VCT_PL
{
    public class PL_TRAY_SCANNING : Common
    {
        public string ModelNo { get; set; } = null;
        public string ChildPartNo { get; set; } = null;
        public string Barcode { get; set; } = null;
        public string LotNo { get; set; } = null;
        public string TrayBarcode { get; set; } = null;
        public int? Qty { get; set; } = null;
        public long? RowId { get; set; } = null;
        public string RefNo { get; set; }

    }
}