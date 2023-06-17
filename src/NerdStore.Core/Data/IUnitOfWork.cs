namespace NerdStore.Core.Data
{
    public interface IUnitOfWork
    {
        void Rollback();
        Task<bool> CommitAsync();
    }
}
