using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIService.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string NameArb { get; set; }
        public string NameEng { get; set; }
        public string PhoneNum { get; set; }
        public string Address { get; set; }
        public string RegitrationNum { get; set; }
        public Nullable<int> DefaultCurrencyID { get; set; }
        public Nullable<int> AddedUserID { get; set; }
        public System.DateTime AddedDate { get; set; }
        public Nullable<int> LastUpdatedUserID { get; set; }
        public System.DateTime LastUpdatedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public virtual  List<Store> Stores { get; set; } 
    }
}