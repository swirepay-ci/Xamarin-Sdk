using Android.App;
using Android.OS;
using Android.Util;
using swirepaysdk.Service;
using System.Text;
using System.Threading.Tasks;

namespace swirepaysdk.Droid.Views
{
    [Activity(Label = "PaymentMethodActivity")]
    public class PaymentMethodActivity : BaseActivity<PaymentMethodRedirect>
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

            BaseActivity<Redirect>.param_id = "sp-session-id";

            loadUrl(Constants.paymentUrl+ "setup-session?key=" + Base64.EncodeToString(Encoding.ASCII.GetBytes(Constants.apiKey),Base64Flags.Default));
        }
    }

    public class PaymentMethodRedirect : AbstractRedirect
    {
        public async Task callAsync(OnLinkSelectedHandler handler, string id)
        {
            string result = await SwirepaySdk.getInstance(Constants.apiKey).fetchSetupSession(id);

            handler(result);
        }

        public override void OnRedirect(OnLinkSelectedHandler handler, string id)
        {
            callAsync(handler, id);
        }
    }
}