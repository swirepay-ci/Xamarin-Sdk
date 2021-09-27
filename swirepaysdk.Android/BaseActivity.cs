using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Util;
using Android.Webkit;
using Android.Widget;
using Newtonsoft.Json;
using swirepaysdk.Droid.Utility;
using swirepaysdk.Droid.Views;
using swirepaysdk.Model.Account;
using swirepaysdk.Service;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.Android;

namespace swirepaysdk.Droid
{
    [Activity(Label = "BaseActivity")]
    public abstract class BaseActivity : FormsAppCompatActivity
    {

        public WebView webView;
        static ProgressBar progress;
        public static string param_id = "";
        public static string result_id = "";
        private static Activity activity;

        public delegate void OnLinkSelectedHandler(string result);

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_base);

            webView = FindViewById<WebView>(Resource.Id.webView);
            progress = FindViewById<ProgressBar>(Resource.Id.progress);
        }

        //public abstract void onRedirect(string url);

        public static void BaseConstructor(FormsAppCompatActivity activityInstance, string paramId)
        {
            activity = activityInstance;
            param_id = paramId;
        }

        public void loadUrl(string url)
        {

            webView.ClearCache(true);
            webView.ClearHistory();
            progress.Visibility = Android.Views.ViewStates.Visible;
            webView.Settings.JavaScriptEnabled = true;
            webView.RequestFocusFromTouch();
            webView.ScrollBarStyle = Android.Views.ScrollbarStyles.InsideOverlay;
            WebSettings webSettings = webView.Settings;
            webSettings.DomStorageEnabled = true;
            webSettings.DatabaseEnabled = true;
            webSettings.UseWideViewPort = true;
            Log.Debug("sdk_test", "loadUrl: "+url);
            webView.LoadUrl(url);
            webView.SetWebChromeClient(new WebChromeClient());
            webView.SetWebViewClient(new WebViewClientClass(dofinish));
        }

        public class WebViewClientClass : WebViewClient
        {

            private OnLinkSelectedHandler linkSelected;

            public WebViewClientClass(OnLinkSelectedHandler handler)
            {
                linkSelected = handler;
            }

            public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
            {

                var localUrl = request.Url.ToString();
                Log.Debug("sdk_test", "shouldOverrideUrlLoading: " + localUrl);
                var uri = request.Url;
                var id = uri.GetQueryParameter(param_id);

                if (id != null)
                {
                    result_id = id;
                }

                if (isThisFinalUrl(localUrl))
                {
                    onRedirect(linkSelected, result_id);
                    return true;
                }

                return base.ShouldOverrideUrlLoading(view,request);
            }

            public override void OnPageFinished(WebView view, string url)
            {
                progress.Visibility = Android.Views.ViewStates.Gone;
                Log.Debug("BaseActivity", "onPageFinished:");
            }

            public override void OnReceivedError(WebView view, IWebResourceRequest requesy, WebResourceError error)
            {

            }
        }

        public void dofinish(string result)
        {
            SetResult(Result.Ok, new Intent()
               .PutExtra("Result", result));

            // Close this activity.
            Finish();
        }

        public static async Task onRedirect(OnLinkSelectedHandler linkSelected,string id)
        {
            string result = null;
            if (activity.GetType() == typeof(PaymentLinkActivity))
            {
                result = await ApiService.getService().checkStatus(id);
            }else if(activity.GetType() == typeof(CreateAccountActivity))
            {
                result = JsonConvert.SerializeObject(new Account(id));
            }else if(activity.GetType() == typeof(PaymentMethodActivity))
            {
                result = await ApiService.getService().fetchSetupSession(id);
            }else if(activity.GetType() == typeof(InvoicePaymentActivity))
            {
                result = await ApiService.getService().checkInvoiceStatus(id);
            }

            linkSelected(result);
        }

        public static bool isThisFinalUrl(string url)
        {
            if (url != null && url.Contains(Constants.baseUrl))
            {
                return true;
            }
            return false;
        }

        long backPressedTime = 0;
        public override void OnBackPressed()
        {
            if (Java.Lang.JavaSystem.CurrentTimeMillis() - backPressedTime < 2000)
            {
                SetResult(Result.Canceled, new Intent()
                    .PutExtra("Result", "User Cancelled"));

                Finish();
            }
         else
            {
              backPressedTime = Java.Lang.JavaSystem.CurrentTimeMillis();
              Toast.MakeText(this, "Click back again to exit!", ToastLength.Short).Show();
            }
        }
    }
}