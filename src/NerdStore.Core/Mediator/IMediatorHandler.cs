﻿using NerdStore.Core.Messages;
using NerdStore.Core.Messages.Common.DomainEvents;
using NerdStore.Core.Messages.Common.DomainNotifications;

namespace NerdStore.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEventAsync<TEvent>(TEvent @event) where TEvent : Event;
        Task<bool> SendCommandAsync<TCommand>(TCommand command) where TCommand : Command;
        Task PublishDomainEventAsync<TEvent>(TEvent @event) where TEvent : DomainEvent;
        Task PublishDomainNotificationAsync(DomainNotification notification);
    }
}
