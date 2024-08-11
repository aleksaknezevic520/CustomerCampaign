using CustomerCampaign.SOAPConsumer.Factories;
using Microsoft.AspNetCore.Mvc;
using RewardService;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerCampaign.SOAPConsumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardController : ControllerBase
    {
        private readonly RewardFactory _rewardFactory;

        public RewardController(RewardFactory rewardFactory)
        {
            _rewardFactory = rewardFactory;
        }

        [HttpGet]
        [Route(nameof(Get))]
        public async Task<JsonResult> Get(int agentId, int customerId) => 
            await _rewardFactory.GetRewardById(agentId, customerId);

        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<JsonResult> GetAll() => await _rewardFactory.GetRewards();

        [HttpGet]
        [Route(nameof(GetRewardsForAgent))]
        public async Task<JsonResult> GetRewardsForAgent(int agentId) => 
            await _rewardFactory.GetRewardsForAgent(agentId);

        [HttpGet]
        [Route(nameof(GetRewardsForCustomer))]
        public async Task<JsonResult> GetRewardsForCustomer(int customerId) => 
            await _rewardFactory.GetRewardForCustomer(customerId);

        [HttpPost]
        [Route(nameof(Add))]
        public async Task<JsonResult> Add([FromBody] AddRewardRq request) => 
            await _rewardFactory.AddReward(request);

        [HttpPut]
        [Route(nameof(Update))]
        public async Task<JsonResult> Update([FromBody] UpdateRewardRq request) => 
            await _rewardFactory.UpdateReward(request);

        [HttpDelete]
        [Route(nameof(Delete))]
        public async Task<JsonResult> Delete(int agentId, int customerId) => 
            await _rewardFactory.DeleteReward(agentId, customerId);
    }
}
