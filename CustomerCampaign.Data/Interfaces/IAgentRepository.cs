using CustomerCampaign.Repositories.Models;

namespace CustomerCampaign.Data.Interfaces
{
    public interface IAgentRepository : IRepositoryBase
    {
        Agent GetAgentById(int id);
        Task<Agent> GetAgentByEmailAsync(string email);
        void CreateAgent(Agent agent);
    }
}
