using System;
using System.Collections.Generic;
using System.Text;

namespace swirepaysdk.Model
{
    public class CustomerModel
    {
       public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string taxId { get; set; }
        public string taxStatus { get; set; }
        public string taxValue { get; set; }

        public CustomerModel(string email,string name,string phoneNumber,string taxId,string taxStatus,string taxValue)
        {
            this.email = email;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.taxId = taxId;
            this.taxStatus = taxStatus;
            this.taxValue = taxValue;
        }
    }
}
