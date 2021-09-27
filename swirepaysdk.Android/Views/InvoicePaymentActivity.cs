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
    [Activity(Label = "InvoicePaymentActivity")]
    public class InvoicePaymentActivity : BaseActivity
    {
        SwirepaySdk swirepaysdk;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            swirepaysdk = SwirepaySdk.getInstance(Constants.apiKey);

            createInvoicePayment();
        }

        private async Task createInvoicePayment()
        {

            BaseActivity.BaseConstructor(this, "sp-invoice-link");

            loadUrl(Constants.paymentUrl+ "invoice-link/" + "invoicelink-02f9c3ade85746a28007d6fe44efdc3a");
        }
    }
}