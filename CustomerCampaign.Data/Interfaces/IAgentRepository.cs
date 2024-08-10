using CustomerCampaign.Repositories.Models;

namespace CustomerCampaign.Data.Interfaces
{
    public interface IAgentRepository : IRepositoryBase
    {
        void CreateAgent(Agent agent);
        Agent GetAgentById(int id);
    }
}
