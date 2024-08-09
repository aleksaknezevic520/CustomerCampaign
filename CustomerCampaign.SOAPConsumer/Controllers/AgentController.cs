using CustomerCampaign.SOAPConsumer.Factories;
using CustomerCampaign.SOAPConsumer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerCampaign.SOAPConsumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly AgentFactory _agentFactory;

        public AgentController(AgentFactory agentFactory)
        {
            _agentFactory = agentFactory;
        }

        [HttpPost]
        public async Task<JsonResult> CreateAgent(CreateAgent request) => await _agentFactory.CreateAgent(request);
    }
}
