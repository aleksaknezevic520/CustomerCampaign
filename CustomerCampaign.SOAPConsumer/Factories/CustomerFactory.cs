using CustomerService;
using Microsoft.AspNetCore.Mvc;
using RewardService;
using System;
using System.Threading.Tasks;

namespace CustomerCampaign.SOAPConsumer.Factories
{
    public class CustomerFactory
    {
        private readonly RewardServiceClient _rewardService;
        private readonly CustomerServiceClient _customerService;

        public CustomerFactory(RewardServiceClient rewardService, CustomerServiceClient customerService)
        {
            _rewardService = rewardService;
            _customerService = customerService;
        }

        public async Task<JsonResult> SyncCustomers(SyncCustomersRq rq)
        {
            var response = await _customerService.SyncCustomersAsync(rq);
            return new JsonResult(response);
        }

        internal async Task<JsonResult> UpdateLoyaltyStatus(UpdateCustomerLoyaltyStatusRq request)
        {
            var response = await _customerService.UpdateCustomerLoyaltyStatusAsync(request);
            return new JsonResult(response);
        }
    }
}
