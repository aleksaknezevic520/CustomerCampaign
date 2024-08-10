using CustomerCampaign.Data.Interfaces;
using CustomerCampaign.Repositories.Models;
using CustomerCampaign.SOAP.Helpers;
using CustomerCampaign.SOAP.Interfaces;
using CustomerCampaign.SOAP.Models.Requests;
using CustomerCampaign.SOAP.Models.Responses;

namespace CustomerCampaign.SOAP.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<SyncCustomersRs> SyncCustomers(SyncCustomersRq request)
        {
            if (request == null)
                return new SyncCustomersRs("Request object is null");

            try
            {
                foreach (var customerRq in request.Customers)
                {
                    var customer = _customerRepository.GetCustomerBySSN(customerRq.SSN);
                    var homeAddress = CustomerHelper.MapCustomerAddress(customerRq.HomeAddress);
                    var workAddress = CustomerHelper.MapCustomerAddress(customerRq.WorkAddress);
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

                return new SyncCustomersRs(null);
            }
            catch (Exception)
            {
                return new SyncCustomersRs("Unknown error occured while synchronizing customers");
            }
        }

        public async Task<AddCustomerRs> AddCustomer(AddCustomerRq request)
        {
            try
            {
                var customer = new Customer
                {
                    Name = request.Name,
                    SSN = request.SSN,
                    DateOfBirth = request.DateOfBirth,
                    IsLoyal = true,
                    HomeAddress = CustomerHelper.MapCustomerAddress(request.HomeAddress),
                    WorkAddress = CustomerHelper.MapCustomerAddress(request.HomeAddress)
                };

                _customerRepository.AddCustomer(customer);
                await _customerRepository.CommitAsync();

                return new AddCustomerRs(null);
            }
            catch (Exception)
            {
                return new AddCustomerRs("Unknown error occurred while saving customer");
            }
        }
    }
}
