using CustomerCampaign.SOAP.Models.Requests;
using CustomerCampaign.SOAP.Models.Responses;
using System.ServiceModel;

namespace CustomerCampaign.SOAP.Interfaces
{
    [ServiceContract]
    public interface IRewardService
    {
        [OperationContract]
        Task<GetRewardRs> GetRewardByIdAsync(int agentId, int customerId);

        [OperationContract]
        Task<GetRewardsRs> GetRewards();

        [OperationContract]
        Task<GetRewardsRs> GetRewardsForAgent(int AgentId);

        [OperationContract]
        Task<GetRewardsRs> GetRewardsForCustomer(int customerId);

        [OperationContract]
        Task<AddRewardRs> AddReward(AddRewardRq rq);

        [OperationContract]
        Task<UpdateRewardRs> UpdateReward(UpdateRewardRq rq);

        [OperationContract]
        Task<DeleteRewardRs> DeleteReward(DeleteRewardRq rq);
    }
}
