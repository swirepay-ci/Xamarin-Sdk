using Xamarin.Forms;
using swirepaysdk.View;

namespace swirepaysdk.Model
{
    class MainViewModel
    {
        public Command gotoPaymentLink { get; set; }

        public MainViewModel()
        {
            gotoPaymentLink = new Command(gotoPaymentLinkPage);
        }

        private void gotoPaymentLinkPage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new PaymentLinkPage());
        }
    }
}
