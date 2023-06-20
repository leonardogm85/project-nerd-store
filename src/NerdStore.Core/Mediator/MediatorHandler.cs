using MediatR;
using NerdStore.Core.EventSourcing;
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.Common.DomainEvents;
using NerdStore.Core.Messages.Common.DomainNotifications;

namespace NerdStore.Core.Mediator
{
    public sealed class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventSourcingRepository _eventSourcingRepository;

        public MediatorHandler(IMediator mediator, IEventSourcingRepository eventSourcingRepository)
        {
            _mediator = mediator;
            _eventSourcingRepository = eventSourcingRepository;
        }

        // TODO: Split Event into ContextEvent and IntegrationEvent

        public async Task PublishEventAsync<TEvent>(TEvent @event) where TEvent : Event
        {
            await _mediator.Publish(@event);
            await _eventSourcingRepository
                .AddEventAsync(@event);
        }

        public async Task<bool> SendCommandAsync<TCommand>(TCommand command) where TCommand : Command
        {
            return await _mediator.Send(command);
        }

        // TODO: DomainEvent inherit from Event

        public async Task PublishDomainEventAsync<TEvent>(TEvent @event) where TEvent : DomainEvent
        {
            await _mediator.Publish(@event);
        }

        public async Task PublishDomainNotificationAsync(DomainNotification notification)
        {
            await _mediator.Publish(notification);
        }
    }
}
