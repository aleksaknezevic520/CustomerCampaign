using CustomerCampaign.Data.Interfaces;
using CustomerCampaign.Infrastructure;
using CustomerCampaign.Repositories.Models;
using CustomerCampaign.SOAP.Helpers;
using CustomerCampaign.SOAP.Interfaces;
using CustomerCampaign.SOAP.Models.Requests;
using CustomerCampaign.SOAP.Models.Responses;

namespace CustomerCampaign.SOAP.Services
{
    public class RewardService : IRewardService
    {
        private readonly IRewardRepository _rewardRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAgentRepository _agentRepository;

        public RewardService(IRewardRepository rewardRepository, ICustomerRepository customerRepository, 
            IAgentRepository agentRepository)
        {
            _rewardRepository = rewardRepository;
            _customerRepository = customerRepository;
            _agentRepository = agentRepository;
        }

        public async Task<GetRewardRs> GetRewardByIdAsync(int agentId, int customerId)
        {
            try
            {
                var reward = await _rewardRepository.GetRewardByIdAsync(agentId, customerId);

                var response = new GetRewardRs(null);
                if(reward is not null)
                    response.Reward = ObjectMapper.MapReward(reward);

                return response;
            }
            catch (Exception)
            {
                return new GetRewardRs("Unkown error occurred while getting customer rewards");
            }
        }

        public async Task<GetRewardsRs> GetRewards()
        {
            try
            {
                var rewards = await _rewardRepository.GetRewardsAsync();

                var response = new GetRewardsRs(null);
                response.Rewards = ObjectMapper.MapRewards(rewards);

                return response;
            }
            catch (Exception)
            {
                return new GetRewardsRs("Unkown error occurred while getting customer rewards");
            }
        }

        public async Task<GetRewardsRs> GetRewardsForAgent(int agentId)
        {
            try
            {
                var rewards = await _rewardRepository.GetRewardsForAgentAsync(agentId);                

                var response = new GetRewardsRs(null);
                response.Rewards = ObjectMapper.MapRewards(rewards);

                return response;
            }
            catch (Exception)
            {
                return new GetRewardsRs("Unkown error occurred while getting customer rewards for agent");
            }
        }

        public async Task<GetRewardsRs> GetRewardsForCustomer(int customerId)
        {
            try
            {
                var rewards = await _rewardRepository.GetRewardsForCustomerAsync(customerId);

                var response = new GetRewardsRs(null);
                response.Rewards = ObjectMapper.MapRewards(rewards);

                return response;
            }
            catch (Exception)
            {
                return new GetRewardsRs("Unkown error occurred while getting customer rewards for agent");
            }
        }

        public async Task<AddRewardRs> AddReward(AddRewardRq rq)
        {
            if (rq == null)
                return new AddRewardRs("Request object is null");

            var currentDate = DateTime.Now;
            var agentRewardsOnDay = await _rewardRepository.GetAgentRewardsOnDayAsync(rq.AgentId, currentDate);

            var agent = _agentRepository.GetAgentById(rq.AgentId);
            if(agent is null)
                return new AddRewardRs("Agent not found");

            if (agentRewardsOnDay?.Count >= Constants.Max_Rewards_Per_Day)
                return new AddRewardRs("Daily rewards limit is reached");

            var customer = _customerRepository.GetCustomerById(rq.CustomerId);
            if (customer is not { IsLoyal: true })
                return new AddRewardRs("Loyalty customer not found");

            var reward = await _rewardRepository.GetRewardByIdAsync(rq.AgentId, rq.CustomerId);
            if (reward is not null)
                return new AddRewardRs("Reward already exists for the customer");

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

                return new AddRewardRs(null);
            }
            catch (Exception)
            {
                return new AddRewardRs("Unknown error occurred while saving reward");
            }
        }

        public async Task<UpdateRewardRs> UpdateReward(UpdateRewardRq rq)
        {
            var reward = await _rewardRepository.GetRewardByIdAsync(rq.AgentId, rq.CustomerId);
            if (reward is null)
                return new UpdateRewardRs("Reward not found");

            try
            {
                reward.AgentId = rq.AgentId;
                reward.CustomerId = rq.CustomerId;
                reward.DiscountPercent = rq.DiscountPercent;

                await _rewardRepository.CommitAsync();

                return new UpdateRewardRs(null);
            }
            catch (Exception)
            {
                return new UpdateRewardRs("Unknown error occurred while saving reward");
            }
        }

        public async Task<DeleteRewardRs> DeleteReward(DeleteRewardRq rq)
        {
            var reward = await _rewardRepository.GetRewardByIdAsync(rq.AgentId, rq.CustomerId);
            if (reward is null)
                return new DeleteRewardRs("Reward not found");

            try
            {
                _rewardRepository.DeleteReward(reward);
                await _rewardRepository.CommitAsync();

                return new DeleteRewardRs(null);
            }
            catch (Exception)
            {
                return new DeleteRewardRs("Unknown error occurred while deleting reward");
            }
        }
    }
}
