using System;
using System.Collections.Generic;
using System.Text;

namespace swirepaysdk.Model.Plan
{
    public class PlanRequest
    {
        
    public PlanRequest()
        {

        }

        public PlanRequest(string name,int amount,string description, string currencyCode,string billingFrequency,int billingPeriod,
            int planQuantity, string planTotalPayments,string planStartDate)
        {
            this.name = name;
            this.amount = amount;
            this.description = description;
            this.currencyCode = currencyCode;
            this.billingFrequency = billingFrequency;
            this.billingPeriod = billingPeriod;
            this.quantity = planQuantity;
            this.startDate = planStartDate;
            this.totalPayments = planTotalPayments;
        }
    public string name { get; set; }
    public int amount{ get; set; }
    public string description{ get; set; }
    public string currencyCode{ get; set; }
    public string billingFrequency{ get; set; }
    public int billingPeriod{ get; set; }
        public int quantity { get; set; }
        public string startDate { get; set; }
        public string totalPayments { get; set; }
    }
}
