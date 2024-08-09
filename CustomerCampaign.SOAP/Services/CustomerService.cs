using CustomerCampaign.Data.Interfaces;
using CustomerCampaign.Repositories.Models;
using CustomerCampaign.SOAP.Helpers;
using CustomerCampaign.SOAP.Interfaces;
using CustomerCampaign.SOAP.Models.Requests;

namespace CustomerCampaign.SOAP.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task SyncCustomers(SyncCustomersRq request)
        {
            foreach (var customerRq in request.Customers)
            {
                var customer = _customerRepository.GetCustomer(customerRq.SSN);
                var homeAddress = CustomerHelper.SetCustomerAddress(customerRq.HomeAddress);
                var workAddress = CustomerHelper.SetCustomerAddress(customerRq.WorkAddress);
                if (customer == null)
                {
                    _customerRepository.AddCustomer(new Customer
                    {
                        Name = customerRq.Name,
                        SSN = customerRq.SSN,
                        DateOfBirth = customerRq.DateOfBirth,
                        IsLoyal = true,
                        HomeAddress = homeAddress,
                        WorkAddress = workAddress
                    });
                    continue;
                }
                // Update customer
                customer.Name = customerRq.Name;
                customer.DateOfBirth = customerRq.DateOfBirth;
                customer.HomeAddress = homeAddress; 
                customer.WorkAddress = workAddress;
            }

            await _customerRepository.CommitAsync();
        }

        public async Task AddCustomer(AddCustomerRq request)
        {
            var customer = new Customer
            {
                Name = request.Name,
                SSN = request.SSN,
                DateOfBirth = request.DateOfBirth,
                IsLoyal = true,
                HomeAddress = CustomerHelper.SetCustomerAddress(request.HomeAddress),
                WorkAddress = CustomerHelper.SetCustomerAddress(request.HomeAddress)
            };

            _customerRepository.AddCustomer(customer);
            await _customerRepository.CommitAsync();
        }
    }
}
