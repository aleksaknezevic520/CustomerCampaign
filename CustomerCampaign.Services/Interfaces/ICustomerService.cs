using CustomerCampaign.Services.Models.Requests;

namespace CustomerCampaign.Services.Interfaces
{
    public interface ICustomerService
    {
        Task SyncCustomers(SyncCustomersRq request);
        Task AddCustomer(AddCustomerRq request);
    }
}
