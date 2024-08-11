using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Requests
{
    [DataContract]
    public class GetRewardForCustomerRq : RequestBase
    {
        [DataMember]
        public int CustomerId { get; set; }
    }
}
