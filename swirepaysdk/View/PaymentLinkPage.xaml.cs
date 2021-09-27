using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace swirepaysdk.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentLinkPage : ContentPage
    {
        public PaymentLinkPage()
        {
            InitializeComponent();

        }

        void webviewNavigated(object sender, WebNavigatedEventArgs e)
        {
            Log.Warning("Data",e.Url);
        }
    }
}