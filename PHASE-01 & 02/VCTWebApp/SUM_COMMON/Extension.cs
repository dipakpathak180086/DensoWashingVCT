using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COMMON
{
 /*========================================================================================
Procedure/Module :  Extension Methods For Input
Purpose          :  Common
Created By       :  Gautam
Created on       :  10-June-2014
Modified By      :  Gautam
Modified on      :  ------------------
Copyright (c) Bar Code India Ltd. All rights reserved.
========================================================================================*/
    /// <summary>
    /// 
    /// </summary>
    public static class Extension
    {
        public static bool IsNumeric(this string _data)
        {
            bool isNum;
            long retNum;
         
            isNum = Int64.TryParse(Convert.ToString(_data), System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;

            //System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^[1-9]\d*(\.\d+)?$");
            //return reg.IsMatch(_data);
        }
        /// <summary>
        /// Determines whether [is numeric or decimal] [the specified _data].
        /// </summary>
        /// <param name="_data">The _data.</param>
        /// <returns></returns>
        public static bool IsNumericOrDecimal(this string _data)
        {
            bool isNum;
            decimal retNum;

            isNum = decimal.TryParse(Convert.ToString(_data), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;

            //System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^[1-9]\d*(\.\d+)?$");
            //return reg.IsMatch(_data);
        }
        //public static bool IsDecimaldd(this string _data)
        //{
        //    bool isNum;
        //    decimal retNum;

        //    isNum = decimal.TryParse(Convert.ToString(_data),out retNum);
        //    return isNum;

        //    //System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^[1-9]\d*(\.\d+)?$");
        //    //return reg.IsMatch(_data);
        //}

        /// <summary>
        /// SQLs the date format.
        /// </summary>
        /// <param name="strDate">The string date.</param>
        /// <returns></returns>
        public static string SqlDateFormat(this string strDate)
        {
            DateTime sDate = new DateTime();
            if (IsDateTime(strDate))
            {
                if (!string.IsNullOrEmpty(strDate))
                {
                    bool suc = DateTime.TryParse(strDate, out sDate);
                    if (!suc)
                    {
                        sDate = Convert.ToDateTime(strDate.Split('/')[1] + "/" + strDate.Split('/')[0] + "/" + strDate.Split('/')[2]);
                    }
                }
            }
            return sDate.ToString("MM/dd/yyyy");
        }
        /// <summary>
        /// SQLs the date time format.
        /// </summary>
        /// <param name="strDate">The string date.</param>
        /// <returns></returns>
        public static string SqlDateTimeFormat(this string strDate)
        {
            DateTime sDate = new DateTime();
            if (IsDateTime(strDate))
            {
                bool suc = DateTime.TryParse(strDate, out sDate);
                if (!suc)
                {
                    sDate = Convert.ToDateTime(strDate.Split(' ')[0].Split('/')[1] + "/" + strDate.Split(' ')[0].Split('/')[0] + "/" + strDate.Split(' ')[0].Split('/')[2] + strDate.Split(' ')[1]);
                }
                else
                {
                    string stempdate = sDate.ToString("MM/dd/yyyy hh:mm:ss");
                    return stempdate;
                }
            }
            return sDate.ToString("MM/dd/yyyy hh:mm:ss").Replace("01/01/0001 00:00:00", "Null");
        }
        /// <summary>
        /// Determines whether [is date time] [the specified text date].
        /// </summary>
        /// <param name="txtDate">The text date.</param>
        /// <returns></returns>
        public static bool IsDateTime(this string txtDate)
        {
            DateTime tempDate;

            return DateTime.TryParse(txtDate, out tempDate) ? true : false;
        }
        /// <summary>
        /// Determines whether the specified string is decimal.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        public static bool IsDecimal(this string str)
        {
            bool result = false;
            if (!str.Trim().IsNumeric())
            {
                if (str.Contains('.'))
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
