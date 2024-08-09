﻿using CustomerCampaign.SOAP.Models.Requests;
using CustomerCampaign.SOAP.Models.Responses;
using System.ServiceModel;

namespace CustomerCampaign.SOAP.Interfaces
{
    [ServiceContract]
    public interface IRewardService
    {
        [OperationContract]
        Task<AddCustomerRewardRs> AddCustomerReward(AddCustomerRewardRq rq);
    }
}
