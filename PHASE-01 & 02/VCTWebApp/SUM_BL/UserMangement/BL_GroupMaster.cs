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
    public  class BL_GroupMaster
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

        public DataTable ShowDetails(PL_GroupMaster obj)
        {
            DL_GroupMaster dlobj=new DL_GroupMaster();
            return dlobj.ShowDetails(obj);
        }
        public DataTable GetGroups(PL_GroupMaster obj)
        {
            DL_GroupMaster dlobj = new DL_GroupMaster();
            return dlobj.ShowDetails(obj);
        }
        public DataTable GetGroupRights(PL_GroupMaster obj)
        {
            DL_GroupMaster dlobj = new DL_GroupMaster();
            return dlobj.GetGroupRights(obj);
        }
        public OperationResult Save(PL_GroupMaster obj)
        {
            DL_GroupMaster dlobj = new DL_GroupMaster();
            return dlobj.Save(obj);
        }
        public OperationResult Update(PL_GroupMaster obj)
        {
            DL_GroupMaster dlobj = new DL_GroupMaster();
            return dlobj.Update(obj);
        }
        public DataTable CheckTransation(PL_GroupMaster obj)
        {
            DL_GroupMaster dlobj = new DL_GroupMaster();
            return dlobj.CheckTransation(obj);
        }
        public OperationResult Delete(PL_GroupMaster obj)
        {
            DL_GroupMaster dlobj = new DL_GroupMaster();
            return dlobj.Delete(obj);
        }
        public OperationResult SaveUpdateGroupRights(DataTable dt, PL_GroupMaster obj)
        {
            DL_GroupMaster dlobj = new DL_GroupMaster();
            return dlobj.SaveUpdateGroupRights(dt, obj);
        }
        public bool ShowDetailsEdit(PL_GroupMaster oPL, TextBox txtGroupName)
        {
            bool bFlag = false;
            DL_GroupMaster dlobj = new DL_GroupMaster();
            DataTable DT = dlobj.ShowDetailsByID(oPL);
            if (DT.Rows.Count > 0)
            {
                txtGroupName.Text = DT.Rows[0]["GroupName"].ToString();
                bFlag = true;
            }
            return bFlag;
        }
    }
}
