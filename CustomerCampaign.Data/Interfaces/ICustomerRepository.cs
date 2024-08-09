using CustomerCampaign.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCampaign.Data.Interfaces
{
    public interface ICustomerRepository : IRepositoryBase
    {
        void AddCustomer(Customer customer);
        Customer GetCustomer(string ssn);
    }
}
