using AuthenticationService;
using CustomerCampaign.SOAPConsumer.Factories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerCampaign.SOAPConsumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationFactory _authFactory;

        public AuthenticationController(AuthenticationFactory authFactory)
        {
            _authFactory = authFactory;
        }

        [HttpPost]
        [Route(nameof(Authenticate))]
        public async Task<JsonResult> Authenticate([FromBody] AuthenticateRq rq) => await _authFactory.Authenticate(rq);
    }
}
