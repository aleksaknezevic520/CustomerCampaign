using CustomerCampaign.Data.Interfaces;
using CustomerCampaign.Repositories.Models;

namespace CustomerCampaign.Data.Repositories
{
    public class RewardRepository : RepositoryBase, IRewardRepository
    {
        public RewardRepository(CustomerCampaignDbContext dataContext) : base(dataContext)
        {
        }

        public List<Reward> GetRewards()
        {
            return DataContext.Rewards.ToList();
        }

        public Reward GetRewardById(int id)
        {
            return DataContext.Rewards.Find(id);
        }

        public List<Reward> GetAgentRewardsOnDay(int agentId, DateTime currentDate)
        {
            return DataContext.Rewards
                .Where(x => x.AgentId == agentId && x.CreatedDate.Date == currentDate.Date)
                .ToList();
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
