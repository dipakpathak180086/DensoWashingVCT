using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SUM_PL;
using SUM_DL;
using System.Data;
using System.Web.UI.WebControls;
using COMMON;

namespace SUM_BL
{
    public class BL_UserMaster
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
        
        public DataTable ShowUserDetails(PL_UserMaster obj)
        {
            DL_UserMaster dlobj = new DL_UserMaster();
            return dlobj.ShowUserDetails(obj);
        }
        public DataTable BindGroup(PL_UserMaster obj)
        {
            DL_UserMaster dlobj = new DL_UserMaster();
            return dlobj.BindGroup(obj);
        }
        public DataTable GetMailSetting(PL_UserMaster obj)
        {
            DL_UserMaster dlobj = new DL_UserMaster();
            return dlobj.GetMailSetting(obj);
        }
        public OperationResult Save(PL_UserMaster obj)
        {
            DL_UserMaster dlobj = new DL_UserMaster();
            return dlobj.Save(obj);
        }
        public OperationResult Update(PL_UserMaster obj)
        {
            DL_UserMaster dlobj = new DL_UserMaster();
            return dlobj.Update(obj);
        }
        public OperationResult Delete(PL_UserMaster obj)
        {
            DL_UserMaster dlobj = new DL_UserMaster();
            return dlobj.Delete(obj);
        }



        public bool ShowDetailsEdit(PL_UserMaster oPL, DropDownList ddlUsertype, TextBox txtUserName,
                                    TextBox txtUserID, TextBox txtPassword, DropDownList ddlPlant, DropDownList ddlDepartment,TextBox txtEmail,TextBox txtPinNo)
        {
            bool bFlag = false;
            DL_UserMaster dlobj = new DL_UserMaster();
            DataTable DT = dlobj.ShowDetailsByID(oPL);
            if (DT.Rows.Count > 0)
            {
                ddlUsertype.SelectedValue = DT.Rows[0]["GroupID"].ToString();
                txtUserName.Text = DT.Rows[0]["USERNAME"].ToString();
                txtUserID.Text = DT.Rows[0]["UserCode"].ToString();
                txtPassword.Text = DT.Rows[0]["PASSWORD"].ToString();
                ddlPlant.SelectedValue = DT.Rows[0]["PlantCode"].ToString();
                ddlDepartment.SelectedValue = DT.Rows[0]["DepartmentCode"].ToString();
                txtEmail.Text= DT.Rows[0]["EmailId"].ToString();
                txtPinNo.Text= DT.Rows[0]["PinNo"].ToString();
                bFlag = true;
            }
            return bFlag;
        }

        public DataTable ValidateUser(PL_UserMaster obj)
        {
            DL_UserMaster dlobj = new DL_UserMaster();
            return dlobj.ValidateUser(obj); 
        }
        public DataTable UpdatePassword(PL_UserMaster obj)
        {
            DL_UserMaster dlobj = new DL_UserMaster();
            return dlobj.UpdatePassword(obj);
        }

        public DataTable BindPlant()
        {
            DL_UserMaster dlobj = new DL_UserMaster();
            return dlobj.BindPlant();
        }
        public DataTable BindDepartment()
        {
            DL_UserMaster dlobj = new DL_UserMaster();
            return dlobj.BindDepartment();
        }
    }
}
