using NerdStore.Core.Messages;

namespace NerdStore.Core.EventSourcing
{
    public interface IEventSourcingRepository : IDisposable
    {
        Task AddEventAsync<TEvent>(TEvent @event) where TEvent : Event;
        Task<IEnumerable<StoredEvent>> GetEventsByAggregateIdAsync(Guid aggregateId);
    }
}
