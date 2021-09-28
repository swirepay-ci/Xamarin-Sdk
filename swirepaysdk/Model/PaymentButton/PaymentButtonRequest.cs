using System;
using System.Collections.Generic;
using System.Text;

namespace swirepaysdk.Model.PaymentButton
{
   public class PaymentButtonRequest
    {
        public int amount { get; set; } 
        public string currencyCode { get; set; }
        public string description { get; set; }
        public string notificationType { get; set; }
        public List<string> paymentMethodType { get; set; }
    }
}
