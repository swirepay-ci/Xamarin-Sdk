using Newtonsoft.Json;
using swirepaysdk.Model;
using swirepaysdk.Model.PaymentButton;
using swirepaysdk.Model.Payments;
using swirepaysdk.Model.Plan;
using swirepaysdk.Model.SubscriptionButton;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace swirepaysdk.Service
{
    public class SwirepaySdk
    {
        private static string apiKey;
        private static string apiUrl;
        private static SwirepaySdk swirepaySdk;

        public static SwirepaySdk getInstance()
        {
            if (swirepaySdk == null)
                swirepaySdk = new SwirepaySdk();

            return swirepaySdk;
        }

        public static void initSdk(string key,string url)
        {
            apiKey = key;
            apiUrl = url;
        }

        public async Task<SuccessResponse<PaymentLink>> fetchPaymentLink(PaymentRequest paymentRequest) 
        {
            if ( String.IsNullOrEmpty(apiKey))
                throw new KeyNotInitializedException();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);

            var json = JsonConvert.SerializeObject(paymentRequest);
            //string data = @"{""amount"":100,""notificationType"":""Email"",""redirectUri"":"""",""description"":""Test"",""currencyCode"":""USD"",""paymentMethodType"":[""CARD""],""customer"":{""email"":""testaccountowner-stag+111@swirepay.com"",""name"":""UserMe"",""phoneNumber"":""+14104994322"",""taxId"":""NONE"",""taxStatus"":""exempt""}}";
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await client.PostAsync(apiUrl + "v1/payment-link", content);

                if (response != null)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    SuccessResponse<PaymentLink> result = JsonConvert.DeserializeObject<SuccessResponse<PaymentLink>>(jsonString);
                    return result;
                }
            }
            catch (Exception e)
            {
                Log.Warning("Msg", e.Message);
            }
            return null;
        }

        public async Task<string> checkStatus(string paymentLinkGid)
        {
            if (String.IsNullOrEmpty(apiKey))
                throw new KeyNotInitializedException();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);

            HttpResponseMessage response = await client.GetAsync(apiUrl + "v1/payment-link/" + paymentLinkGid);

            if (response != null)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                //SuccessResponse<PaymentLink> result = JsonConvert.DeserializeObject<SuccessResponse<PaymentLink>>(jsonString);
                return jsonString;
            }
            return null;
        }

        public async Task<string> fetchSetupSession(string setupId)
        {
            if (String.IsNullOrEmpty(apiKey))
                throw new KeyNotInitializedException();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);

            HttpResponseMessage response = await client.GetAsync(apiUrl + "v1/setup-session/" + setupId);

            if (response != null)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                return jsonString;
            }
            return null;
        }

        public async Task<string> checkInvoiceStatus(string invoiceGid)
        {
            if (String.IsNullOrEmpty(apiKey))
                throw new KeyNotInitializedException();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);

            HttpResponseMessage response = await client.GetAsync(apiUrl + "v1/invoice-link/" + invoiceGid);

            if (response != null)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                return jsonString;
            }
            return null;
        }

        public async Task<SuccessResponse<SubscriptionButton>> createPlan(PlanRequest planRequest)
        {
            if (String.IsNullOrEmpty(apiKey))
                throw new KeyNotInitializedException();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);

            var json = JsonConvert.SerializeObject(planRequest);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await client.PostAsync(apiUrl + "v1/plan", content);

                if (response != null)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    SuccessResponse<Plan> successResponse = JsonConvert.DeserializeObject<SuccessResponse<Plan>>(jsonString);
                    Plan plan = (Plan)Convert.ChangeType(successResponse.entity, typeof(Plan));

                    if (successResponse.responseCode == 200)
                    {
                        SubscriptionButtonRequest subscriptionButtonRequest = new SubscriptionButtonRequest();
                        //subscriptionButtonRequest.couponGid = "coupon-95eaecf56e514b3d98e59397f81d7645";
                        subscriptionButtonRequest.currencyCode = "USD";
                        subscriptionButtonRequest.description = "Test description";
                        subscriptionButtonRequest.name = "USD";
                        subscriptionButtonRequest.planAmount = plan.amount;
                        subscriptionButtonRequest.planBillingFrequency = "MONTH";
                        subscriptionButtonRequest.planBillingPeriod = 1;
                        subscriptionButtonRequest.planGid = plan.gid;
                        subscriptionButtonRequest.planQuantity = 1;
                        subscriptionButtonRequest.planStartDate = "2021-09-28T12:00:00";
                        subscriptionButtonRequest.planTotalPayments = "2";

                        //var taxRates = new List<string>();
                        //taxRates.Add("taxrates-8b65b57692cf4a9c94607f0c1d364c39");
                        //subscriptionButtonRequest.taxRates = taxRates;

                        return await createSubscriptionButton(subscriptionButtonRequest);
                    }
                }
            }
            catch (Exception e)
            {
                Log.Warning("Msg", e.Message);
            }
            return null;
        }

        public async Task<SuccessResponse<SubscriptionButton>> createSubscriptionButton(SubscriptionButtonRequest subscriptionButtonRequest)
        {
            if (String.IsNullOrEmpty(apiKey))
                throw new KeyNotInitializedException();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);

            var json = JsonConvert.SerializeObject(subscriptionButtonRequest);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await client.PostAsync(apiUrl + "v1/subscription-button", content);

                if (response != null)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    SuccessResponse<SubscriptionButton> result = JsonConvert.DeserializeObject<SuccessResponse<SubscriptionButton>>(jsonString);

                    return result;
                }
            }
            catch (Exception e)
            {
                Log.Warning("Msg", e.Message);
            }

            return null;
        }
   
        public async Task<string> getSubscriptionButton(string buttonGid)
        {
            if (String.IsNullOrEmpty(apiKey))
                throw new KeyNotInitializedException();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);

            HttpResponseMessage response = await client.GetAsync(apiUrl + "v1/subscription-button/" + buttonGid);

            if (response != null)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                return jsonString;
            }
            return null;
        }

        public async Task<SuccessResponse<PaymentButton>> createPaymentButton(PaymentButtonRequest paymentButtonRequest)
        {
            if (String.IsNullOrEmpty(apiKey))
                throw new KeyNotInitializedException();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);

            var json = JsonConvert.SerializeObject(paymentButtonRequest);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await client.PostAsync(apiUrl + "v1/payment-button", content);

                if (response != null)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    SuccessResponse<PaymentButton> result = JsonConvert.DeserializeObject<SuccessResponse<PaymentButton>>(jsonString);

                    return result;
                }
            }
            catch (Exception e)
            {
                Log.Warning("Msg", e.Message);
            }

            return null;
        }

        
        public async Task<string> getPaymentButton(string buttonGid)
        {
            if ( String.IsNullOrEmpty(apiKey))
                throw new KeyNotInitializedException();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);

            HttpResponseMessage response = await client.GetAsync(apiUrl + "v1/payment-button/" + buttonGid);

            if (response != null)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                return jsonString;
            }
            return null;
        }

        //public async Task<SuccessResponse<PaymentLink>> fetchPaymentLink(PaymentRequest paymentRequest, string apikey)
        //{
        //    try
        //    {
        //        var apiCall = RestService.For<IApiInterface>(Constants.stagingUrl);
        //        SuccessResponse<PaymentLink> successResponse = await apiCall.fetchPaymentLink(paymentRequest, apikey);
        //        return successResponse;

        //    }
        //    catch (Exception e)
        //    {
        //        Log.Warning("Msg", e.Message);
        //    }
        //    return null;
        //}
    }
}
