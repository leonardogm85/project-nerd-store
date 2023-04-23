namespace NerdStore.Core.Messages
{
    public abstract class Message
    {
        public Guid AggregateId { get; }
        public string MessageType { get; }

        protected Message(Guid aggregateId)
        {
            AggregateId = aggregateId;
            MessageType = GetType().Name;
        }
    }
}
