using CustomerCampaign.Services.Interfaces;
using CustomerCampaign.Services.Models.Requests;
using CustomerCampaign.Services.Models.Responses;

namespace CustomerCampaign.Services.Services
{
    public class RewardService : IRewardService
    {
        public AddCustomerRewardRs AddCustomerReward(AddCustomerRewardRq rq)
        {
            return new AddCustomerRewardRs
            {
                SuccessfulSaving = false,
                ErrorMessage = "Method not implemented"
            };
        }
    }
}
