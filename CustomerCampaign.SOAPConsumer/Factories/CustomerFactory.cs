using CustomerService;
using Microsoft.AspNetCore.Mvc;
using RewardService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using CustomerServiceAddress = CustomerService.Address;

namespace CustomerCampaign.SOAPConsumer.Factories
{
    public class CustomerFactory
    {
        private readonly RewardServiceClient _rewardService;
        private readonly CustomerServiceClient _customerService;

        public CustomerFactory()
        {
            _rewardService = new RewardServiceClient(RewardServiceClient.EndpointConfiguration.BasicHttpBinding_IRewardService);
            _customerService = new CustomerServiceClient(CustomerServiceClient.EndpointConfiguration.BasicHttpBinding_ICustomerService);
        }

        public async Task<JsonResult> SyncCustomers()
        {
            var response = await _customerService.SyncCustomersAsync();
            return new JsonResult(response);
        }

        internal async Task<JsonResult> UpdateLoyaltyStatus(UpdateCustomerLoyaltyStatusRq request)
        {
            var response = await _customerService.UpdateCustomerLoyaltyStatusAsync(request);
            return new JsonResult(response);
        }
    }
}
