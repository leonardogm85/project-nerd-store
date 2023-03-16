using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Messages.CommonMessages.DomainNotifications;

namespace NerdStore.WebApp.Mvc.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly DomainNotificationHandler _domainNotificationHandler;

        public SummaryViewComponent(INotificationHandler<DomainNotification> domainNotificationHandler)
        {
            _domainNotificationHandler = (DomainNotificationHandler)domainNotificationHandler;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notifications = _domainNotificationHandler.GetNotifications();

            notifications.ToList().ForEach(notification =>
            {
                ViewData.ModelState.AddModelError(string.Empty, notification.Value);
            });

            return await Task.FromResult(View());
        }
    }
}
