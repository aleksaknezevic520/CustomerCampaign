using CustomerCampaign.Repositories.Models;

namespace CustomerCampaign.Data.Interfaces
{
    public interface IRewardRepository : IRepositoryBase
    {
        Task<Reward> GetRewardByIdAsync(int agentId, int customerId);
        Task<List<Reward>> GetRewardsAsync();
        Task<Reward> GetRewardForCustomerAsync(int customerId);
        Task<List<Reward>> GetRewardsForAgentAsync(int agentId);
        Task<List<Reward>> GetAgentRewardsOnDayAsync(int agentId, DateTime currentDate);
        void CreateReward(Reward reward);
        void DeleteReward(Reward reward);
    }
}
