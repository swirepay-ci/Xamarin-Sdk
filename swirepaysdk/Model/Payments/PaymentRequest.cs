using System.Collections.Generic;

namespace swirepaysdk.Model.Payments
{
    public class PaymentRequest
    {

    public string amount { get; set; }
    public string currencyCode { get; set; }
    public List<string> paymentMethodType { get; set; }
    public CustomerModel customer { get; set; }
    public string customerGid { get; set; }
    public string notificationType { get; set; }
    public string dueDate { get; set; }

    public PaymentRequest(string amount,string currencyCode,string customerGid,string notificationType,string dueDate,List<string> paymentMethods,
        CustomerModel customer)
        {
            this.amount = amount;
            this.currencyCode = currencyCode;
            this.customer = customer;
            this.customerGid = customerGid;
            this.notificationType = notificationType;
            this.dueDate = dueDate;
            this.paymentMethodType = paymentMethods;
        }
    }
}
