using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SUM_PL
{
    public class PL_UserMaster
    {
        public string UserName
        { get; set; }
        public string UserID
        { get; set; }
        public string UserCode
        { get; set; }
        public string PlantCode
        { get; set; }
        public string PlantName
        { get; set; }
        public string DepartmentCode
        { get; set; }
        public string DepartmentName
        { get; set; }
        public string Password
        { get; set; }
        public string UserType
        { get; set; }
        public int CreatedBy
        { get; set; }
        public int ModifiedBy
        { get; set; }
        public string NewPswd
        { get; set; }
        public string GroupName
        { get; set; }
        public string EmailID
        { get; set; }
        public string PinNo
        { get; set; }
        public string DbType
        { get; set; }
    }
}
