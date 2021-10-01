using swirepaysdk.Model.Payments;
using System;
using System.Collections.Generic;
using System.Text;

namespace swirepaysdk.Model.Plan
{
    class Plan
    {
        public string gid { get; set; }
        public Currency currency { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
        public string description { get; set; }
        public string billingFrequency { get; set; }
        public int billingPeriod { get; set; }
        public string currencyCode { get; set; }
        public string startDate { get; set; }
        public string couponGid { get; set; }
        public List<string> taxRates { get; set; }
        public string totalPayments{get;set;}
        public int quantity { get; set; }

    }
}
