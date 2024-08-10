using CustomerCampaign.Data.Interfaces;
using CustomerCampaign.Data.Models;
using CustomerCampaign.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerCampaign.Data.Repositories
{
    public class PurchaseRepository : RepositoryBase, IPurchaseRepository
    {
        public PurchaseRepository(CustomerCampaignDbContext dataContext) : base(dataContext)
        {
        }

        public async Task<List<PurchaseItem>> GetPurchaseItemsAsync()
        {
            return await DataContext.PurchaseItems.ToListAsync();
        }
    }
}
