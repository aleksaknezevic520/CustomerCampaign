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
        Task AddCustomer(AddCustomerRq request);
    }
}
