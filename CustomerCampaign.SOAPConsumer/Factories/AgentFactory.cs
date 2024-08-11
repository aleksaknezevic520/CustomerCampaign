using AgentService;
using CustomerCampaign.SOAPConsumer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerCampaign.SOAPConsumer.Factories
{
    public class AgentFactory
    {
        private readonly AgentServiceClient _agentService;

        public AgentFactory(AgentServiceClient agentService)
        {
            _agentService = agentService;
        }

        public async Task<JsonResult> CreateAgent(CreateAgentRq request)
        {
            var response = await _agentService.CreateAgentAsync(request);
            return new JsonResult(response);
        }
    }
}
