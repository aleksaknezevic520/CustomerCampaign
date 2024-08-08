using CustomerCampaign.Services.Models.Requests;
using CustomerCampaign.Services.Models.Responses;
using System.ServiceModel;

namespace CustomerCampaign.Services.Interfaces
{
    [ServiceContract]
    public interface IRewardService
    {
        [OperationContract]
        AddCustomerRewardRs AddCustomerReward (AddCustomerRewardRq rq);
    }
}
