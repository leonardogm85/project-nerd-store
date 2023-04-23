using NerdStore.Core.Messages;
using NerdStore.Core.Messages.CommonMessages.DomainNotifications;

namespace NerdStore.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEventAsync<TEvent>(TEvent @event) where TEvent : Event;
        Task<bool> SendCommandAsync<TCommand>(TCommand command) where TCommand : Command;
        Task PublishNotificationAsync<TNotification>(TNotification notification) where TNotification : DomainNotification;
    }
}
