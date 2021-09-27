using System;
using System.Collections.Generic;
using System.Text;

namespace swirepaysdk.Model.Payments
{
    public class PaymentLink
    {
        public string gid { get; set; }
        public int amount { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string name { get; set; }
        public List<String> paymentMethodType { get; set; }
        public bool deleted { get; set; }
        public Currency currency { get; set; }
        public string link { get; set; }
    }

    public class Currency
    {
        public int id { get; set; }
        public string name { get; set; }
        public string countryAlpha2 { get; set; }
        public string toFixed { get; set; }
        public string prefix { get; set; }
    }
}
