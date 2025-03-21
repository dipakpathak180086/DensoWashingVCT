﻿using DENSO_VCT_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_VCT_PL
{
    public class PL_LOT_ENTRY : Common
    {
        public string ModelName { get; set; }
        public string ModelNo { get; set; }
        public string ChildPartNo { get; set; }
        public string ChildPartName { get; set; }
        public string LotNo { get; set; }
        public int LotQty { get; set; }
        public Int64 RowId { get; set; }
        public string TMName { get; set; }
        public string Shift { get; set; }
        public string TLName { get; set; }
        public string SerialNo { get; set; }
        public string VendorCode { get; set; }
        public string Barcode { get; set; }

        public bool Manual_Date { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Tray01 { get; set; }
        public string Tray02 { get; set; }
        public string Tray03 { get; set; }
        public string Tray04 { get; set; }
    }
}
