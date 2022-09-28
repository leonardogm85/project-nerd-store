using NerdStore.Core.DomainObjects;

namespace NerdStore.Core.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
