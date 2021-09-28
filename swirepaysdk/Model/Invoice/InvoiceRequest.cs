using System;
using System.Collections.Generic;
using System.Text;

namespace swirepaysdk.Model.Invoice
{
    class InvoiceRequest
    {
       
    public string currencyCode { get; set; }
    public string customerGid{get;}
    public string couponGid{get;}
    public string daysUntilDue{get;}
    public string paymentDueDate{get;}
    public string issueDate{get;}
    public int amount{get;}
    public string status{get;}
    public string description{get;}
    public List<string> taxRates{get;}
    public string customerNote{get;}
    public string billingAddress{get;}
    public string shippingAddress{get;}
    public string subscriptionGid{get;}
    public string invoiceNumber{get;}
    public List<string> invoiceLineItems{get;}
    public List<string> invoiceLineItemDtos{get;}
    }
}
