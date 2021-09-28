using Android.App;
using Android.OS;
using swirepaysdk.Model.PaymentButton;
using swirepaysdk.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace swirepaysdk.Droid.Views
{
    [Activity(Label = "PaymentButtonActivity")]
    public class PaymentButtonActivity : BaseActivity<PaymentRedirect>
    {
        private SwirepaySdk swirepaysdk;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            swirepaysdk = SwirepaySdk.getInstance(Constants.apiKey);

            createPaymentButton();
        }

        public async Task createPaymentButton()
        {
            PaymentButtonRequest request = new PaymentButtonRequest();
            request.amount = 200;
            request.notificationType = "Email";
            request.currencyCode = "USD";
            request.description = "Test description";

            var paymentMethods = new List<string>();
            paymentMethods.Add("CARD");
            request.paymentMethodType = paymentMethods;

            var result = await swirepaysdk.createPaymentButton(request);
            PaymentButton paymentButton = (PaymentButton)Convert.ChangeType(result.entity, typeof(PaymentButton));

            BaseActivity<Redirect>.param_id = "sp-payment-button";

            loadUrl(paymentButton.link);
        }
    }

    public class PaymentRedirect : AbstractRedirect
    {
        public async Task callAsync(OnLinkSelectedHandler handler, string id)
        {
            string result = await SwirepaySdk.getInstance(Constants.apiKey).getPaymentButton(id);

            handler(result);
        }

        public override void OnRedirect(OnLinkSelectedHandler handler, string id)
        {
            callAsync(handler, id);
        }
    }
}