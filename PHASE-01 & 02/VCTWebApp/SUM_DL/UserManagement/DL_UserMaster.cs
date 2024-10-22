using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SUM_PL;
using COMMON;

namespace SUM_DL
{
    public class DL_UserMaster
    {

        DataTable DT = new DataTable();
        Datautility DU = new Datautility();
        public DataTable ShowUserDetails(PL_UserMaster obj)
        {
            try
            {
                SqlParameter[] parma = {
                                        new SqlParameter("@Type","SELECT"),
                                   };
                DT = DU.GetDataUsingProcedure("[PRC_UserMaster]", parma);
            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_UserMaster ShowUserDetails() [PRC_UserMaster]:" + obj.CreatedBy, ex.Message);
                throw ex;
            }
            //finally
            //{
            //    CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Denso" + "  ::  DL_UserMaster ShowDetails() [USP_M_User]:" + obj.CreatedBy, "");
            //}
            return DT;
        }

        public DataTable ShowDetailsByID(PL_UserMaster obj)
        {
            try
            {
                SqlParameter[] parma = {
                                        new SqlParameter("@Type","ShowDetailsByID"),
                                        new SqlParameter("@UserCode",obj.UserID),
                                   };
                DT = DU.GetDataUsingProcedure("[PRC_UserMaster]", parma);

            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_UserMaster ShowDetailsByID() [USP_M_User]:" + "", ex.Message);
                throw ex;
            }
            //finally
            //{
            //    CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Denso" + "  ::  DL_UserMaster ShowDetailsByID() [USP_M_User]:" + "", "");
            //}
            return DT;
        }
        public DataTable BindGroup(PL_UserMaster obj)
        {
            try
            {
                SqlParameter[] parma = {
                                        new SqlParameter("@Type","GETUSERGROUP"),
                                   };
                DT = DU.GetDataUsingProcedure("[PRC_UserMaster]", parma);

            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_UserMaster GETUSERGROUP() [PRC_UserMaster]:" + "", ex.Message);
                throw ex;
            }
            //finally
            //{
            //    CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Denso" + "  ::  DL_UserMaster GETUSERGROUP() [PRC_UserMaster]:" + "", "");
            //}
            return DT;
        }


        public OperationResult Save(PL_UserMaster obj)
        {
            OperationResult oPeration = OperationResult.SaveError;
            try
            {
                if (!this.CheckDuplicate(obj))
                {
                    SqlParameter[] parma = {
                                        new SqlParameter("@Type","INSERT"),
                                        new SqlParameter("@UserCode",obj.UserCode),
                                        new SqlParameter("@UserName",obj.UserName),
                                        new SqlParameter("@Password",obj.Password),
                                        new SqlParameter("@GroupName",obj.GroupName),
                                        new SqlParameter("@EmailId",obj.EmailID),
                                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                                        new SqlParameter("@PinNo",obj.PinNo),
                                   };
                    int Result = DU.ExecuteProcedure("[PRC_UserMaster]", parma);
                    if (Result > 0)
                    {
                        oPeration = OperationResult.SaveSuccess;
                    }
                }
                else
                {
                    oPeration = OperationResult.Duplicate;
                }
                
            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_UserMaster Save() [PRC_UserMaster]:" + obj.CreatedBy, ex.Message);
                throw ex;
            }
            //finally
            //{
            //    CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Denso" + "  ::  DL_UserMaster Save() [PRC_UserMaster]:" + obj.CreatedBy, "");
            //}
            return oPeration;
        }


        public bool CheckDuplicate(PL_UserMaster obj)
        {
            bool isDuplicate = false;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] parma = {
                                        new SqlParameter("@Type","CHECKDUP"),
                                        new SqlParameter("@UserCode",obj.UserCode),
                                   };
                DT = DU.GetDataUsingProcedure("[PRC_UserMaster]", parma);

                if (DT.Rows.Count > 0)
                {
                    isDuplicate = true;
                    //VariableInfo.sbDuplicateCount.Append(Convert.ToString(obj.UserCode) + ",");
                }

                else
                {
                    //VariableInfo.sbSaveCount.Append(Convert.ToString(obj.UserCode) + ",");
                    isDuplicate = false;
                }


            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_UserMaster CheckDuplicate() [PRC_UserMaster]:" + obj.CreatedBy, ex.Message);
                throw ex;
            }
            //finally
            //{
            //    CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Denso" + "  ::  DL_UserMaster CheckDuplicate() [USP_M_User]:" + obj.CreatedBy, "");
            //}
            return isDuplicate;
        }

        public OperationResult Update(PL_UserMaster obj)
        {
            OperationResult oPeration = OperationResult.UpdateError;
            try
            {
                SqlParameter[] parma = {
                                        new SqlParameter("@Type","UPDATE"),
                                        new SqlParameter("@UserCode",obj.UserCode),
                                        new SqlParameter("@UserName",obj.UserName),
                                        new SqlParameter("@Password",obj.Password),
                                        new SqlParameter("@GroupName",obj.GroupName),
                                        new SqlParameter("@EmailId",obj.EmailID),
                                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                                        new SqlParameter("@PlantCode",obj.PlantCode),
                                        new SqlParameter("@DepartmentCode",obj.DepartmentCode),
                                        new SqlParameter("@PinNo",obj.PinNo),
                                   };
                int Result = DU.ExecuteProcedure("[PRC_UserMaster]", parma);
                if (Result > 0)
                {
                    oPeration = OperationResult.UpdateSuccess;
                }
            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_UserMaster Update() [USP_M_User]:" + obj.CreatedBy, ex.Message);
                throw ex;
            }
            //finally
            //{
            //    CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Denso" + "  ::  DL_UserMaster Update() [USP_M_User]:" + obj.CreatedBy, "");
            //}
            return oPeration;
        }

        public OperationResult Delete(PL_UserMaster obj)
        {
            OperationResult oPeration = OperationResult.DeleteError;
            try
            {
                SqlParameter[] parma = {
                                        new SqlParameter("@Type","DELETE"),
                                        new SqlParameter("@UserCode",obj.UserCode),
                                   };
                int Result = DU.ExecuteProcedure("[PRC_UserMaster]", parma);
                if (Result > 0)
                {
                    oPeration = OperationResult.DeleteSuccess;
                }
            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_UserMaster Delete() [USP_M_User]:" + obj.CreatedBy, ex.Message);
                throw ex;
            }
            //finally
            //{
            //    CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Denso" + "  ::  DL_UserMaster Delete() [USP_M_User]:" + obj.CreatedBy, "");
            //}
            return oPeration;
        }

        public DataTable BindPlant()
        {
            try
            {
                SqlParameter[] parma = {
                                        new SqlParameter("@Type","GET_PLANT"),
                                   };
                DT = DU.GetDataUsingProcedure("[PRC_UserMaster]", parma);
            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  BindPlant ShowDetails() [PRC_UserMaster]:" + "", ex.Message);
                throw ex;
            }
            //finally
            //{
            //    CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtInfo, "Denso" + "  ::  BindPlant ShowDetails() [PRC_UserMaster]:" + "", "");
            //}
            return DT;
        }

        public DataTable BindDepartment()
        {
            try
            {
                SqlParameter[] parma = {
                                        new SqlParameter("@Type","GET_DEPARTMENT"),
                                   };
                DT = DU.GetDataUsingProcedure("[PRC_UserMaster]", parma);
            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  BindDepartment ShowDetails() [PRC_UserMaster]:" + "", ex.Message);
                throw ex;
            }
            
            return DT;
        }
        public DataTable ValidateUser(PL_UserMaster obj)
        {
            try
            {
                SqlParameter[] parma = {
                                     new SqlParameter("@Type","VALIDATEUSER_PC"),
                                     new SqlParameter("@UserCode",obj.UserCode),
                                     new SqlParameter("@Password",obj.Password),
                                     //new SqlParameter("@WarehouseID",obj.WarehouseID),
                                     };

                DT = DU.GetDataUsingProcedure("[PRC_UserMaster]", parma);
            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  ValidateUser [PRC_UserMaster]:" + obj.CreatedBy, ex.Message);
                throw ex;
            }
           
            return DT;
        }


        public DataTable GetMailSetting(PL_UserMaster obj)
        {
            try
            {
                SqlParameter[] parma = {
                                     new SqlParameter("@Type",obj.DbType),
                                     new SqlParameter("@UserCode",obj.UserCode),
                                     };

                DT = DU.GetDataUsingProcedure("[PRC_UserMaster]", parma);
            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  ValidateUser [PRC_UserMaster]:" + obj.CreatedBy, ex.Message);
                throw ex;
            }
            
            return DT;
        }
        public DataTable UpdatePassword(PL_UserMaster obj)
        {
            OperationResult oPeration = OperationResult.UpdateError;
            try
            {
                SqlParameter[] parma = {
                                        new SqlParameter("@Type","UPDATEPASSWORD"),
                                        new SqlParameter("@UserID",obj.UserID),
                                        new SqlParameter("@NewPassword",obj.NewPswd),
                                        new SqlParameter("@Password",obj.Password),
                                   };
                DT = DU.GetDataUsingProcedure("[PRC_UserMaster]", parma);
            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_UserMaster UpdatePassword() [USP_M_User]:" + obj.CreatedBy, ex.Message);
                throw ex;
            }
          
            return DT;
        }
    }
}
