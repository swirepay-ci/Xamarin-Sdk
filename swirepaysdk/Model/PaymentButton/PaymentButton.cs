using swirepaysdk.Model.Payments;
using System;
using System.Collections.Generic;
using System.Text;

namespace swirepaysdk.Model.PaymentButton
{
    public class PaymentButton
    {
        public string link{get;set;}
        public string gid{get;set;}
        public string createdAt{get;set;}
        public string updatedAt{get;set;}
        public int amount{get;set;}
        public string redirectUri{get;set;}
        public string description{get;set;}
        public string statementDescriptor{get;set;}
        public string expiresAt{get;set;}
        public string status{get;set;}
        public string nextActionUrl{get;set;}
        public Currency currency{ get; set; }
        public Support support { get; set; }
        public bool deleted { get; set; }
    }

    public class Support
    {
        public string gid { get; set; }
        public string createdAt {get;set;}
        public string updatedAt {get;set;}
        public string email {get;set;}
        public string phone {get;set;}
        public string website {get;set;}
        public bool deleted {get;set;}
    }
}
