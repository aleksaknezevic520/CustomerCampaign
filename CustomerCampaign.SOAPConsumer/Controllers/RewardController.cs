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

        [HttpPost]
        [Route(nameof(Get))]
        public async Task<JsonResult> Get([FromBody] GetRewardByIdRq rq) => await _rewardFactory.GetRewardById(rq);

        [HttpPost]
        [Route(nameof(GetAll))]
        public async Task<JsonResult> GetAll([FromBody] GetRewardsRq rq) => await _rewardFactory.GetRewards(rq);

        [HttpPost]
        [Route(nameof(GetRewardsForAgent))]
        public async Task<JsonResult> GetRewardsForAgent([FromBody] GetRewardsForAgentRq rq) => 
            await _rewardFactory.GetRewardsForAgent(rq);

        [HttpPost]
        [Route(nameof(GetRewardForCustomer))]
        public async Task<JsonResult> GetRewardForCustomer([FromBody] GetRewardForCustomerRq rq) => 
            await _rewardFactory.GetRewardForCustomer(rq);

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
        public async Task<JsonResult> Delete([FromBody] DeleteRewardRq rq) => await _rewardFactory.DeleteReward(rq);
    }
}
