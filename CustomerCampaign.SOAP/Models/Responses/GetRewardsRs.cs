using CustomerCampaign.Infrastructure.Models.Common;

namespace CustomerCampaign.SOAP.Models.Responses
{
    public class GetRewardsRs : ResponseBase
    {
        public GetRewardsRs(string errorMessage) : base(errorMessage)
        {
        }

        public List<Reward> Rewards { get; set; }
    }
}
