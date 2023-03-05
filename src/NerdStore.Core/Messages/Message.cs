namespace NerdStore.Core.Messages
{
    public abstract class Message
    {
        public string MessageType { get; }
        public Guid AggregateId { get; }

        protected Message(Guid aggregateId)
        {
            AggregateId = aggregateId;
            MessageType = GetType().Name;
        }
    }
}
