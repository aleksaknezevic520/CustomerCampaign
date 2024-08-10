using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Responses
{
    [DataContract]
    public class SyncCustomersRs : ResponseBase
    {
        public SyncCustomersRs(string errorMessage) : base(errorMessage)
        {
        }
    }
}
