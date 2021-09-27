using Newtonsoft.Json;
using swirepaysdk.Model;
using swirepaysdk.Model.Payments;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace swirepaysdk.Service
{
    public class SwirepaySdk : IApiInterface
    {
        private static string apiKey { get; set; }
        private static SwirepaySdk swirepaySdk;
        
        public static SwirepaySdk getInstance(string apiKey)
        {
            initSdk(apiKey);

            if (swirepaySdk == null)
                swirepaySdk = new SwirepaySdk();

            return swirepaySdk;
        }

        public static void initSdk(string key)
        {
            apiKey = key;
           
        }


        public PaymentLink PaymentLink { get; private set; }

        public async Task<string> checkStatus(string paymentLinkGid) 
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);

            HttpResponseMessage response = await client.GetAsync(Constants.stagingUrl + "v1/payment-link/"+paymentLinkGid);

            if (response != null)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                //SuccessResponse<PaymentLink> result = JsonConvert.DeserializeObject<SuccessResponse<PaymentLink>>(jsonString);
                return jsonString;
            }
            return null;
        }

        public async Task<SuccessResponse<PaymentLink>> fetchPaymentLink(PaymentRequest paymentRequest)
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);

            var json = JsonConvert.SerializeObject(paymentRequest);
            //string data = @"{""amount"":100,""notificationType"":""Email"",""redirectUri"":"""",""description"":""Test"",""currencyCode"":""USD"",""paymentMethodType"":[""CARD""],""customer"":{""email"":""testaccountowner-stag+111@swirepay.com"",""name"":""UserMe"",""phoneNumber"":""+14104994322"",""taxId"":""NONE"",""taxStatus"":""exempt""}}";
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await client.PostAsync(Constants.stagingUrl + "v1/payment-link", content);

                if (response != null)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    SuccessResponse<PaymentLink> result = JsonConvert.DeserializeObject<SuccessResponse<PaymentLink>>(jsonString);
                    return result;
                }
            }catch(Exception e)
            {
                Log.Warning("Msg",e.Message);
            }
            return null;
        }

        public async Task<string> fetchSetupSession(string setupId)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);

            HttpResponseMessage response = await client.GetAsync(Constants.stagingUrl + "v1/setup-session/" + setupId);

            if (response != null)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                return jsonString;
            }
            return null;
        }

        public async Task<string> checkInvoiceStatus(string invoiceGid)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);

            HttpResponseMessage response = await client.GetAsync(Constants.stagingUrl + "v1/invoice-link/" + invoiceGid);

            if (response != null)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                return jsonString;
            }
            return null;
        }
    }
}
