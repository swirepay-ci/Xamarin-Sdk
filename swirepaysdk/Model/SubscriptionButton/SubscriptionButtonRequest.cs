using System;
using System.Collections.Generic;
using System.Text;

namespace swirepaysdk.Model.SubscriptionButton
{
    public class SubscriptionButtonRequest
    {
        public string currencyCode { get; set; }
        public string description{ get; set; }
        public int planAmount{get;set;}
        public string planBillingFrequency{get;set;}
        public int planBillingPeriod{get;set;}
        public string planGid{get;set;}
        public int planQuantity{get;set;}
        public string planStartDate{get;set;}
        public string planTotalPayments{get;set;}
        public string redirectUri = Constants.baseUrl;
        public string couponGid{get;set;}
        public List<string> taxRates{get;set;}
        public string name{get;set;}
    }
}
