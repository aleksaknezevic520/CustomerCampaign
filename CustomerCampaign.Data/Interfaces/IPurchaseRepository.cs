using CustomerCampaign.Data.Models;

namespace CustomerCampaign.Data.Interfaces
{
    public interface IPurchaseRepository : IRepositoryBase
    {
        Task<List<PurchaseItem>> GetPurchaseItemsAsync();
    }
}
