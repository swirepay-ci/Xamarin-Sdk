using System;
using System.Collections.Generic;
using System.Text;

namespace swirepaysdk.Model.SubscriptionButton
{
    public class SubscriptionButton
    { 
    public string name { get; set; }
    public int planAmount{get;}
    public string description{get;}
    public string currencyCode{get;}
    public string planBillingFrequency{get;}
    public int planBillingPeriod{get;}
    public string planStartDate{get;}
    public List<string> taxRates{get;}
    public string couponId{get;}
    public int planQuantity{get;}
    public int planTotalPayments{get;}
    public string status{get;}
    public string link { get; set; }
    }
}
