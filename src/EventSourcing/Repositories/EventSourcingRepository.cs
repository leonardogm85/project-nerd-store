using EventSourcing.Interfaces;
using EventStore.ClientAPI;
using NerdStore.Core.EventSourcing;
using NerdStore.Core.Messages;
using Newtonsoft.Json;
using System.Text;

namespace EventSourcing.Repositories
{
    public sealed class EventSourcingRepository : IEventSourcingRepository
    {
        private readonly IEventStoreService _eventStoreService;

        public EventSourcingRepository(IEventStoreService eventStoreService)
        {
            _eventStoreService = eventStoreService;
        }

        public async Task AddEventAsync<TEvent>(TEvent @event) where TEvent : Event
        {
            await _eventStoreService.GetConnection().AppendToStreamAsync(
                @event.AggregateId.ToString(),
                ExpectedVersion.Any,
                GetFormattedEvent(@event));
        }

        public async Task<IEnumerable<StoredEvent>> GetEventsByAggregateIdAsync(Guid aggregateId)
        {
            var events = await _eventStoreService.GetConnection().ReadStreamEventsBackwardAsync(
                aggregateId.ToString(),
                0,
                100,
                false);
            // TODO: Implement method

            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _eventStoreService.Dispose();
        }

        private static EventData GetFormattedEvent<TEvent>(TEvent @event) where TEvent : Event
        {
            return new EventData(
                Guid.NewGuid(),
                @event.MessageType,
                true,
                Encoding.Default.GetBytes(JsonConvert.SerializeObject(@event)),
                Array.Empty<byte>());
        }
    }
}
