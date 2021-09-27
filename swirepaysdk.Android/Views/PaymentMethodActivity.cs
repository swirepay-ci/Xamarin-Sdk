using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using swirepaysdk.Droid.Utility;
using swirepaysdk.Model;
using swirepaysdk.Model.Payments;
using swirepaysdk.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace swirepaysdk.Droid.Views
{
    [Activity(Label = "PaymentMethodActivity")]
    public class PaymentMethodActivity : BaseActivity
    {
        SwirepaySdk swirepaysdk;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            swirepaysdk = SwirepaySdk.getInstance(Constants.apiKey);

            createPaymentMethod();
        }

        private async Task createPaymentMethod()
        {

            BaseActivity.BaseConstructor(this, "sp-session-id");

            loadUrl(Constants.paymentUrl+ "setup-session?key=" + Base64.EncodeToString(Encoding.ASCII.GetBytes(Constants.apiKey),Base64Flags.Default));
        }
    }
}