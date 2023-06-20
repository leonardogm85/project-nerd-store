using NerdStore.Core.DataTransferObjects;

namespace EventSourcing.DataTransferObjects
{
    public sealed class EventDataTransferObject : IDataTransferObject
    {
        public Guid AggregateId { get; }
        public string MessageType { get; }
        public DateTime Timestamp { get; }

        public EventDataTransferObject(Guid aggregateId, string messageType, DateTime timestamp)
        {
            AggregateId = aggregateId;
            MessageType = messageType;
            Timestamp = timestamp;
        }
    }
}
