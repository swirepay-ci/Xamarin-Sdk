using Newtonsoft.Json;
using swirepaysdk.Model.Payments;
using System;
using System.Collections.Generic;

namespace swirepaysdk.Model.Invoice
{
    public class InvoiceResponse
    {

        public string gid { get; set; }
        public InvoiceAccount account { get; set; }
        public Invoice invoice { get; set; }
        public List<InvoiceLineItems> invoiceLineItems { get; set; }
    }

    public class InvoiceAccount {
        public string gid { get; set; }
        public string name { get; set; }
        public string support { get; set; }
        public string largeLogo { get; set; }
        public string timezone { get; set; }
        public Country country { get; set; }
        public Currency currency { get; set; }
        public List<string> supportedPaymentTypes { get; set; }
        public List<string> supportedRecurringPaymentTypes { get; set; }
    }


    public class Country
    { 
    public int id { get; set; }
    public string name{get; set;}
    public string alpha2{get; set;}
    public string alpha3{get; set;}
    public string unCode{get; set;}
}

public class Invoice
    { 
    public string gid { get; set; }
    public Customer customer{get; set;}
    public PaymentMethod paymentMethod{get; set;}
    public string billingAddress{get; set;}
    public string shippingAddress{get; set;}
    public List<InvoiceLineItems> invoiceLineItems{get; set;}
    public List<TaxAmount> taxAmount{get; set;}
    public int total{get; set;}
    public int discountAmount{get; set;}
    public string shippingAmount{get; set;}
    public List<String> paymentMethodType{get; set;}
    public string description{get; set;}
    public int amount{get; set;}
    public string statementDescriptor{get; set;}
    public string paymentDueDate{get; set;}
    public string paymentDate{get; set;}
    public string status{get; set;}
    public string lastProcessed{get; set;}
    public string issueDate{get; set;}
    public string customerNote{get; set;}
    public string invoiceNumber{get; set;}
    public string invoicePdfKey{get; set;}
    public Currency currency{get; set;}
    public Coupon coupon{get; set;}
}

public class TaxAmount
    { 
    public TaxRate taxRates { get; set; }
    public int tax { get; set; }
}

public  class TaxRate
    {
    public string gid { get; set; }
    public string createdAt{get; set;}
    public string updatedAt{get; set;}
    public string displayName{get; set;}
    public string description{get; set;}
    public string jurisdiction{get; set;}
    public Double percentage{get; set;}
    public bool inclusive{get; set;}
    public bool deleted{get; set;}
}

public class Customer
    { 
    public string gid { get; set; }
    public string name{get; set;}
    public string email{get; set;}
    public string phoneNumber{get; set;}
    public string billingAddress{get; set;}
    public string shippingAddress{get; set;}
    public string iavToken{get; set;}
}

    public class PaymentMethod
    { 
    public string gid { get; set; }
    public Card card { get; set; }
    public string bank { get; set; }
    [JsonProperty(PropertyName = "default")]
    public bool _default{get;set;}
    }

    public class Card
    { 
    public string name { get; set; }
    public string lastFour { get; set; }
    public string scheme{ get; set; }
    public int expiryMonth{ get; set; }
    public string expiryYear{ get; set; }
    }

    public class Coupon 
    { 
    public string gid { get; set; }
    public string createdAt{get; set;}
    public string updatedAt{get; set;}
    public string validity{get; set;}
    public int amountOff{get; set;}
    public string name{get; set;}
    public string maximumRedemption{get; set;}
    public Currency currency{get; set;}
    public string promotionalCodes{get; set;}
    public string couponRedemption{get; set;}
    public int redemptionCount{get; set;}
    public bool active{get; set;}
    public string valid{get; set;}
    public bool deleted { get; set; }
    }
}
