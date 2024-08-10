using CustomerCampaign.Data.Interfaces;
using CustomerCampaign.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace CustomerCampaign.Data.Repositories
{
    public class RewardRepository : RepositoryBase, IRewardRepository
    {
        public RewardRepository(CustomerCampaignDbContext dataContext) : base(dataContext)
        {
        }

        public async Task<Reward> GetRewardByIdAsync(int agentId, int customerId)
        {
            return await DataContext.Rewards.FindAsync(agentId, customerId);                ;
        }

        public async Task<List<Reward>> GetRewardsAsync()
        {
            return await DataContext.Rewards.ToListAsync();
        }

        public async Task<List<Reward>> GetRewardsForCustomerAsync(int customerId)
        {
            return await DataContext.Rewards
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<List<Reward>> GetRewardsForAgentAsync(int agentId)
        {
            return await DataContext.Rewards
                .Where(x => x.AgentId == agentId)
                .ToListAsync();
        }

        public async Task<List<Reward>> GetAgentRewardsOnDayAsync(int agentId, DateTime currentDate)
        {
            return await DataContext.Rewards
                .Where(x => x.AgentId == agentId && x.CreatedDate.Date == currentDate.Date)
                .ToListAsync();
        }

        public void CreateReward(Reward reward)
        {
            DataContext.Rewards.Add(reward);
        }

        public void DeleteReward(Reward reward)
        {
            DataContext.Rewards.Remove(reward);
        }
    }
}
