using Microsoft.AspNetCore.Mvc;
using RewardService;
using System;
using System.Threading.Tasks;

namespace CustomerCampaign.SOAPConsumer.Factories
{
    public class RewardFactory
    {
        private readonly RewardServiceClient _rewardClient;

        public RewardFactory()
        {
            _rewardClient = new RewardServiceClient(RewardServiceClient.EndpointConfiguration.BasicHttpBinding_IRewardService);
        }

        internal async Task<JsonResult> GetRewardById(int agentId, int customerId)
        {
            var response = await _rewardClient.GetRewardByIdAsync(agentId, customerId);
            return new JsonResult(response);
        }

        internal async Task<JsonResult> GetRewards()
        {
            var response = await _rewardClient.GetRewardsAsync();
            return new JsonResult(response);
        }

        internal async Task<JsonResult> GetRewardsForCustomer(int customerId)
        {
            var response = await _rewardClient.GetRewardsForCustomerAsync(customerId);
            return new JsonResult(response);
        }

        internal async Task<JsonResult> GetRewardsForAgent(int agentId)
        {
            var response = await _rewardClient.GetRewardsForAgentAsync(agentId);
            return new JsonResult(response);
        }

        internal async Task<JsonResult> AddReward(AddRewardRq request)
        {
            var response = await _rewardClient.AddRewardAsync(request);
            return new JsonResult(response);
        }

        internal async Task<JsonResult> UpdateReward(UpdateRewardRq request)
        {
            var response = await _rewardClient.UpdateRewardAsync(request);
            return new JsonResult(response);
        }

        internal async Task<JsonResult> DeleteReward(int agentId, int customerId)
        {
            var response = await _rewardClient.DeleteRewardAsync(new DeleteRewardRq
            {
                AgentId = agentId,
                CustomerId = customerId
            });
            return new JsonResult(response);
        }
    }
}
