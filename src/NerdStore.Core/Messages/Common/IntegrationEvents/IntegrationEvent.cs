using MediatR;

namespace NerdStore.Core.Messages.Common.IntegrationEvents
{
    public abstract class IntegrationEvent : Event
    {
        protected IntegrationEvent(Guid aggregateId) : base(aggregateId)
        {
        }
    }
}
