using AgentService;
using CustomerCampaign.SOAPConsumer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerCampaign.SOAPConsumer.Factories
{
    public class AgentFactory
    {
        private readonly AgentServiceClient _agentService;

        public AgentFactory()
        {
            _agentService = new AgentServiceClient(AgentServiceClient.EndpointConfiguration.BasicHttpBinding_IAgentService);
        }

        public async Task<JsonResult> CreateAgent(CreateAgent request)
        {
            if(request == null)
                return new JsonResult(new { Success = false, ErrorMessage = "Request is null" });

            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password) 
                || string.IsNullOrEmpty(request.Name))
                return new JsonResult(new { Success = false, ErrorMessage = "All fields are required" });

            var response = await _agentService.CreateAgentAsync(new CreateAgentRq
            {
                Email = request.Email,
                Password = request.Password,
                Name = request.Name
            });

            return new JsonResult(response);
        }
    }
}
