using CustomerCampaign.Data.Interfaces;
using CustomerCampaign.Repositories.Models;
using CustomerCampaign.SOAP.Helpers;
using CustomerCampaign.SOAP.Interfaces;
using CustomerCampaign.SOAP.Models.Requests;
using CustomerCampaign.SOAP.Models.Responses;

namespace CustomerCampaign.SOAP.Services
{
    public class AgentService : IAgentService
    {
        private readonly IAgentRepository _agentRepository;

        public AgentService(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        public async Task<CreateAgentRs> CreateAgent(CreateAgentRq request)
        {
            if (request == null)
                return new CreateAgentRs
                {
                    Success = false,
                    ErrorMessage = "Request object is null"
                };

            try
            {
                _agentRepository.CreateAgent(new Agent
                {
                    Name = request.Name,
                    Email = request.Email,
                    Password = request.Password // TODO: encrypt pwd when saving to db
                });

                await _agentRepository.CommitAsync();

                return new CreateAgentRs
                {
                    Success = true,
                    ErrorMessage = null
                };
            }
            catch (Exception)
            {
                return new CreateAgentRs
                {
                    Success = false,
                    ErrorMessage = "Un error occured while saving agent"
                };
            }
        }
    }
}
