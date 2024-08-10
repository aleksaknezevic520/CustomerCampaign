using CustomerCampaign.Infrastructure.Models.Common;
using System.Runtime.Serialization;

namespace CustomerCampaign.SOAP.Models.Responses
{
    [DataContract]
    public class GetRewardRs : ResponseBase
    {
        public GetRewardRs(string errorMessage) : base(errorMessage)
        {
        }

        [DataMember]
        public Reward Reward { get; set; }
    }
}
