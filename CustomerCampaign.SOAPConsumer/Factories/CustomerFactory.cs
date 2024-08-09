using CustomerService;
using Microsoft.AspNetCore.Mvc;
using RewardService;
using SoapDemo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using CustomerServiceAddress = CustomerService.Address;

namespace CustomerCampaign.SOAPConsumer.Factories
{
    public class CustomerFactory
    {
        private readonly SOAPDemoSoapClient _customerClient;
        private readonly RewardServiceClient _rewardService;
        private readonly CustomerServiceClient _customerService;

        public CustomerFactory()
        {
            _rewardService = new RewardServiceClient(RewardServiceClient.EndpointConfiguration.BasicHttpBinding_IRewardService);
            _customerService = new CustomerServiceClient(CustomerServiceClient.EndpointConfiguration.BasicHttpBinding_ICustomerService);
            _customerClient = new SOAPDemoSoapClient(SOAPDemoSoapClient.EndpointConfiguration.SOAPDemoSoap);
        }

        public async Task<JsonResult> SyncCustomers()
        {
            try
            {
                var customerId = 1;
                var customers = new List<Customer>();
                do
                {
                    var customer = await _customerClient.FindPersonAsync(customerId.ToString());

                    // No more customers, exit the loop
                    if (customer == null)
                        break;

                    var customerRq = new Customer
                    {
                        Name = customer.Name,
                        SSN = customer.SSN,
                        DateOfBirth = customer.DOB
                    };

                    if (customer.Home != null)
                        customerRq.HomeAddress = new CustomerServiceAddress
                        {
                            City = customer.Home.City,
                            State = customer.Home.State,
                            Street = customer.Home.Street,
                            Zip = customer.Home.Zip
                        };

                    if (customer.Office != null)
                        customerRq.WorkAddress = new CustomerServiceAddress
                        {
                            City = customer.Office.City,
                            State = customer.Office.State,
                            Street = customer.Office.Street,
                            Zip = customer.Office.Zip
                        };

                    customers.Add(customerRq);

                    customerId++;
                } while (true);

                await _customerService.SyncCustomersAsync(new SyncCustomersRq() { Customers = customers.ToArray() });
                return new JsonResult(new { Success = true });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new JsonResult(new { Success = false, Error = "An error occured while trying to sync customers" });
            }
        }
    }
}
