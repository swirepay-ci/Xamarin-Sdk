using System;
using System.Collections.Generic;
using System.Text;

namespace swirepaysdk.Model.Plan
{
    public class PlanRequest
    {
        
    public string name { get; set; }
    public int amount{ get; set; }
    public string description{ get; set; }
    public string currencyCode{ get; set; }
    public string billingFrequency{ get; set; }
    public int billingPeriod{ get; set; }
    }
}
