using CustomerCampaign.Repositories.Models;

namespace CustomerCampaign.Data.Interfaces
{
    public interface ICustomerRepository : IRepositoryBase
    {
        void AddCustomer(Customer customer);
        Customer GetCustomerById(int id);
        Customer GetCustomerBySSN(string ssn);
    }
}
