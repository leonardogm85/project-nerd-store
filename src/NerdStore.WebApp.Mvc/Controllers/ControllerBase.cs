using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Mediator;
using NerdStore.Core.Messages.Common.DomainNotifications;
using NerdStore.Core.Messages.Common.DomainNotifications.Handlers;

namespace NerdStore.WebApp.Mvc.Controllers
{
    // TODO: Create Identities Project

    // TODO: Create ControllerBase class for the Client and another for the Employee

    // TODO: Implement Authentication and Authorization with Identity

    public abstract class ControllerBase : Controller
    {
        private readonly IMediatorHandler _mediatorHandler;

        // TODO: Create interface for DomainNotificationHandler

        private readonly DomainNotificationHandler _domainNotificationHandler;

        // TODO: Get authenticated client

        protected readonly Guid ClientId = Guid.Parse("D2A38981-0099-4DB4-A5D5-18BF7A472985");

        protected ControllerBase(IMediatorHandler mediatorHandler, INotificationHandler<DomainNotification> domainNotificationHandler)
        {
            _mediatorHandler = mediatorHandler;
            _domainNotificationHandler = (DomainNotificationHandler)domainNotificationHandler;
        }

        protected bool HasNotification()
        {
            return _domainNotificationHandler.HasNotification();
        }

        protected IEnumerable<string> GetNotifications()
        {
            return _domainNotificationHandler.GetNotifications()
                .Select(n => n.Value)
                .ToList();
        }

        protected async Task PublishNotificationAsync(string key, string value)
        {
            await _mediatorHandler.PublishDomainNotificationAsync(new(key, value));
        }
    }
}
