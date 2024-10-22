using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace COMMON 
{
    /*========================================================================================
   Procedure/Module :  Common Enum
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
    public enum ValidateResult 
    {
        VALID,
        INVALID,
        EMPTY
    }
    /// <summary>
    /// 
    /// </summary>
    public enum OperationResult
    {
        SaveSuccess,
        SaveError,
        UpdateSuccess,
        UpdateError,
        DeleteSuccess,
        DeleteError,
        Error,
        Duplicate,
        PartialDelete,
        FullDelete,
        DeleteRefference,
        ForeignKeyError,
        PrimaryKeyError,
        NotFound,
        Valid,
        Invalid,
        PrinterError,
        InsertError,
        InActiveUsers,
        ActiveUsers,
    }
    /// <summary>
    /// 
    /// </summary>
    public enum ValidateType
    {
        IsNumeric,
        IsNumericOrDecimal,
        IsDateTime,
        IsDecimal,
        IsString
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MsgType
    {
        Success,
        Error,
        Info,
        Confirm
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MsgResult
    {
        DUPLICATE,
        YES,
        NO,
        OK,
        CANCEL,
        INVALID
    }
}
