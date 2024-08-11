using CustomerCampaign.Infrastructure.Settings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CustomerCampaign.SOAP.Helpers
{
    public static class AuthHelper
    {
        public static (bool Invalid, string Error) ValidateToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                return (true, "Not authenticated");

            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthSettings.JwtKey)),
                    ValidateLifetime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                var tokenHandler = new JwtSecurityTokenHandler();

                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                return (false, null);
            }
            catch (SecurityTokenExpiredException)
            {
                return (true, "Token has expired");
            }
            catch (Exception ex)
            {
                return (true, "Invalid token");
            }
        }
    }
}
