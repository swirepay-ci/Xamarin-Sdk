
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Acr.UserDialogs;
using Android.Content;
using swirepaysdk.Droid.Views;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using swirepaysdk.Service;

namespace swirepaysdk.Droid
{
    [Activity(Label = "swirepaysdk", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : FormsAppCompatActivity
    {
        TextView resultText, responseText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            UserDialogs.Init(this);

            SwirepaySdk.initSdk(Constants.apiKey,Constants.stagingUrl);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            resultText = FindViewById<TextView>(Resource.Id.tvResult);
            responseText = FindViewById<TextView>(Resource.Id.tvResponse);
            AndroidX.AppCompat.Widget.Toolbar toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
            Button btnPayment = FindViewById<Button>(Resource.Id.btnPayment);
            Button btnCreateAccount = FindViewById<Button>(Resource.Id.btnAccount);
            Button btnPaymentMethod = FindViewById<Button>(Resource.Id.btnPaymentMethod);
            Button btnInvoice = FindViewById<Button>(Resource.Id.btnInvoice);
            Button btnSubscriptionButton = FindViewById<Button>(Resource.Id.btnSubscriptionButton);
            Button btnPaymentButton = FindViewById<Button>(Resource.Id.btnPaymentButton);

            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Android SDK";

            btnPayment.Click += (sender, e) =>
            {
                StartActivityForResult(new Intent(this, typeof(PaymentLinkActivity)), 99);
            };

            btnCreateAccount.Click += (sender, e) =>
            {

                StartActivityForResult(new Intent(this, typeof(CreateAccountActivity)), 99);
            };

            btnPaymentMethod.Click += (sender, e) =>
            {

                StartActivityForResult(new Intent(this, typeof(PaymentMethodActivity)), 99);
            };

            btnInvoice.Click += (sender, e) =>
            {

                StartActivityForResult(new Intent(this, typeof(InvoicePaymentActivity)), 99);
            };

            btnSubscriptionButton.Click += (sender, e) =>
            {
                StartActivityForResult(new Intent(this, typeof(SubscriptionButtonActivity)), 99);
            };

            btnPaymentButton.Click += (sender, e) =>
            {
                StartActivityForResult(new Intent(this, typeof(PaymentButtonActivity)), 99);
            };
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
                responseText.Text = data.GetStringExtra("Result");
            }else
            {
                responseText.Text = data.GetStringExtra("Result");
            }
        }
    }
}