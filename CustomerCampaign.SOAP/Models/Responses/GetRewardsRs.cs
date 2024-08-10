using CustomerCampaign.Infrastructure.Models.Common;
using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Responses
{
    [DataContract]
    public class GetRewardsRs : ResponseBase
    {
        public GetRewardsRs(string errorMessage) : base(errorMessage)
        {
        }

        [DataMember]
        public List<Reward> Rewards { get; set; }
    }
}
