using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace VCTWebApp
{
    public class GlobalVariable
    {
        public static string mPrn = string.Empty;
        public static string mPrinterName = "";
        public static string mPalletPrnFileName = "PALLET_LABEL.PRN";
        public static bool ReadLocationPrn()
        {
            string _sPrnWithMaster = AppDomain.CurrentDomain.BaseDirectory + "\\Location.PRN";
            string prn = string.Empty;

            if (File.Exists(_sPrnWithMaster))
            {
                StreamReader sr = new StreamReader(_sPrnWithMaster);
                prn = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();

                mPrn = prn;
            }
            return true;
        }
    }
}
