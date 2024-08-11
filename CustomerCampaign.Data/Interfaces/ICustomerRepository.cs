using CustomerCampaign.Repositories.Models;

namespace CustomerCampaign.Data.Interfaces
{
    public interface ICustomerRepository : IRepositoryBase
    {
        Customer GetCustomerById(int id);
        Customer GetCustomerBySSN(string ssn);
        void AddCustomer(Customer customer);
        void AddCustomers(List<Customer> customers);
    }
}
