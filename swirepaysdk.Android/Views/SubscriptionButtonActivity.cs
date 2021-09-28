using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using swirepaysdk.Model.Payments;
using swirepaysdk.Model.Plan;
using swirepaysdk.Model.SubscriptionButton;
using swirepaysdk.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swirepaysdk.Droid.Views
{
    [Activity(Label = "SubscriptionButtonActivity")]
    public class SubscriptionButtonActivity : BaseActivity<SubscriptionRedirect>
    {
        private SwirepaySdk swirepaysdk;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            swirepaysdk = SwirepaySdk.getInstance(Constants.apiKey);

            createSubscriptionButton();
        }

        public async Task createSubscriptionButton()
        {
            PlanRequest planRequest = new PlanRequest();
            planRequest.amount = 200;
            planRequest.billingFrequency = "Month";
            planRequest.billingPeriod = 1;
            planRequest.currencyCode = "USD";
            planRequest.description = "Test description";
            planRequest.name = "Test";

            var result = await swirepaysdk.createPlan(planRequest);
            SubscriptionButton subscription = (SubscriptionButton)Convert.ChangeType(result.entity, typeof(SubscriptionButton));

            BaseActivity<Redirect>.param_id = "sp-subscription-button";

            loadUrl(subscription.link);
        }
    }

    public class SubscriptionRedirect : AbstractRedirect
    {
        public async Task callAsync(OnLinkSelectedHandler handler, string id)
        {
            string result = await SwirepaySdk.getInstance(Constants.apiKey).getSubscriptionButton(id);

            handler(result);
        }

        public override void OnRedirect(OnLinkSelectedHandler handler, string id)
        {
            callAsync(handler, id);
        }
    }
}