using CustomerCampaign.SOAPConsumer.Factories;
using CustomerCampaign.SOAPConsumer.Models;
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
        [Route(nameof(Create))]
        public async Task<JsonResult> Create(CreateAgent request) => await _agentFactory.CreateAgent(request);
    }
}
