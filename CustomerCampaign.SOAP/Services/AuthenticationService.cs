using CustomerCampaign.Data.Interfaces;
using CustomerCampaign.Infrastructure.Settings;
using CustomerCampaign.SOAP.Interfaces;
using CustomerCampaign.SOAP.Models.Requests;
using CustomerCampaign.SOAP.Models.Responses;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CustomerCampaign.SOAP.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAgentRepository _agentRepository;

        public AuthenticationService(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        public async Task<AuthenticateRs> Authenticate(AuthenticateRq request)
        {
            if (string.IsNullOrEmpty(request?.Email) || string.IsNullOrEmpty(request?.Password))
                return new AuthenticateRs("Email and password and mandatory");

			try
			{
                var agent = await _agentRepository.GetAgentByEmailAsync(request.Email);

                if (agent == null)
                    return new AuthenticateRs("Incorrect email");

                var key = Encoding.ASCII.GetBytes(AuthSettings.JwtKey);

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity([new Claim(ClaimTypes.NameIdentifier, request.Email)]),
                    Expires = DateTime.UtcNow.AddMinutes(AuthSettings.ExpiresInMinutes),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                        SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var response = new AuthenticateRs(null);
                response.Token = tokenHandler.WriteToken(token);

                return response;
			}
			catch (Exception)
			{
                return new AuthenticateRs("Unknown error occurred");
			}
        }
    }
}
