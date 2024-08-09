using CustomerCampaign.Data.Interfaces;
using CustomerCampaign.Repositories.Models;

namespace CustomerCampaign.Data.Repositories
{
    public class CustomerRepository : RepositoryBase, ICustomerRepository
    {
        public CustomerRepository(CustomerCampaignDbContext dataContext) : base(dataContext)
        {

        }

        public void AddCustomer(Customer customer)
        {
            DataContext.Customers.Add(customer);
        }

        public Customer GetCustomerById(int id)
        {
            return DataContext.Customers.SingleOrDefault(x => x.Id == id);
        }

        public Customer GetCustomerBySSN(string ssn)
        {
            return DataContext.Customers.SingleOrDefault(x => x.SSN == ssn);
        }
    }
}
