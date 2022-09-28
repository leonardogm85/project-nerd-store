using MediatR;
using NerdStore.Core.Messages;

namespace NerdStore.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
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
    }
}
