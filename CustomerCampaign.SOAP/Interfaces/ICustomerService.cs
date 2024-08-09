using CustomerCampaign.SOAP.Models.Requests;
using System.ServiceModel;

namespace CustomerCampaign.SOAP.Interfaces
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        Task SyncCustomers(SyncCustomersRq request);
        [OperationContract]
        Task AddCustomer(AddCustomerRq request);
    }
}
