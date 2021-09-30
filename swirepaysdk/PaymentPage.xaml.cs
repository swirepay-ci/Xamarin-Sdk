using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace swirepaysdk
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentPage : ContentPage
    {
        public delegate void SetResultEventHandler(object source, EventArgs args);
        public event SetResultEventHandler ResultSet;

        public PaymentPage()
        {
            InitializeComponent();
            Webview.Source = "https://staging-secure.swirepay.com/setup-session?key="+Convert.ToBase64String(Encoding.ASCII.GetBytes("sk_test_RsXBK7eRDZfI8xBD19jRuK5xd1KOUuuD"));
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
        }  
  

        protected void OnNavigating(object sender, WebNavigatingEventArgs e)
        {
            Log.Warning("Payment",e.Url);

            if (e.Url.Contains("https://www.swirepay.com"))
            {
                Uri uri = new Uri(e.Url);

                string query = HttpUtility.ParseQueryString(uri.Query).Get("sp-session-id");

                MainPage.Result = query;
                OnResult();
                Navigation.PopAsync();
            }
        }

        protected void OnNavigated(object sender, WebNavigatedEventArgs e)
        {

        }

        protected virtual void OnResult()
        {
            if (ResultSet != null)
            {
                ResultSet(this, EventArgs.Empty);
            }
        }
    }
}