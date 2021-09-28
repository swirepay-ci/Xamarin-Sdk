using Android.App;
using Android.OS;
using swirepaysdk.Model;
using swirepaysdk.Model.Payments;
using swirepaysdk.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace swirepaysdk.Droid.Views
{
    [Activity(Label = "PaymentLinkActivity")]
    public class PaymentLinkActivity : BaseActivity<Redirect>
    {
        SwirepaySdk swirepaysdk;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

           swirepaysdk = SwirepaySdk.getInstance(Constants.apiKey);

            getPaymentLink();
        }

        private async Task getPaymentLink()
        {
            CustomerModel customer = new CustomerModel("testaccountowner-stag+395@swirepay.com", "Adam Baker", "+1254789895", "NONE", "exempt", null);

            var paymentMethods = new List<string>();
            paymentMethods.Add("CARD");

            PaymentRequest paymentRequest = new PaymentRequest("200", "USD", "", "Email", "2021-09-24T12:00:00", paymentMethods, customer);

            var result = await swirepaysdk.fetchPaymentLink(paymentRequest);
            PaymentLink paymentLink = (PaymentLink)Convert.ChangeType(result.entity, typeof(PaymentLink));

            BaseActivity<Redirect>.param_id = "sp-payment-link";

            loadUrl(paymentLink.link);
        }
    }

    public class Redirect : AbstractRedirect
    {
        public async Task callAsync(OnLinkSelectedHandler handler, string id)
        {
            string result = await SwirepaySdk.getInstance(Constants.apiKey).checkStatus(id);

            handler(result);
        }

        public override void OnRedirect(OnLinkSelectedHandler handler, string id)
        {
            callAsync(handler,id);
        }
    }
}