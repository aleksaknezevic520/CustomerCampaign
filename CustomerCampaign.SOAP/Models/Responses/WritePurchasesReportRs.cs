using CustomerCampaign.Infrastructure.Models.Common;
using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Responses
{
    [DataContract]
    public class WritePurchasesReportRs : ResponseBase
    {
        public WritePurchasesReportRs(string errorMessage) : base(errorMessage)
        {
        }
    }
}
