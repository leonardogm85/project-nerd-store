using MediatR;

namespace NerdStore.Core.Messages.Common.IntegrationEvents
{
    public abstract class IntegrationEvent : Message, INotification
    {
        public DateTime Timestamp { get; }

        protected IntegrationEvent(Guid aggregateId) : base(aggregateId)
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
