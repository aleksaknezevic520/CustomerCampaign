using CustomerCampaign.Data.Interfaces;
using CustomerCampaign.Repositories.Models;

namespace CustomerCampaign.Data.Repositories
{
    public class AgentRepository : RepositoryBase, IAgentRepository
    {
        public AgentRepository(CustomerCampaignDbContext dataContext) : base(dataContext)
        {
        }

        public void CreateAgent(Agent agent)
        {
            DataContext.Agents.Add(agent);
        }
    }
}
