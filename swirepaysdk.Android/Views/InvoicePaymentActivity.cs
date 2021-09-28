using Android.App;
using Android.OS;
using swirepaysdk.Service;
using System.Threading.Tasks;

namespace swirepaysdk.Droid.Views
{
    [Activity(Label = "InvoicePaymentActivity")]
    public class InvoicePaymentActivity : BaseActivity<InvoiceRedirect>
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

            BaseActivity<Redirect>.param_id = "sp-invoice-link";

            loadUrl(Constants.paymentUrl+ "invoice-link/" + "invoicelink-02f9c3ade85746a28007d6fe44efdc3a");
        }
    }

    public class InvoiceRedirect : AbstractRedirect
    {
        public async Task callAsync(OnLinkSelectedHandler handler, string id)
        {
            string result = await SwirepaySdk.getInstance(Constants.apiKey).checkInvoiceStatus(id);

            handler(result);
        }

        public override void OnRedirect(OnLinkSelectedHandler handler, string id)
        {
            callAsync(handler, id);
        }
    }
}