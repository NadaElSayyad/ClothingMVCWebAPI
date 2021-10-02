using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class CompanyModel
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

        public virtual List<StoreModel> Stores { get; set; }
    }

}