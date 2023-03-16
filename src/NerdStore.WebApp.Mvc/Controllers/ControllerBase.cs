using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.DomainNotifications;

namespace NerdStore.WebApp.Mvc.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly DomainNotificationHandler _domainNotificationHandler;

        protected readonly Guid ClientId = Guid.Parse("D2A38981-0099-4DB4-A5D5-18BF7A472985");

        protected ControllerBase(IMediatorHandler mediatorHandler, INotificationHandler<DomainNotification> domainNotificationHandler)
        {
            _mediatorHandler = mediatorHandler;
            _domainNotificationHandler = (DomainNotificationHandler)domainNotificationHandler;
        }

        protected bool IsValid()
        {
            return !_domainNotificationHandler.HasNotification();
        }

        protected IEnumerable<string> GetErrorMessages()
        {
            return _domainNotificationHandler.GetNotifications().Select(n => n.Value).ToList();
        }

        protected async Task NotifyErrorAsync(string key, string value)
        {
            await _mediatorHandler.PublishNotificationAsync(new DomainNotification(key, value));
        }
    }
}
