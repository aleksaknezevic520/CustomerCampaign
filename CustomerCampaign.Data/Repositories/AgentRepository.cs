using CustomerCampaign.Data.Interfaces;
using CustomerCampaign.Repositories.Models;

namespace CustomerCampaign.Data.Repositories
{
    public class AgentRepository : RepositoryBase, IAgentRepository
    {
        public AgentRepository(CustomerCampaignDbContext dataContext) : base(dataContext)
        {
        }

        public Agent GetAgentById(int id)
        {
            return DataContext.Agents.Find(id);
        }

        public void CreateAgent(Agent agent)
        {
            DataContext.Agents.Add(agent);
        }
    }
}
