using EventStore.ClientAPI;

namespace EventSourcing.Interfaces
{
    public interface IEventStoreService : IDisposable
    {
        IEventStoreConnection GetConnection();
    }
}
