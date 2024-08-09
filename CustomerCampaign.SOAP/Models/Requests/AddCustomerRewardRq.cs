using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Requests
{
    [DataContract]
    public class AddCustomerRewardRq
    {
        [DataMember]
        public int AgentId { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int DiscountPercent { get; set; }
    }
}
