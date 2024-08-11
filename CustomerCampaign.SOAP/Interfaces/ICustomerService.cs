using CustomerCampaign.SOAP.Models.Requests;
using CustomerCampaign.SOAP.Models.Responses;
using System.ServiceModel;

namespace CustomerCampaign.SOAP.Interfaces
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        Task<SyncCustomersRs> SyncCustomers(SyncCustomersRq request);

        [OperationContract]
        Task<AddCustomerRs> AddCustomer(AddCustomerRq request);

        [OperationContract]
        Task<UpdateCustomerLoyaltyStatusRs> UpdateCustomerLoyaltyStatus(UpdateCustomerLoyaltyStatusRq request);
    }
}
