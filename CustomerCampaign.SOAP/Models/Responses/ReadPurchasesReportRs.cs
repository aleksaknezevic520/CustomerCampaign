using CustomerCampaign.Infrastructure.Models.Common;
using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Responses
{
    [DataContract]
    public class ReadPurchasesReportRs : ResponseBase
    {
        public ReadPurchasesReportRs(string errorMessage) : base(errorMessage)
        {
        }

        [DataMember]
        public List<PurchaseItem> PurchaseItems { get; set; }
    }
}
