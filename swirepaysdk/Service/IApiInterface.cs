using Refit;
using swirepaysdk.Model;
using swirepaysdk.Model.Payments;
using System.Threading.Tasks;

namespace swirepaysdk.Service
{
    [Headers("Content-Type:application/json")]
    public interface IApiInterface
    {
        [Post("/v1/payment-link")]
        Task<SuccessResponse<PaymentLink>> fetchPaymentLink([Body] PaymentRequest paymentRequest, [Header("x-api-key")] string apikey);
    }
}
