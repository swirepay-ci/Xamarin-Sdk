using Android.App;
using Android.Content;
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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            createPaymentMethod();
        }

        private async Task createPaymentMethod()
        {

            BaseActivity<Redirect>.param_id = "sp-session-id";

            if (!string.IsNullOrEmpty(Constants.apiKey))
            {
                loadUrl(Constants.paymentUrl + "setup-session?key=" + Base64.EncodeToString(Encoding.ASCII.GetBytes(Constants.apiKey), Base64Flags.Default));
            }
            else
            {
                SetResult(Result.Canceled, new Intent()
                 .PutExtra("Result", "Key not initialized!"));

               Finish();
            }
        }
    }

    public class PaymentMethodRedirect : AbstractRedirect
    {
        public async Task callAsync(OnLinkSelectedHandler handler, string id)
        {
            string result = await SwirepaySdk.getInstance().fetchSetupSession(id);

            handler(result);
        }

        public override void OnRedirect(OnLinkSelectedHandler handler, string id)
        {
            callAsync(handler, id);
        }
    }
}