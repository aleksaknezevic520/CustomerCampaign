using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Requests
{
    [DataContract]
    public class GetRewardsForAgentRq : RequestBase
    {
        [DataMember]
        public int AgentId { get; set; }
    }
}
