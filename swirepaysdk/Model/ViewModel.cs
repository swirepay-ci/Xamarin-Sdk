using swirepaysdk.Model.Payments;
using swirepaysdk.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace swirepaysdk.Model
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        IApiInterface ips = DependencyService.Get<IApiInterface>();

        private PaymentLink paymentLink;

        public PaymentLink PaymentLink
        {

            get
            {
                return paymentLink;
            }

            set
            {
                paymentLink = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PaymentLink"));
            }
        }

        public ViewModel()
        {

            getPaymentLink();
        }

        private async void getPaymentLink()
        {
            CustomerModel customer = new CustomerModel("testaccountowner-stag+395@swirepay.com", "Adam Baker", "+1254789895", "NONE", "exempt", null);

            var paymentMethods = new List<string>();
            paymentMethods.Add("CARD");

            PaymentRequest paymentRequest = new PaymentRequest("200", "USD", "", "Email", "2021-09-24T12:00:00", paymentMethods, customer);

            var result = await ips.fetchPaymentLink(paymentRequest);
            PaymentLink = (PaymentLink)Convert.ChangeType(result.entity, typeof(PaymentLink));
        }
    }
}
