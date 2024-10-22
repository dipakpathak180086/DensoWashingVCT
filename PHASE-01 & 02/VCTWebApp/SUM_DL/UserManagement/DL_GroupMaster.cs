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
  public  class DL_GroupMaster
    {
        DataTable DT = new DataTable();
        Datautility DU = new Datautility();
        public DataTable ShowDetails(PL_GroupMaster obj)
        {
            try
            {
                SqlParameter[] parma = {    
                                        new SqlParameter("@Type","SELECT"),
                                   };
                DT = DU.GetDataUsingProcedure("[PRC_GroupMaster]", parma);
            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_GroupMaster ShowDetails() [PRC_GroupMaster]:" + obj.CreatedBy, ex.Message);
                throw ex;
            }
            
            return DT;
        }

        public DataTable ShowDetailsByID(PL_GroupMaster obj)
        {
            try
            {
                SqlParameter[] parma = {    
                                        new SqlParameter("@Type","SELECTBYID"),
                                        new SqlParameter("@GroupID",obj.GroupID),
                                      
                                   };
                DT = DU.GetDataUsingProcedure("[PRC_GroupMaster]", parma);
            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_GroupMaster ShowDetails() [PRC_GroupMaster]:" + obj.CreatedBy, ex.Message);
                throw ex;
            }
            
            return DT;
        }

        public DataTable GetGroups(PL_GroupMaster obj)
        {
            try
            {
                SqlParameter[] parma = {    
                                        new SqlParameter("@Type","GETGROUP"),
                                   };
                DT = DU.GetDataUsingProcedure("[PRC_GroupMaster]", parma);
            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_GroupMaster ShowDetails() [PRC_GroupMaster]:" + obj.CreatedBy, ex.Message);
                throw ex;
            }
           
            return DT;
        }

        public DataTable GetGroupRights(PL_GroupMaster obj)
        {
            try
            {
                SqlParameter[] parma = {    
                                        new SqlParameter("@Type","GET_USER_RIGHTS"),
                                        new SqlParameter("@GroupName",obj.GroupID),
                                   };
                DT = DU.GetDataUsingProcedure("[PRC_GroupMaster]", parma);
            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_GroupMaster ShowDetails() [PRC_GroupMaster]:" + obj.CreatedBy, ex.Message);
                throw ex;
            }
           
            return DT;
        }

        public OperationResult Save(PL_GroupMaster obj)
        {
            OperationResult oPeration = OperationResult.SaveError;
            try
            {
                if (!this.CheckDuplicate(obj))
                {
                    SqlParameter[] parma = {
                                        new SqlParameter("@Type","INSERT"),
                                        new SqlParameter("@GroupName",obj.GroupName),
                                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                                        new SqlParameter("@PlantCode",obj.PlantCode),
                                   };
                    int Result = DU.ExecuteProcedure("[PRC_GroupMaster]", parma);
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
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_GroupMaster Save() [PRC_GroupMaster]:" + obj.CreatedBy, ex.Message);
                throw ex;
            }
           
            return oPeration;
        }

        public bool CheckDuplicate(PL_GroupMaster obj)
        {
            bool isDuplicate = false;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] parma = {
                                        new SqlParameter("@Type","CHECKDUP"),
                                        new SqlParameter("GroupName",obj.GroupName),
                                   };
                DT = DU.GetDataUsingProcedure("[PRC_GroupMaster]", parma);

                if (DT.Rows.Count > 0)
                {
                    isDuplicate = true;
                }

                else
                {
                    isDuplicate = false;
                }


            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_UserMaster CheckDuplicate() [PRC_PlantMaster]:" + obj.CreatedBy, ex.Message);
                throw ex;
            }
            
            return isDuplicate;
        }
        public OperationResult Update(PL_GroupMaster obj)
        {
            OperationResult oPeration = OperationResult.UpdateError;
            try
            {
                SqlParameter[] parma = {    
                                        new SqlParameter("@Type","UPDATE"),
                                        new SqlParameter("@GroupName",obj.GroupName),
                                        new SqlParameter("@GroupID",obj.GroupID),
                                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                                        new SqlParameter("@PlantCode",obj.PlantCode),
                                   };
                int Result = DU.ExecuteProcedure("[PRC_GroupMaster]", parma);
                if (Result > 0)
                {
                    oPeration = OperationResult.UpdateSuccess;
                }

            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_GroupMaster Save() [PRC_GroupMaster]:" + obj.CreatedBy, ex.Message);
                throw ex;
            }
           
            return oPeration;
        }

        public DataTable CheckTransation(PL_GroupMaster obj)
        {
            try
            {
                SqlParameter[] parma = {
                                        new SqlParameter("@Type","CHECKTRANSACTION"),
                                        new SqlParameter("@GroupName",obj.GroupName),
                                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                                        new SqlParameter("@GroupID",obj.GroupID),
                                        new SqlParameter("@PlantCode",obj.PlantCode),
                                   };
                DT = DU.GetDataUsingProcedure("[PRC_GroupMaster]", parma);
            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_GroupMaster CheckTransation() [PRC_GroupMaster]:" + obj.CreatedBy, ex.Message);
                throw ex;
            }
          
            return DT;
        }

        public OperationResult Delete(PL_GroupMaster obj)
        {
            OperationResult oPeration = OperationResult.DeleteError;
            try
            {
                SqlParameter[] parma = {    
                                        new SqlParameter("@Type","DELETE"),
                                        new SqlParameter("@GroupName",obj.GroupName),
                                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                                        new SqlParameter("@GroupID",obj.GroupID),
                                        new SqlParameter("@PlantCode",obj.PlantCode),
                                   };
                int Result = DU.ExecuteProcedure("[PRC_GroupMaster]", parma);
                if (Result > 0)
                {
                    oPeration = OperationResult.DeleteSuccess;
                }
            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_GroupMaster Save() [PRC_GroupMaster]:" + obj.CreatedBy, ex.Message);
                throw ex;
            }
            
            return oPeration;
        }

        public OperationResult SaveUpdateGroupRights(DataTable dt, PL_GroupMaster obj)
        {
            int Result = 0;
            OperationResult oPeration = OperationResult.UpdateSuccess;
            try
            {
                for (int iCnt = 0; iCnt < dt.Rows.Count; iCnt++)
                {
                    SqlParameter[] parma = {
                                        new SqlParameter("@Type","INSERT_GROUP_RIGHT"),
                                        new SqlParameter("@GroupID",obj.GroupID),
                                        new SqlParameter("@ModuleID",int.Parse(dt.Rows[iCnt]["MODULE_ID"].ToString())),
                                        new SqlParameter("@ViewRights",dt.Rows[iCnt]["VIEW_RIGHTS"].ToString()),
                                  };
                    Result = DU.ExecuteProcedure("[PRC_GroupMaster]", parma);
                }
                if (Result == -1)
                    oPeration = OperationResult.UpdateSuccess;
            }
            catch (Exception ex)
            {
                CommonHelper.mSatoLogger.LogMessage(SatoLib.EventNotice.EventTypes.evtError, "Denso" + "  ::  DL_GroupMaster Save() [PRC_GroupMaster]:" + obj.CreatedBy, ex.Message);
                throw ex;
            }
            
            return oPeration;
        }
    }
}
