using MediatR;

namespace NerdStore.Core.Messages.Common.DomainEvents
{
    public abstract class DomainEvent : Message, INotification
    {
        public DateTime Timestamp { get; }

        protected DomainEvent(Guid aggregateId) : base(aggregateId)
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
