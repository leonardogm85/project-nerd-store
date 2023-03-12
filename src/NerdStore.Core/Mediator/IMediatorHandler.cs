using NerdStore.Core.Messages;

namespace NerdStore.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEventAsync<TEvent>(TEvent @event) where TEvent : Event;
        Task<bool> SendCommandAsync<TCommand>(TCommand command) where TCommand : Command;
    }
}
