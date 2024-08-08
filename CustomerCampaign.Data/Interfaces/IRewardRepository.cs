using CustomerCampaign.Repositories.Models;

namespace CustomerCampaign.Data.Interfaces
{
    public interface IRewardRepository : IRepositoryBase
    {
        List<Reward> GetRewards();
        Reward GetRewardById(int id);
        void CreateReward(Reward reward);
        void DeleteReward(Reward reward);
    }
}
