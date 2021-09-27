using System;
using System.Collections.Generic;
using System.Text;

namespace swirepaysdk.Model.Invoice
{
    class InvoiceLineItemDtos
    {
       
        public string amount { get; set; }
        public string name{get;}
        public string description{get;}
        public string quantity{get;}
        public string note{get;}
        public string rate{get;}
        public CurrencyType currencyCode{get;}
    }
}
