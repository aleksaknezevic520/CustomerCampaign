using CustomerCampaign.SOAPConsumer.Factories;
using CustomerService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerCampaign.SOAPConsumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerFactory _customerFactory;

        public CustomerController(CustomerFactory customerFactory)
        {
            _customerFactory = customerFactory;
        }

        [HttpPost]
        [Route(nameof(Sync))]
        public async Task<JsonResult> Sync() => await _customerFactory.SyncCustomers();

        [HttpPost]
        [Route(nameof(UpdateLoyaltyStatus))]
        public async Task<JsonResult> UpdateLoyaltyStatus([FromBody] UpdateCustomerLoyaltyStatusRq request) => 
            await _customerFactory.UpdateLoyaltyStatus(request);
        
    }
}
