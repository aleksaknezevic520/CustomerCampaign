using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Requests
{
    [DataContract]
    public class GetRewardByIdRq : RequestBase
    {
        [DataMember]
        public int AgentId { get; set; }

        [DataMember]
        public int CustomerId { get; set; }
    }
}
