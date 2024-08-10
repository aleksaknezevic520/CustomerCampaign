using CustomerCampaign.SOAPConsumer.Factories;
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
        [Route(nameof(SyncCustomers))]
        public async Task<JsonResult> SyncCustomers() => await _customerFactory.SyncCustomers();
        
    }
}
