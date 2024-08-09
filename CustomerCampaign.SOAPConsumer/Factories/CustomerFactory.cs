using CustomerCampaign.Services.Interfaces;
using CustomerCampaign.Services.Models.Common;
using CustomerCampaign.Services.Models.Requests;
using CustomerCampaign.SOAP;
using Microsoft.AspNetCore.Mvc;
using SoapDemo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CustomerCampaign.SOAPConsumer.Factories
{
    public class CustomerFactory
    {
        private readonly ICustomerService _customerService;
        private readonly SOAPDemoSoapClient _customerClient;

        public CustomerFactory(ICustomerService customerService)
        {
            _customerService = customerService;
            _customerClient = new SOAPDemoSoapClient(SOAPDemoSoapClient.EndpointConfiguration.SOAPDemoSoap);
        }

        public async Task<JsonResult> SyncCustomers()
        {
            try
            {
                var request = new SyncCustomersRq { Customers = new List<Customer>() };
                var customerId = 1;
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
                        customerRq.HomeAddress = new Services.Models.Common.Address
                        {
                            City = customer.Home.City,
                            State = customer.Home.State,
                            Street = customer.Home.Street,
                            Zip = customer.Home.Zip
                        };

                    if (customer.Office != null)
                        customerRq.WorkAddress = new Services.Models.Common.Address
                        {
                            City = customer.Office.City,
                            State = customer.Office.State,
                            Street = customer.Office.Street,
                            Zip = customer.Office.Zip
                        };

                    request.Customers.Add(customerRq);

                    customerId++;
                } while (true);

                await _customerService.SyncCustomers(request);
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
