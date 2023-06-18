namespace NerdStore.Core.EventSourcing
{
    public class StoredEvent
    {
        public Guid Id { get; }
        public string Type { get; }
        public DateTime OccurredIn { get; }
        public string Data { get; }

        public StoredEvent(Guid id, string type, DateTime occurredIn, string data)
        {
            Id = id;
            Type = type;
            OccurredIn = occurredIn;
            Data = data;
        }
    }
}
