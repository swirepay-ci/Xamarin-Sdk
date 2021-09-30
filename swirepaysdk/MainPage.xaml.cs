using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace swirepaysdk
{
    public partial class MainPage : ContentPage,INotifyPropertyChanged
    {
        public static string _result;
        public static string Result
        {
            get { return _result; }
            set { _result = value; }
        }

        public MainPage()
        {
            InitializeComponent();
        }

        void OnPaymentLink(object sender, EventArgs e)
        {
            var paymentPage = new PaymentPage();
            paymentPage.ResultSet +=this.OnResult;
           Navigation.PushAsync(paymentPage);
            
        }

        public void OnResult(object source, EventArgs e)
        {
            Log.Warning("Result",Result);
        }
    }
}