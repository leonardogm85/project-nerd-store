using MediatR;
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.Common.DomainEvents;
using NerdStore.Core.Messages.Common.DomainNotifications;

namespace NerdStore.Core.Mediator
{
    public sealed class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishEventAsync<TEvent>(TEvent @event) where TEvent : Event
        {
            await _mediator.Publish(@event);
        }

        public async Task<bool> SendCommandAsync<TCommand>(TCommand command) where TCommand : Command
        {
            return await _mediator.Send(command);
        }

        public async Task PublishDomainNotificationAsync<TNotification>(TNotification notification) where TNotification : DomainNotification
        {
            await _mediator.Publish(notification);
        }

        public async Task PublishDomainEventAsync<TEvent>(TEvent @event) where TEvent : DomainEvent
        {
            await _mediator.Publish(@event);
        }
    }
}
