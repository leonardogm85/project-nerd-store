using NerdStore.Core.Messages;

namespace NerdStore.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEventAsync<TEvent>(TEvent @event) where TEvent : Event;
    }
}
