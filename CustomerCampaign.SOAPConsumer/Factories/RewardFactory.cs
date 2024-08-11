using Microsoft.AspNetCore.Mvc;
using RewardService;
using System;
using System.Threading.Tasks;

namespace CustomerCampaign.SOAPConsumer.Factories
{
    public class RewardFactory
    {
        private readonly RewardServiceClient _rewardClient;

        public RewardFactory(RewardServiceClient rewardClient)
        {
            _rewardClient = rewardClient;
        }

        internal async Task<JsonResult> GetRewardById(GetRewardByIdRq rq)
        {
            var response = await _rewardClient.GetRewardByIdAsync(rq);
            return new JsonResult(response);
        }

        internal async Task<JsonResult> GetRewards(GetRewardsRq rq)
        {
            var response = await _rewardClient.GetRewardsAsync(rq);
            return new JsonResult(response);
        }

        internal async Task<JsonResult> GetRewardForCustomer(GetRewardForCustomerRq rq)
        {
            var response = await _rewardClient.GetRewardForCustomerAsync(rq);
            return new JsonResult(response);
        }

        internal async Task<JsonResult> GetRewardsForAgent(GetRewardsForAgentRq rq)
        {
            var response = await _rewardClient.GetRewardsForAgentAsync(rq);
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

        internal async Task<JsonResult> DeleteReward(DeleteRewardRq rq)
        {
            var response = await _rewardClient.DeleteRewardAsync(rq);
            return new JsonResult(response);
        }
    }
}
