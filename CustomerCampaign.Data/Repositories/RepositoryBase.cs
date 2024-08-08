using CustomerCampaign.Data.Interfaces;
using CustomerCampaign.Repositories.Models;

namespace CustomerCampaign.Data.Repositories
{
    public class RepositoryBase : IRepositoryBase
    {
        protected CustomerCampaignDbContext DataContext { get; set; }

        public RepositoryBase(CustomerCampaignDbContext dataContext)
        {
            DataContext = dataContext;
        }

        public Task CommitAsync() => DataContext.SaveChangesAsync();

        public void Commit()
        {
            DataContext.SaveChanges();
        }
    }
}
