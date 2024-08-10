using AddressCommon = CustomerCampaign.Infrastructure.Models.Common.Address;
using RewardCommon = CustomerCampaign.Infrastructure.Models.Common.Reward;
using PurchaseItemCommon = CustomerCampaign.Infrastructure.Models.Common.PurchaseItem;
using CustomerCampaign.Repositories.Models;
using CustomerCampaign.Data.Models;

namespace CustomerCampaign.SOAP.Helpers
{
    internal static class ObjectMapper
    {
        internal static Address MapCustomerAddress(AddressCommon customerAddress) =>
            customerAddress == null ? null : new Address
            {
                City = customerAddress.City,
                State = customerAddress.State,
                Street = customerAddress.Street,
                Zip = customerAddress.Zip
            };

        internal static List<RewardCommon> MapRewards(List<Reward> rewards) =>
            rewards.Select(x => new RewardCommon
            {
                AgentId = x.AgentId,
                AgentName = x.Agent.Name,
                CustomerId = x.CustomerId,
                CustomerName = x.Customer.Name,
                CustomerSsn = x.Customer.SSN,
                DiscountPercent = x.DiscountPercent,
                CreatedDate = x.CreatedDate
            }).ToList();

        internal static RewardCommon MapReward(Reward reward) => 
            new RewardCommon
            {
                AgentId = reward.AgentId,
                AgentName = reward.Agent.Name,
                CustomerId = reward.CustomerId,
                CustomerName = reward.Customer.Name,
                CustomerSsn = reward.Customer.SSN,
                DiscountPercent = reward.DiscountPercent,
                CreatedDate = reward.CreatedDate
            };

        internal static List<PurchaseItemCommon> MapPurchases(List<PurchaseItem> purchaseItems) =>
            purchaseItems.Select(x => new PurchaseItemCommon
            {
                PurchaseId = x.PurchaseId,
                PurchaseoriginalTotalPrice = x.Purchase.Price,
                PurchaseDiscount = x.Purchase.Customer.Reward?.DiscountPercent,
                PurchaseDiscountedTotalPrice = x.Purchase.DiscountedPrice,
                PurchaseDate = x.Purchase.CreatedDate,
                CustomerName = x.Purchase.Customer.Name,
                PurchaseItemId = x.Id,
                PurchaseItemName = x.Name,
                PurchaseItemAmount = x.Amount,
                PurchaseItemUnitPrice = x.UnitPrice
            }).ToList();
    }
}
