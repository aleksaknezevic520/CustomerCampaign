using CustomerCampaign.SOAP.Interfaces;
using CustomerCampaign.SOAP.Models.Requests;
using CustomerCampaign.SOAP.Models.Responses;

namespace CustomerCampaign.SOAP.Services
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
