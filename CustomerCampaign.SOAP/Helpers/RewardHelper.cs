using CustomerCampaign.Repositories.Models;
using Microsoft.Extensions.Logging;
using RewardCommon = CustomerCampaign.Infrastructure.Models.Common.Reward;

namespace CustomerCampaign.SOAP.Helpers
{
    public static class RewardHelper
    {
        internal static List<RewardCommon> MapRewards(List<Reward> rewards)
        {
            return rewards.Select(x => new RewardCommon
            {
                AgentId = x.AgentId,
                AgentName = x.Agent.Name,
                CustomerId = x.CustomerId,
                CustomerName = x.Customer.Name,
                CustomerSsn = x.Customer.SSN,
                DiscountPercent = x.DiscountPercent,
                CreatedDate = x.CreatedDate
            }).ToList();
        }

        internal static RewardCommon MapReward(Reward reward)
        {
            return new RewardCommon
            {
                AgentId = reward.AgentId,
                AgentName = reward.Agent.Name,
                CustomerId = reward.CustomerId,
                CustomerName = reward.Customer.Name,
                CustomerSsn = reward.Customer.SSN,
                DiscountPercent = reward.DiscountPercent,
                CreatedDate = reward.CreatedDate
            };
        }
    }
}
