using CustomerCampaign.Repositories.Models;

namespace CustomerCampaign.SOAP.Helpers
{
    public static class AgentHelper
    {
        public static (bool IsValid, string ErrorMessage) ValidateAgent(Agent agent)
        {
            if(string.IsNullOrEmpty(agent.Name))
                return (false, $"{nameof(agent.Name)} is mandatory");

            if(string.IsNullOrEmpty(agent.Email))
                return (false, $"{nameof(agent.Email)} is mandatory");

            if(string.IsNullOrEmpty(agent.Password))
                return (false, $"{nameof(agent.Password)} is mandatory");

            if (agent.Password.Length < 8)
                return (false, $"{nameof(agent.Password)} must be at least 8 characters long");

            try
            {
                new System.Net.Mail.MailAddress(agent.Email.Trim());
            }
            catch
            {
                return (false, $"{nameof(agent.Email)} is invalid");
            }

            return (true, null);
        }
    }
}
