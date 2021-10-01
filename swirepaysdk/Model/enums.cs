using System;
using System.Collections.Generic;
using System.Text;

namespace swirepaysdk.Model
{
    public enum NotificationType
    {
        Email, SMS, ALL
    }

   public enum PaymentMethodType
    {
        CARD, ACH
    }

    public enum CurrencyType
    {
        INR, USD
    }
}
