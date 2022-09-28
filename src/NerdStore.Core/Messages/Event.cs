using MediatR;

namespace NerdStore.Core.Messages
{
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event(Guid aggregateId) : base(aggregateId)
        {
            Timestamp = DateTime.Now;
        }
    }
}
