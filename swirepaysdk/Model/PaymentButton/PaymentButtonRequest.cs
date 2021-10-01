using System;
using System.Collections.Generic;
using System.Text;

namespace swirepaysdk.Model.PaymentButton
{
   public class PaymentButtonRequest
    {
        public PaymentButtonRequest()
        {

        }

        public PaymentButtonRequest(int amount,string currencyCode,string description,string notificationType,List<string> paymentMethods)
        {
            this.amount = amount;
            this.currencyCode = currencyCode;
            this.description = description;
            this.notificationType = notificationType;
            this.paymentMethodType = paymentMethods;
        }

        public int amount { get; set; } 
        public string currencyCode { get; set; }
        public string description { get; set; }
        public string notificationType { get; set; }
        public List<string> paymentMethodType { get; set; }
    }
}
