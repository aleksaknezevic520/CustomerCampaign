using CustomerCampaign.Infrastructure.Models.Common;

namespace CustomerCampaign.SOAP.Models.Responses
{
    public class GetRewardRs : ResponseBase
    {
        public GetRewardRs(string errorMessage) : base(errorMessage)
        {
        }

        public Reward Reward { get; set; }
    }
}
