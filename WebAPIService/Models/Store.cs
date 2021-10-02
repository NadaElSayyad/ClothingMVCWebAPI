using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIService.Models
{
    public class Store
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string NameArb { get; set; }
        public string NameEng { get; set; }
        public string PhoneNum { get; set; }
        public string Address { get; set; }
        public Nullable<bool> MainStore { get; set; }
        public int CompanyID { get; set; }
        public Nullable<int> AddedUserID { get; set; }
        public System.DateTime AddedDate { get; set; }
        public Nullable<int> LastUpdatedUserID { get; set; }
        public System.DateTime LastUpdatedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }


        public virtual Company Company { get; set; }  
    }
}