using swirepaysdk.Model.Payments;
using System;
using System.Collections.Generic;
using System.Text;

namespace swirepaysdk.Model.Plan
{
    class Plan
    {
    public string gid { get; set; }
    public Currency currency{ get; set; }
    public string name{ get; set; }
    public int amount{ get; set; }
    public string description{ get; set; }
    public string billingFrequency{ get; set; }
    public int billingPeriod{ get; set; }
    }
}
