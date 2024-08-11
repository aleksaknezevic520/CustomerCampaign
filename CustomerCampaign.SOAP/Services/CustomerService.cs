using Azure.Core;
using CustomerCampaign.Data.Interfaces;
using CustomerCampaign.Repositories.Models;
using CustomerCampaign.SOAP.Helpers;
using CustomerCampaign.SOAP.Interfaces;
using CustomerCampaign.SOAP.Models.Requests;
using CustomerCampaign.SOAP.Models.Responses;
using SOAPDemo;

namespace CustomerCampaign.SOAP.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly SOAPDemoSoapClient _soapDemoClient;

        public CustomerService(ICustomerRepository customerRepository, SOAPDemoSoapClient soapDemoClient)
        {
            _customerRepository = customerRepository;
            _soapDemoClient = soapDemoClient;
        }

        public async Task<SyncCustomersRs> SyncCustomers(SyncCustomersRq request)
        {
            var validationResult = AuthHelper.ValidateToken(request.AuthToken);

            if (validationResult.Invalid)
                return new SyncCustomersRs(validationResult.Error);

            try
            {
                var customerId = 1;
                var customers = new List<Customer>();
                do
                {
                    var customerExternal = await _soapDemoClient.FindPersonAsync(customerId.ToString());

                    // No more customers, exit the loop
                    if (customerExternal == null)
                        break;

                    var homeAddress = ObjectMapper.MapCustomerAddress(customerExternal.Home);
                    var workAddress = ObjectMapper.MapCustomerAddress(customerExternal.Office);

                    var customer = _customerRepository.GetCustomerBySSN(customerExternal.SSN);
                    if (customer == null)
                    {
                        var newCustomer = new Customer
                        {
                            Name = customerExternal.Name,
                            SSN = customerExternal.SSN,
                            DateOfBirth = customerExternal.DOB,
                            HomeAddress = homeAddress,
                            WorkAddress = workAddress
                        };

                        customers.Add(newCustomer);
                    }
                    else
                    {

                        // Update customer
                        customer.Name = customerExternal.Name;
                        customer.DateOfBirth = customerExternal.DOB;
                        customer.HomeAddress = homeAddress;
                        customer.WorkAddress = workAddress;
                    }

                    customerId++;
                } while (true);

                _customerRepository.AddCustomers(customers);
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
            var validationResult = AuthHelper.ValidateToken(request.AuthToken);

            if (validationResult.Invalid)
                return new AddCustomerRs(validationResult.Error);

            try
            {
                var customer = new Customer
                {
                    Name = request.Name,
                    SSN = request.SSN,
                    DateOfBirth = request.DateOfBirth,
                    IsLoyal = true,
                    HomeAddress = ObjectMapper.MapCustomerAddress(request.HomeAddress),
                    WorkAddress = ObjectMapper.MapCustomerAddress(request.HomeAddress)
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

        public async Task<UpdateCustomerLoyaltyStatusRs> UpdateCustomerLoyaltyStatus(UpdateCustomerLoyaltyStatusRq request)
        {
            var validationResult = AuthHelper.ValidateToken(request.AuthToken);

            if (validationResult.Invalid)
                return new UpdateCustomerLoyaltyStatusRs(validationResult.Error);

            try
            {
                var customer = _customerRepository.GetCustomerById(request.CustomerId);

                if(customer == null)
                    return new UpdateCustomerLoyaltyStatusRs("Customer not found");

                customer.IsLoyal = request.IsLoyal;

                await _customerRepository.CommitAsync();

                return new UpdateCustomerLoyaltyStatusRs(null);
            }
            catch (Exception)
            {
                return new UpdateCustomerLoyaltyStatusRs("Unknown error occurred");
            }
        }
    }
}
