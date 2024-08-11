using AuthenticationService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerCampaign.SOAPConsumer.Factories
{
    public class AuthenticationFactory
    {
        private readonly AuthenticationServiceClient _authServiceClient;

        public AuthenticationFactory(AuthenticationServiceClient authServiceClient)
        {
            _authServiceClient = authServiceClient;
        }

        public async Task<JsonResult> Authenticate(AuthenticateRq rq)
        {
            var response = await _authServiceClient.AuthenticateAsync(rq);
            return new JsonResult(response);
        }
    }
}
