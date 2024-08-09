using CustomerCampaign.Data.Interfaces;
using CustomerCampaign.Infrastructure.Settings;
using CustomerCampaign.Repositories.Models;
using CustomerCampaign.SOAP.Interfaces;
using CustomerCampaign.SOAP.Models.Requests;
using CustomerCampaign.SOAP.Models.Responses;

namespace CustomerCampaign.SOAP.Services
{
    public class RewardService : IRewardService
    {
        private readonly IRewardRepository _rewardRepository;
        private readonly ICustomerRepository _customerRepository;

        public RewardService(IRewardRepository rewardRepository, ICustomerRepository customerRepository)
        {
            _rewardRepository = rewardRepository;
            _customerRepository = customerRepository;
        }

        public async Task<AddCustomerRewardRs> AddCustomerReward(AddCustomerRewardRq rq)
        {
            if (rq == null)
                return new AddCustomerRewardRs
                {
                    Success = false,
                    ErrorMessage = "Request object is null"
                };

            var currentDate = DateTime.Now;
            var agentRewardsOnDay = _rewardRepository.GetAgentRewardsOnDay(rq.AgentId, currentDate);

            if (agentRewardsOnDay?.Count >= AgentRewardLimitSettings.Max_Rewards_Per_Day)
                return new AddCustomerRewardRs
                {
                    Success = false,
                    ErrorMessage = "Daily rewards limit is reached"
                };

            var customer = _customerRepository.GetCustomerById(rq.CustomerId);
            if(customer is not { IsLoyal: true })
                return new AddCustomerRewardRs
                {
                    Success = false,
                    ErrorMessage = "Customer is not part of the loyalty program"
                };

            try
            {
                _rewardRepository.CreateReward(new Reward
                {
                    AgentId = rq.AgentId,
                    CreatedDate = currentDate,
                    CustomerId = rq.CustomerId,
                    DiscountPercent = rq.DiscountPercent
                });
                await _rewardRepository.CommitAsync();

                return new AddCustomerRewardRs { Success = true };
            }
            catch (Exception)
            {
                return new AddCustomerRewardRs
                {
                    Success = false,
                    ErrorMessage = "Method not implemented"
                };
            }
        }
    }
}
