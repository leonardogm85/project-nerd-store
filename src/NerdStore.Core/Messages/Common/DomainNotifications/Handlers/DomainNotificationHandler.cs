using MediatR;

namespace NerdStore.Core.Messages.Common.DomainNotifications.Handlers
{
    public sealed class DomainNotificationHandler : INotificationHandler<DomainNotification>, IDisposable
    {
        private readonly List<DomainNotification> _notifications = new();

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);

            return Task.CompletedTask;
        }

        public IEnumerable<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }

        public void Dispose()
        {
            _notifications.Clear();
        }
    }
}
