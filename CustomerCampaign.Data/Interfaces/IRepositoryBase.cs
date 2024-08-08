namespace CustomerCampaign.Data.Interfaces
{
    public interface IRepositoryBase
    {
        void Commit();
        Task CommitAsync();
    }
}
