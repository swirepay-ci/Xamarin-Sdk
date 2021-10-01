using Android.App;
using Android.OS;
using Android.Util;
using Newtonsoft.Json;
using swirepaysdk.Model.Account;
using swirepaysdk.Service;
using System.Text;
using System.Threading.Tasks;

namespace swirepaysdk.Droid.Views
{
    [Activity(Label = "CreateAccountActivity")]
    public class CreateAccountActivity : BaseActivity<AccountRedirect>
    {
        SwirepaySdk swirepaysdk;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            swirepaysdk = SwirepaySdk.getInstance();

            createAccount();
        }

        private async Task createAccount()
        {

            BaseActivity<AccountRedirect>.param_id = "sp-account-id";

            string accountUrl = swirepaysdk.GetCreateAccountUrl(Constants.paymentUrl,Constants.apiKey);

            loadUrl(accountUrl);
        }
    }

    public class AccountRedirect : AbstractRedirect
    {
        public override void OnRedirect(OnLinkSelectedHandler handler, string id)
        {
            string result = JsonConvert.SerializeObject(new Account(id));

            handler(result);
        }
    }
}