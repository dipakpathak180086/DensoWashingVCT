using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SUM_PL
{
   public class PL_GroupMaster
    {
       public string GroupID
       {
           get;
           set;
       }
        public string PlantCode
        {
            get;
            set;
        }
        public string GroupName
       {
           get;
           set;
       }
       public string GroupDesc
       {
           get;
           set;
       }
       public string CreatedBy
       {
           get;
           set;
       }
       public string ModifiedBy
       {
           get;
           set;
       }
        public int WarehouseID
        {
            get;
            set;
        }
    }
}
