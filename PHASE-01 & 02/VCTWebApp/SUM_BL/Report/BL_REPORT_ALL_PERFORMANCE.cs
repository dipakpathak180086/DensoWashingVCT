using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SUM_PL;
using System.Data;
using System.Web.UI.WebControls;
using COMMON;
using SUM_DL;

namespace SUM_BL
{
    public  class BL_REPORBL_REPORT_ALL_PERFORMANCET_LOG
    {
        public ValidateResult ValidateData(string _Data, ValidateType _type)
        {
          
            ValidateResult oResult = ValidateResult.INVALID;
            try
            {
                if (!string.IsNullOrEmpty(_Data))
                {
                    if (_type.ToString() == ValidateType.IsString.ToString())
                    {
                        oResult = ValidateResult.VALID;
                    }
                    else if (_type.ToString() == ValidateType.IsNumericOrDecimal.ToString())
                    {
                        if (_Data.IsNumericOrDecimal())
                        {
                            oResult = ValidateResult.VALID;
                        }
                    }
                    else if (_type.ToString() == ValidateType.IsNumeric.ToString())
                    {
                        if (_Data.IsNumeric())
                        {
                            oResult = ValidateResult.VALID;
                        }
                    }
                    else if (_type.ToString() == ValidateType.IsDateTime.ToString())
                    {
                        if (_Data.IsDateTime())
                        {
                            oResult = ValidateResult.VALID;
                        }
                    }
                    else if (_type.ToString() == ValidateType.IsDecimal.ToString())
                    {
                        if (_Data.IsDecimal())
                        {
                            oResult = ValidateResult.VALID;
                        }
                    }
                }
                else
                {
                    oResult = ValidateResult.EMPTY;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oResult;

        }

        public DataTable ShowDetails(PL_REPORT_ALL_PERFORMANCE_DATA obj)
        {
            DL_REPORT_ALL_PERFORMANCE dlobj=new DL_REPORT_ALL_PERFORMANCE();
            return dlobj.ShowDetails(obj);
        }
      
    }
}
