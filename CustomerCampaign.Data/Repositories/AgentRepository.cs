using CustomerCampaign.Data.Interfaces;
using CustomerCampaign.Repositories.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Agent> GetAgentByEmailAsync(string email)
        {
            return await DataContext.Agents.SingleOrDefaultAsync(x => x.Email == email);
        }

        public void CreateAgent(Agent agent)
        {
            DataContext.Agents.Add(agent);
        }
    }
}
