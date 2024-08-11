using CustomerCampaign.SOAP.Models.Requests;
using CustomerCampaign.SOAP.Models.Responses;
using System.ServiceModel;

namespace CustomerCampaign.SOAP.Interfaces
{
    [ServiceContract]
    public interface IRewardService
    {
        [OperationContract]
        Task<GetRewardRs> GetRewardByIdAsync(GetRewardByIdRq rq);

        [OperationContract]
        Task<GetRewardsRs> GetRewards(GetRewardsRq rq);

        [OperationContract]
        Task<GetRewardsRs> GetRewardsForAgent(GetRewardsForAgentRq rq);

        [OperationContract]
        Task<GetRewardRs> GetRewardForCustomer(GetRewardForCustomerRq rq);

        [OperationContract]
        Task<AddRewardRs> AddReward(AddRewardRq rq);

        [OperationContract]
        Task<UpdateRewardRs> UpdateReward(UpdateRewardRq rq);

        [OperationContract]
        Task<DeleteRewardRs> DeleteReward(DeleteRewardRq rq);
    }
}
