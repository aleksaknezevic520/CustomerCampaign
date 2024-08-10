using CustomerCampaign.Infrastructure.Models.Common;

namespace CustomerCampaign.SOAP.Models.Responses
{
    public class ReadPurchasesReportRs : ResponseBase
    {
        public ReadPurchasesReportRs(string errorMessage) : base(errorMessage)
        {
        }

        public List<PurchaseItem> PurchaseItems { get; set; }
    }
}
