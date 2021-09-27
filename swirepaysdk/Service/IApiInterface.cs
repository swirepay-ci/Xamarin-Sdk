using swirepaysdk.Model;
using swirepaysdk.Model.Payments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace swirepaysdk.Service
{
    public interface IApiInterface
    {
        Task<string> checkStatus(string paymentLinkGid);
        Task<SuccessResponse<PaymentLink>> fetchPaymentLink(PaymentRequest paymentRequest);
        Task<string> fetchSetupSession(string setupId);
        Task<string> checkInvoiceStatus(string invoiceGid);
    }
}
