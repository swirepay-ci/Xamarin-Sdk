using swirepaysdk.Service;
using Xamarin.Forms;

namespace swirepaysdk
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<SwirepaySdk>();
            //MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}